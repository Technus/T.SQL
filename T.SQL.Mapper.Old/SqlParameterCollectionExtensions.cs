using System.Data.SqlClient;
using System.Data;

namespace T.SQL.Mapper.Old;

public static class SqlParameterCollectionExtensions
{
    public static IEnumerable<SqlParameter> AsEnumerable(this SqlParameterCollection sqlParameterCollection)
        => sqlParameterCollection.Cast<SqlParameter>();

    public static SqlParameter AddReturnValue(this SqlParameterCollection sqlParameters)
    {
        var o = sqlParameters.Add("@ReturnValue", SqlDbType.Int);
        o.Direction = ParameterDirection.ReturnValue;
        return o;
    }

    public static SqlParameter AddOutputInt(this SqlParameterCollection sqlParameters, string name) => AddOutput(sqlParameters, name, SqlDbType.Int);

    //public static SqlParameter AddOutputText(this SqlParameterCollection sqlParameters, string name)
    //{
    //    return AddOutput(sqlParameters, name, SqlDbType.Text);
    //}

    public static SqlParameter AddOutputString(this SqlParameterCollection sqlParameters, string name, int size) => AddOutput(sqlParameters, name, SqlDbType.VarChar, size);

    public static SqlParameter AddOutput(this SqlParameterCollection sqlParameters, string name, SqlDbType type, int size)
    {
        var sqlParameter = sqlParameters.Add(name, type, size);
        sqlParameter.Direction = ParameterDirection.Output;
        return sqlParameter;
    }

    public static SqlParameter AddOutput(this SqlParameterCollection sqlParameters, string name, SqlDbType type)
    {
        var sqlParameter = sqlParameters.Add(name, type);
        sqlParameter.Direction = ParameterDirection.Output;
        return sqlParameter;
    }

    public static SqlParameter AddInputOutput(this SqlParameterCollection sqlParameters, string parameterName, SqlDbType sqlDbType, int size)
    {
        var sqlParameter = sqlParameters.Add(parameterName, sqlDbType, size);
        sqlParameter.Direction = ParameterDirection.InputOutput;
        return sqlParameter;
    }

    public static SqlParameter AddInputOutput(this SqlParameterCollection sqlParameters, string parameterName, SqlDbType sqlDbType)
    {
        var sqlParameter = sqlParameters.Add(parameterName, sqlDbType);
        sqlParameter.Direction = ParameterDirection.InputOutput;
        return sqlParameter;
    }
}