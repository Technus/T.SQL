using System.Data.SqlClient;
using System.Data;

namespace T.SQL.Mapper.Old;


public static class SqlCommandExtensions
{
    public static SqlParameter AddInputOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType) => sqlCommand.Parameters.AddInputOutput(parameterName, sqlDbType);

    public static SqlParameter AddInputOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType, int size) => sqlCommand.Parameters.AddInputOutput(parameterName, sqlDbType, size);

    public static SqlParameter AddOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType) => sqlCommand.Parameters.AddOutput(parameterName, sqlDbType);

    public static SqlParameter AddOutput(this SqlCommand sqlCommand, string parameterName, SqlDbType sqlDbType, int size) => sqlCommand.Parameters.AddOutput(parameterName, sqlDbType, size);

    public static SqlParameter AddReturnParameter(this SqlCommand sqlCommand, string name = "@ReturnVal")
    {
        var sqlParameter = sqlCommand.Parameters.Add(name, SqlDbType.Int);
        sqlParameter.Direction = ParameterDirection.ReturnValue;
        return sqlParameter;
    }
}
