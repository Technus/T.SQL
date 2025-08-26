using System.Text;

namespace T.SQL.Core;

public static class Extensions
{
    public static bool IsMinSqlDateTime(this DateTime dateTime) => dateTime == SQL_MIN_DATETIME;

    public static bool IsMinSqlDateTimeOrMinDateTime(this DateTime dateTime) => dateTime == SQL_MIN_DATETIME || dateTime == DateTime.MinValue;

    /// <summary>
    /// Minimal SQL datetime of 1900-01-01 00:00:00
    /// </summary>
    public static readonly DateTime SQL_MIN_DATETIME = DateTime.Parse("1900-01-01 00:00:00");
    public static T With<T>(this T item, Action<T> action) where T : class
    {
        action(item);
        return item;
    }

    public static T With<T>(this T item, Func<T, T> action) => action(item);

    public static bool Contains(this string source, string toCheck, StringComparison comp) => source.IndexOf(toCheck, comp) >= 0;
    public static bool Contains(this string source, char toCheck) => source.IndexOf(toCheck) >= 0;

    public static string RemoveStrings(this string input, params string[] stringsToRemove)
    {
        if (input is null || stringsToRemove is null || stringsToRemove.Length == 0)
            return input;
        if (stringsToRemove.Length == 1)
            return input.Replace(stringsToRemove[0], string.Empty);

        var sb = new StringBuilder(input);
        foreach (var str in stringsToRemove)
            sb.Replace(str, string.Empty);

        return sb.ToString();
    }

    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value))
            return value;
        return (value.Length <= maxLength) ? value : value.Substring(0, maxLength);
    }

    public static Dictionary<K, Dictionary<ID, V>> ToMultiDictionary<K, ID, V>(this IReadOnlyDictionary<ID, V> d, Func<V, K> key, IEqualityComparer<K> cmp = default) =>
        d.GroupBy(i => key(i.Value), cmp).ToDictionary(g => g.Key, g => g.ToDictionary(id => id.Key, id => id.Value));
}
