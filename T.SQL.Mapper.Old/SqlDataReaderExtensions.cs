using System.Data.SqlClient;

namespace T.SQL.Mapper.Old;

public static class SqlDataReaderExtensions
{
    public static bool HasColumn(this SqlDataReader dr, string columnName)
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public static int GetColumnId(this SqlDataReader dr, string columnName)
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    public static bool TryGetColumnId(this SqlDataReader row, string columnName, out int columnId)
    {
        columnId = row.GetColumnId(columnName);
        return columnId is >= 0;
    }

    public static bool IsDBNull(this SqlDataReader row, string columnName) => row.IsDBNull(row.GetOrdinal(columnName));

    public static TimeSpan GetTimeSpan(this SqlDataReader row, string columnName) => row.GetTimeSpan(row.GetOrdinal(columnName));

    public static TimeSpan GetTimeSpanOrDefault(this SqlDataReader row, string columnName, TimeSpan defaultValue = default) => row.GetTimeSpanOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static TimeSpan GetTimeSpanOrDefault(this SqlDataReader row, int columnId, TimeSpan defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetTimeSpan(columnId);

    public static TimeSpan? GetTimeSpanOrNull(this SqlDataReader row, string columnName) => row.GetTimeSpanOrNull(row.GetOrdinal(columnName));
    public static TimeSpan? GetTimeSpanOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetTimeSpan(columnId);

    public static DateTime GetDateTime(this SqlDataReader row, string columnName) => row.GetDateTime(row.GetOrdinal(columnName));

    public static DateTime GetDateTimeOrDefault(this SqlDataReader row, string columnName, DateTime defaultValue = default) => row.GetDateTimeOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static DateTime GetDateTimeOrDefault(this SqlDataReader row, int columnId, DateTime defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDateTime(columnId);

    public static DateTime? GetDateTimeOrNull(this SqlDataReader row, string columnName) => row.GetDateTimeOrNull(row.GetOrdinal(columnName));
    public static DateTime? GetDateTimeOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDateTime(columnId);

    public static DateTimeOffset GetDateTimeOffset(this SqlDataReader row, string columnName) => row.GetDateTimeOffset(row.GetOrdinal(columnName));

    public static DateTimeOffset GetDateTimeOffsetOrDefault(this SqlDataReader row, string columnName, DateTimeOffset defaultValue = default) => row.GetDateTimeOffsetOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static DateTimeOffset GetDateTimeOffsetOrDefault(this SqlDataReader row, int columnId, DateTimeOffset defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDateTimeOffset(columnId);

    public static DateTimeOffset? GetDateTimeOffsetOrNull(this SqlDataReader row, string columnName) => row.GetDateTimeOffsetOrNull(row.GetOrdinal(columnName));
    public static DateTimeOffset? GetDateTimeOffsetOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDateTimeOffset(columnId);

    public static Guid GetGuid(this SqlDataReader row, string columnName) => row.GetGuid(row.GetOrdinal(columnName));

    public static Guid GetGuidOrDefault(this SqlDataReader row, string columnName, Guid defaultValue = default) => row.GetGuidOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static Guid GetGuidOrDefault(this SqlDataReader row, int columnId, Guid defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetGuid(columnId);

    public static Guid? GetGuidOrNull(this SqlDataReader row, string columnName) => row.GetGuidOrNull(row.GetOrdinal(columnName));
    public static Guid? GetGuidOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetGuid(columnId);

    public static bool GetBoolean(this SqlDataReader row, string columnName) => row.GetBoolean(row.GetOrdinal(columnName));

    public static bool GetBooleanOrDefault(this SqlDataReader row, string columnName, bool defaultValue = default) => row.GetBooleanOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static bool GetBooleanOrDefault(this SqlDataReader row, int columnId, bool defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetBoolean(columnId);

    public static bool? GetBooleanOrNull(this SqlDataReader row, string columnName) => row.GetBooleanOrNull(row.GetOrdinal(columnName));
    public static bool? GetBooleanOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetBoolean(columnId);

    public static byte GetByte(this SqlDataReader row, string columnName) => row.GetByte(row.GetOrdinal(columnName));

    public static byte GetByteOrDefault(this SqlDataReader row, string columnName, byte defaultValue = default) => row.GetByteOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static byte GetByteOrDefault(this SqlDataReader row, int columnId, byte defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetByte(columnId);

    public static byte? GetByteOrNull(this SqlDataReader row, string columnName) => row.GetByteOrNull(row.GetOrdinal(columnName));
    public static byte? GetByteOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetByte(columnId);

    public static short GetInt16(this SqlDataReader row, string columnName) => row.GetInt16(row.GetOrdinal(columnName));

    public static short GetInt16OrDefault(this SqlDataReader row, string columnName, short defaultValue = default) => row.GetInt16OrDefault(row.GetOrdinal(columnName), defaultValue);
    public static short GetInt16OrDefault(this SqlDataReader row, int columnId, short defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetInt16(columnId);

    public static short? GetInt16OrNull(this SqlDataReader row, string columnName) => row.GetInt16OrNull(row.GetOrdinal(columnName));
    public static short? GetInt16OrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetInt16(columnId);

    public static int GetInt32(this SqlDataReader row, string columnName) => row.GetInt32(row.GetOrdinal(columnName));

    public static int GetInt32OrDefault(this SqlDataReader row, string columnName, int defaultValue = default) => row.GetInt32OrDefault(row.GetOrdinal(columnName), defaultValue);
    public static int GetInt32OrDefault(this SqlDataReader row, int columnId, int defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetInt32(columnId);

    public static int? GetInt32OrNull(this SqlDataReader row, string columnName) => row.GetInt32OrNull(row.GetOrdinal(columnName));
    public static int? GetInt32OrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetInt32(columnId);

    public static long GetInt64(this SqlDataReader row, string columnName) => row.GetInt64(row.GetOrdinal(columnName));

    public static long GetInt64OrDefault(this SqlDataReader row, string columnName, long defaultValue = default) => row.GetInt64OrDefault(row.GetOrdinal(columnName), defaultValue);
    public static long GetInt64OrDefault(this SqlDataReader row, int columnId, long defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetInt64(columnId);

    public static long? GetInt64OrNull(this SqlDataReader row, string columnName) => row.GetInt64OrNull(row.GetOrdinal(columnName));
    public static long? GetInt64OrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetInt64(columnId);

    public static float GetFloat(this SqlDataReader row, string columnName) => row.GetFloat(row.GetOrdinal(columnName));

    public static float GetFloatOrDefault(this SqlDataReader row, string columnName, float defaultValue = default) => row.GetFloatOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static float GetFloatOrDefault(this SqlDataReader row, int columnId, float defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetFloat(columnId);

    public static float? GetFloatOrNull(this SqlDataReader row, string columnName) => row.GetFloatOrNull(row.GetOrdinal(columnName));
    public static float? GetFloatOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetFloat(columnId);

    public static double GetDouble(this SqlDataReader row, string columnName) => row.GetDouble(row.GetOrdinal(columnName));

    public static double GetDoubleOrDefault(this SqlDataReader row, string columnName, double defaultValue = default) => row.GetDoubleOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static double GetDoubleOrDefault(this SqlDataReader row, int columnId, double defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDouble(columnId);

    public static double? GetDoubleOrNull(this SqlDataReader row, string columnName) => row.GetDoubleOrNull(row.GetOrdinal(columnName));
    public static double? GetDoubleOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDouble(columnId);

    public static decimal GetDecimal(this SqlDataReader row, string columnName) => row.GetDecimal(row.GetOrdinal(columnName));

    public static decimal GetDecimalOrDefault(this SqlDataReader row, string columnName, decimal defaultValue = default) => row.GetDecimalOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static decimal GetDecimalOrDefault(this SqlDataReader row, int columnId, decimal defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDecimal(columnId);

    public static decimal? GetDecimalOrNull(this SqlDataReader row, string columnName) => row.GetDecimalOrNull(row.GetOrdinal(columnName));
    public static decimal? GetDecimalOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDecimal(columnId);

    public static char GetChar(this SqlDataReader row, string columnName) => row.GetChar(row.GetOrdinal(columnName));

    public static char GetCharOrDefault(this SqlDataReader row, string columnName, char defaultValue = default) => row.GetCharOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static char GetCharOrDefault(this SqlDataReader row, int columnId, char defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetChar(columnId);

    public static char? GetCharOrNull(this SqlDataReader row, string columnName) => row.GetCharOrNull(row.GetOrdinal(columnName));
    public static char? GetCharOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetChar(columnId);

    public static string GetString(this SqlDataReader row, string columnName) => row.GetString(row.GetOrdinal(columnName));

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static string? GetStringOrDefault(this SqlDataReader row, string columnName, string? defaultValue = default) => row.GetStringOrDefault(row.GetOrdinal(columnName), defaultValue);

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static string? GetStringOrDefault(this SqlDataReader row, int columnId, string? defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetString(columnId);

    public static string? GetStringOrNull(this SqlDataReader row, string columnName) => row.GetStringOrNull(row.GetOrdinal(columnName));
    public static string? GetStringOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetString(columnId);

    public static string GetStringOrEmpty(this SqlDataReader row, string columnName) => row.GetStringOrEmpty(row.GetOrdinal(columnName));
    public static string GetStringOrEmpty(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? string.Empty : row.GetString(columnId);

    public static byte[] GetBytes(this SqlDataReader row, int columnId) => (byte[])row[columnId];

    public static byte[] GetBytes(this SqlDataReader row, string columnName) => row.GetBytes(row.GetOrdinal(columnName));

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static byte[]? GetBytesOrDefault(this SqlDataReader row, string columnName, byte[]? defaultValue = default) => row.GetBytesOrDefault(row.GetOrdinal(columnName), defaultValue);

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static byte[]? GetBytesOrDefault(this SqlDataReader row, int columnId, byte[]? defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetBytes(columnId);

    public static byte[]? GetBytesOrNull(this SqlDataReader row, string columnName) => row.GetBytesOrNull(row.GetOrdinal(columnName));
    public static byte[]? GetBytesOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetBytes(columnId);

    public static byte[] GetBytesOrEmpty(this SqlDataReader row, string columnName) => row.GetBytesOrEmpty(row.GetOrdinal(columnName));
    public static byte[] GetBytesOrEmpty(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? [] : row.GetBytes(columnId);

    public static Stream GetStream(this SqlDataReader row, string columnName) => row.GetStream(row.GetOrdinal(columnName));

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static Stream? GetStreamOrDefault(this SqlDataReader row, string columnName, Stream? defaultValue = default) => row.GetStreamOrDefault(row.GetOrdinal(columnName), defaultValue);

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static Stream? GetStreamOrDefault(this SqlDataReader row, int columnId, Stream? defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetStream(columnId);

    public static Stream? GetStreamOrNull(this SqlDataReader row, string columnName) => row.GetStreamOrNull(row.GetOrdinal(columnName));
    public static Stream? GetStreamOrNull(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? null : row.GetStream(columnId);

    public static Stream GetStreamOrEmpty(this SqlDataReader row, string columnName) => row.GetStreamOrEmpty(row.GetOrdinal(columnName));
    public static Stream GetStreamOrEmpty(this SqlDataReader row, int columnId) => row.IsDBNull(columnId) ? Stream.Null : row.GetStream(columnId);
}