using Microsoft.Data.SqlClient;

namespace T.SQL.Mapper;

public static class Extensions
{
    public static Dictionary<K, V> ToDictionary<K, V>(this SqlDataReader r, Func<V, K> key, Func<SqlDataReader, V> selector, IEqualityComparer<K> cmp = default)
    {
        var l = new List<V>();
        while (r.Read())
            l.Add(selector(r));
        r.NextResult();

        return l.ToDictionary(key, cmp);
    }
}
