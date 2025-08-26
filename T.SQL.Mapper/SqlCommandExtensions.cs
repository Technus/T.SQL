using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using T.SQL.Core;

namespace T.SQL.Mapper;


public static class SqlCommandExtensions
{
    public static string PrintSqlCommand(this SqlCommand sqlCommand)
    {
        var sb = new StringBuilder(32);
        sb.AppendLine(sqlCommand.CommandText);
        sb.AppendLine("Parameters: ");
        for (int i = 0; i < sqlCommand.Parameters.Count; i++)
        {
            var param = sqlCommand.Parameters[i];
            sb.Append('\t').Append(param.ParameterName).Append(" = ").Append(param.Value).AppendLine();
        }
        sb.Append("Timeout: ").Append(sqlCommand.CommandTimeout).Append(" sec.");
        return sb.ToString();
    }

    public static string ToStringParameters(this SqlCommand sqlCommand, string procedureName = default)
    {
        procedureName ??= sqlCommand.CommandText;
        try
        {
            return new StringBuilder(procedureName).Append("(")
                .AppendJoin(", ", sqlCommand.Parameters.AsEnumerable(), static (sb, p) => sb.Append(p.ParameterName).Append("=").Append(p.Value)).Append(")").ToString();
        }
        catch (Exception)
        {
            return $"{procedureName} (nie udało się zalogować parametrów)";
        }
    }

    public static SqlParameter AddInputOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType)
    {
        return sqlCommand.Parameters.AddInputOutput(parameterName, sqlDbType);
    }

    public static SqlParameter AddInputOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType, int size)
    {
        return sqlCommand.Parameters.AddInputOutput(parameterName, sqlDbType, size);
    }

    public static SqlParameter AddOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType)
    {
        return sqlCommand.Parameters.AddOutput(parameterName, sqlDbType);
    }

    public static SqlParameter AddOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType, int size)
    {
        return sqlCommand.Parameters.AddOutput(parameterName, sqlDbType, size);
    }

    public static SqlParameter AddReturnParameter(this SqlCommand sqlCommand, string name = "@ReturnVal")
    {
        SqlParameter sqlParameter = sqlCommand.Parameters.Add(name, SqlDbType.Int);
        sqlParameter.Direction = ParameterDirection.ReturnValue;
        return sqlParameter;
    }
}
