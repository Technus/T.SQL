using Microsoft.Data.SqlClient.Server;

namespace T.SQL.Mapper;
public static class SqlDataRecordExtensions
{
    public static bool HasColumn(this SqlDataRecord dr, string columnName)
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public static int GetColumnId(this SqlDataRecord dr, string columnName)
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    public static bool TryGetColumnId(this SqlDataRecord row, string columnName, out int columnId)
    {
        columnId = row.GetColumnId(columnName);
        return columnId is >= 0;
    }

    public static bool IsDBNull(this SqlDataRecord row, string columnName) => row.IsDBNull(row.GetOrdinal(columnName));

    public static TimeSpan GetTimeSpan(this SqlDataRecord row, string columnName) => row.GetTimeSpan(row.GetOrdinal(columnName));

    public static TimeSpan GetTimeSpanOrDefault(this SqlDataRecord row, string columnName, TimeSpan defaultValue = default) => row.GetTimeSpanOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static TimeSpan GetTimeSpanOrDefault(this SqlDataRecord row, int columnId, TimeSpan defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetTimeSpan(columnId);

    public static TimeSpan? GetTimeSpanOrNull(this SqlDataRecord row, string columnName) => row.GetTimeSpanOrNull(row.GetOrdinal(columnName));
    public static TimeSpan? GetTimeSpanOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetTimeSpan(columnId);

    public static DateTime GetDateTime(this SqlDataRecord row, string columnName) => row.GetDateTime(row.GetOrdinal(columnName));

    public static DateTime GetDateTimeOrDefault(this SqlDataRecord row, string columnName, DateTime defaultValue = default) => row.GetDateTimeOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static DateTime GetDateTimeOrDefault(this SqlDataRecord row, int columnId, DateTime defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDateTime(columnId);

    public static DateTime? GetDateTimeOrNull(this SqlDataRecord row, string columnName) => row.GetDateTimeOrNull(row.GetOrdinal(columnName));
    public static DateTime? GetDateTimeOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDateTime(columnId);

    public static DateTimeOffset GetDateTimeOffset(this SqlDataRecord row, string columnName) => row.GetDateTimeOffset(row.GetOrdinal(columnName));

    public static DateTimeOffset GetDateTimeOffsetOrDefault(this SqlDataRecord row, string columnName, DateTimeOffset defaultValue = default) => row.GetDateTimeOffsetOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static DateTimeOffset GetDateTimeOffsetOrDefault(this SqlDataRecord row, int columnId, DateTimeOffset defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDateTimeOffset(columnId);

    public static DateTimeOffset? GetDateTimeOffsetOrNull(this SqlDataRecord row, string columnName) => row.GetDateTimeOffsetOrNull(row.GetOrdinal(columnName));
    public static DateTimeOffset? GetDateTimeOffsetOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDateTimeOffset(columnId);

    public static Guid GetGuid(this SqlDataRecord row, string columnName) => row.GetGuid(row.GetOrdinal(columnName));

    public static Guid GetGuidOrDefault(this SqlDataRecord row, string columnName, Guid defaultValue = default) => row.GetGuidOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static Guid GetGuidOrDefault(this SqlDataRecord row, int columnId, Guid defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetGuid(columnId);

    public static Guid? GetGuidOrNull(this SqlDataRecord row, string columnName) => row.GetGuidOrNull(row.GetOrdinal(columnName));
    public static Guid? GetGuidOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetGuid(columnId);

    public static bool GetBoolean(this SqlDataRecord row, string columnName) => row.GetBoolean(row.GetOrdinal(columnName));

    public static bool GetBooleanOrDefault(this SqlDataRecord row, string columnName, bool defaultValue = default) => row.GetBooleanOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static bool GetBooleanOrDefault(this SqlDataRecord row, int columnId, bool defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetBoolean(columnId);

    public static bool? GetBooleanOrNull(this SqlDataRecord row, string columnName) => row.GetBooleanOrNull(row.GetOrdinal(columnName));
    public static bool? GetBooleanOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetBoolean(columnId);

    public static byte GetByte(this SqlDataRecord row, string columnName) => row.GetByte(row.GetOrdinal(columnName));

    public static byte GetByteOrDefault(this SqlDataRecord row, string columnName, byte defaultValue = default) => row.GetByteOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static byte GetByteOrDefault(this SqlDataRecord row, int columnId, byte defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetByte(columnId);

    public static byte? GetByteOrNull(this SqlDataRecord row, string columnName) => row.GetByteOrNull(row.GetOrdinal(columnName));
    public static byte? GetByteOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetByte(columnId);

    public static short GetInt16(this SqlDataRecord row, string columnName) => row.GetInt16(row.GetOrdinal(columnName));

    public static short GetInt16OrDefault(this SqlDataRecord row, string columnName, short defaultValue = default) => row.GetInt16OrDefault(row.GetOrdinal(columnName), defaultValue);
    public static short GetInt16OrDefault(this SqlDataRecord row, int columnId, short defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetInt16(columnId);

    public static short? GetInt16OrNull(this SqlDataRecord row, string columnName) => row.GetInt16OrNull(row.GetOrdinal(columnName));
    public static short? GetInt16OrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetInt16(columnId);

    public static int GetInt32(this SqlDataRecord row, string columnName) => row.GetInt32(row.GetOrdinal(columnName));

    public static int GetInt32OrDefault(this SqlDataRecord row, string columnName, int defaultValue = default) => row.GetInt32OrDefault(row.GetOrdinal(columnName), defaultValue);
    public static int GetInt32OrDefault(this SqlDataRecord row, int columnId, int defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetInt32(columnId);

    public static int? GetInt32OrNull(this SqlDataRecord row, string columnName) => row.GetInt32OrNull(row.GetOrdinal(columnName));
    public static int? GetInt32OrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetInt32(columnId);

    public static long GetInt64(this SqlDataRecord row, string columnName) => row.GetInt64(row.GetOrdinal(columnName));

    public static long GetInt64OrDefault(this SqlDataRecord row, string columnName, long defaultValue = default) => row.GetInt64OrDefault(row.GetOrdinal(columnName), defaultValue);
    public static long GetInt64OrDefault(this SqlDataRecord row, int columnId, long defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetInt64(columnId);

    public static long? GetInt64OrNull(this SqlDataRecord row, string columnName) => row.GetInt64OrNull(row.GetOrdinal(columnName));
    public static long? GetInt64OrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetInt64(columnId);

    public static float GetFloat(this SqlDataRecord row, string columnName) => row.GetFloat(row.GetOrdinal(columnName));

    public static float GetFloatOrDefault(this SqlDataRecord row, string columnName, float defaultValue = default) => row.GetFloatOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static float GetFloatOrDefault(this SqlDataRecord row, int columnId, float defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetFloat(columnId);

    public static float? GetFloatOrNull(this SqlDataRecord row, string columnName) => row.GetFloatOrNull(row.GetOrdinal(columnName));
    public static float? GetFloatOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetFloat(columnId);

    public static double GetDouble(this SqlDataRecord row, string columnName) => row.GetDouble(row.GetOrdinal(columnName));

    public static double GetDoubleOrDefault(this SqlDataRecord row, string columnName, double defaultValue = default) => row.GetDoubleOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static double GetDoubleOrDefault(this SqlDataRecord row, int columnId, double defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDouble(columnId);

    public static double? GetDoubleOrNull(this SqlDataRecord row, string columnName) => row.GetDoubleOrNull(row.GetOrdinal(columnName));
    public static double? GetDoubleOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDouble(columnId);

    public static decimal GetDecimal(this SqlDataRecord row, string columnName) => row.GetDecimal(row.GetOrdinal(columnName));

    public static decimal GetDecimalOrDefault(this SqlDataRecord row, string columnName, decimal defaultValue = default) => row.GetDecimalOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static decimal GetDecimalOrDefault(this SqlDataRecord row, int columnId, decimal defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetDecimal(columnId);

    public static decimal? GetDecimalOrNull(this SqlDataRecord row, string columnName) => row.GetDecimalOrNull(row.GetOrdinal(columnName));
    public static decimal? GetDecimalOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetDecimal(columnId);

    public static char GetChar(this SqlDataRecord row, string columnName) => row.GetChar(row.GetOrdinal(columnName));

    public static char GetCharOrDefault(this SqlDataRecord row, string columnName, char defaultValue = default) => row.GetCharOrDefault(row.GetOrdinal(columnName), defaultValue);
    public static char GetCharOrDefault(this SqlDataRecord row, int columnId, char defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetChar(columnId);

    public static char? GetCharOrNull(this SqlDataRecord row, string columnName) => row.GetCharOrNull(row.GetOrdinal(columnName));
    public static char? GetCharOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetChar(columnId);

    public static string GetString(this SqlDataRecord row, string columnName) => row.GetString(row.GetOrdinal(columnName));

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static string? GetStringOrDefault(this SqlDataRecord row, string columnName, string? defaultValue = default) => row.GetStringOrDefault(row.GetOrdinal(columnName), defaultValue);

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static string? GetStringOrDefault(this SqlDataRecord row, int columnId, string? defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetString(columnId);

    public static string? GetStringOrNull(this SqlDataRecord row, string columnName) => row.GetStringOrNull(row.GetOrdinal(columnName));
    public static string? GetStringOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetString(columnId);

    public static string GetStringOrEmpty(this SqlDataRecord row, string columnName) => row.GetStringOrEmpty(row.GetOrdinal(columnName));
    public static string GetStringOrEmpty(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? string.Empty : row.GetString(columnId);

    public static byte[] GetBytes(this SqlDataRecord row, int columnId) => (byte[])row[columnId];

    public static byte[] GetBytes(this SqlDataRecord row, string columnName) => row.GetBytes(row.GetOrdinal(columnName));

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static byte[]? GetBytesOrDefault(this SqlDataRecord row, string columnName, byte[]? defaultValue = default) => row.GetBytesOrDefault(row.GetOrdinal(columnName), defaultValue);

    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static byte[]? GetBytesOrDefault(this SqlDataRecord row, int columnId, byte[]? defaultValue = default) => row.IsDBNull(columnId) ? defaultValue : row.GetBytes(columnId);

    public static byte[]? GetBytesOrNull(this SqlDataRecord row, string columnName) => row.GetBytesOrNull(row.GetOrdinal(columnName));
    public static byte[]? GetBytesOrNull(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? null : row.GetBytes(columnId);

    public static byte[] GetBytesOrEmpty(this SqlDataRecord row, string columnName) => row.GetBytesOrEmpty(row.GetOrdinal(columnName));
    public static byte[] GetBytesOrEmpty(this SqlDataRecord row, int columnId) => row.IsDBNull(columnId) ? [] : row.GetBytes(columnId);

    public static void SetBoolean(this SqlDataRecord row, string columnName, bool value) => row.SetBoolean(row.GetOrdinal(columnName), value);

    public static void SetBooleanOrNull(this SqlDataRecord row, string columnName, bool? value) => row.SetBooleanOrNull(row.GetOrdinal(columnName), value);
    public static void SetBooleanOrNull(this SqlDataRecord row, int columnId, bool? value)
    {
        if (value is not null)
            row.SetBoolean(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetBooleanOrDefault(this SqlDataRecord row, string columnName, bool? value, bool defaultValue = default) => row.SetBooleanOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetBooleanOrDefault(this SqlDataRecord row, int columnId, bool? value, bool defaultValue = default)
    {
        row.SetBoolean(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetByte(this SqlDataRecord row, string columnName, byte value) => row.SetByte(row.GetOrdinal(columnName), value);

    public static void SetByteOrNull(this SqlDataRecord row, string columnName, byte? value) => row.SetByteOrNull(row.GetOrdinal(columnName), value);
    public static void SetByteOrNull(this SqlDataRecord row, int columnId, byte? value)
    {
        if (value is not null)
            row.SetByte(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetByteOrDefault(this SqlDataRecord row, string columnName, byte? value, byte defaultValue = default) => row.SetByteOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetByteOrDefault(this SqlDataRecord row, int columnId, byte? value, byte defaultValue = default)
    {
        row.SetByte(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetChar(this SqlDataRecord row, string columnName, char value) => row.SetChar(row.GetOrdinal(columnName), value);

    public static void SetCharOrNull(this SqlDataRecord row, string columnName, char? value) => row.SetCharOrNull(row.GetOrdinal(columnName), value);
    public static void SetCharOrNull(this SqlDataRecord row, int columnId, char? value)
    {
        if (value is not null)
            row.SetChar(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetCharOrDefault(this SqlDataRecord row, string columnName, char? value, char defaultValue = default) => row.SetCharOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetCharOrDefault(this SqlDataRecord row, int columnId, char? value, char defaultValue = default)
    {
        row.SetChar(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetDateTime(this SqlDataRecord row, string columnName, DateTime value) => row.SetDateTime(row.GetOrdinal(columnName), value);

    public static void SetDateTimeOrNull(this SqlDataRecord row, string columnName, DateTime? value) => row.SetDateTimeOrNull(row.GetOrdinal(columnName), value);
    public static void SetDateTimeOrNull(this SqlDataRecord row, int columnId, DateTime? value)
    {
        if (value is not null)
            row.SetDateTime(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetDateTimeOrDefault(this SqlDataRecord row, string columnName, DateTime? value, DateTime defaultValue = default) => row.SetDateTimeOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetDateTimeOrDefault(this SqlDataRecord row, int columnId, DateTime? value, DateTime defaultValue = default)
    {
        row.SetDateTime(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetDateTimeOffset(this SqlDataRecord row, string columnName, DateTimeOffset value) => row.SetDateTimeOffset(row.GetOrdinal(columnName), value);

    public static void SetDateTimeOffsetOrNull(this SqlDataRecord row, string columnName, DateTimeOffset? value) => row.SetDateTimeOffsetOrNull(row.GetOrdinal(columnName), value);
    public static void SetDateTimeOffsetOrNull(this SqlDataRecord row, int columnId, DateTimeOffset? value)
    {
        if (value is not null)
            row.SetDateTimeOffset(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetDateTimeOffsetOrDefault(this SqlDataRecord row, string columnName, DateTimeOffset? value, DateTimeOffset defaultValue = default) => row.SetDateTimeOffsetOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetDateTimeOffsetOrDefault(this SqlDataRecord row, int columnId, DateTimeOffset? value, DateTimeOffset defaultValue = default)
    {
        row.SetDateTimeOffset(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetDecimal(this SqlDataRecord row, string columnName, decimal value) => row.SetDecimal(row.GetOrdinal(columnName), value);

    public static void SetDecimalOrNull(this SqlDataRecord row, string columnName, decimal? value) => row.SetDecimalOrNull(row.GetOrdinal(columnName), value);
    public static void SetDecimalOrNull(this SqlDataRecord row, int columnId, decimal? value)
    {
        if (value is not null)
            row.SetDecimal(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetDecimalOrDefault(this SqlDataRecord row, string columnName, decimal? value, decimal defaultValue = default) => row.SetDecimalOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetDecimalOrDefault(this SqlDataRecord row, int columnId, decimal? value, decimal defaultValue = default)
    {
        row.SetDecimal(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetDouble(this SqlDataRecord row, string columnName, double value) => row.SetDouble(row.GetOrdinal(columnName), value);

    public static void SetDoubleOrNull(this SqlDataRecord row, string columnName, double? value) => row.SetDoubleOrNull(row.GetOrdinal(columnName), value);
    public static void SetDoubleOrNull(this SqlDataRecord row, int columnId, double? value)
    {
        if (value is not null)
            row.SetDouble(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetDoubleOrDefault(this SqlDataRecord row, string columnName, double? value, double defaultValue = default) => row.SetDoubleOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetDoubleOrDefault(this SqlDataRecord row, int columnId, double? value, double defaultValue = default)
    {
        row.SetDouble(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetFloat(this SqlDataRecord row, string columnName, float value) => row.SetFloat(row.GetOrdinal(columnName), value);

    public static void SetFloatOrNull(this SqlDataRecord row, string columnName, float? value) => row.SetFloatOrNull(row.GetOrdinal(columnName), value);
    public static void SetFloatOrNull(this SqlDataRecord row, int columnId, float? value)
    {
        if (value is not null)
            row.SetFloat(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetFloatOrDefault(this SqlDataRecord row, string columnName, float? value, float defaultValue = default) => row.SetFloatOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetFloatOrDefault(this SqlDataRecord row, int columnId, float? value, float defaultValue = default)
    {
        row.SetFloat(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetGuid(this SqlDataRecord row, string columnName, Guid value) => row.SetGuid(row.GetOrdinal(columnName), value);

    public static void SetGuidOrNull(this SqlDataRecord row, string columnName, Guid? value) => row.SetGuidOrNull(row.GetOrdinal(columnName), value);
    public static void SetGuidOrNull(this SqlDataRecord row, int columnId, Guid? value)
    {
        if (value is not null)
            row.SetGuid(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetGuidOrDefault(this SqlDataRecord row, string columnName, Guid? value, Guid defaultValue = default) => row.SetGuidOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetGuidOrDefault(this SqlDataRecord row, int columnId, Guid? value, Guid defaultValue = default)
    {
        row.SetGuid(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetInt16(this SqlDataRecord row, string columnName, short value) => row.SetInt16(row.GetOrdinal(columnName), value);

    public static void SetInt16OrNull(this SqlDataRecord row, string columnName, short? value) => row.SetInt16OrNull(row.GetOrdinal(columnName), value);
    public static void SetInt16OrNull(this SqlDataRecord row, int columnId, short? value)
    {
        if (value is not null)
            row.SetInt16(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetInt16OrDefault(this SqlDataRecord row, string columnName, short? value, short defaultValue = default) => row.SetInt16OrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetInt16OrDefault(this SqlDataRecord row, int columnId, short? value, short defaultValue = default)
    {
        row.SetInt16(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetInt32(this SqlDataRecord row, string columnName, int value) => row.SetInt32(row.GetOrdinal(columnName), value);

    public static void SetInt32OrNull(this SqlDataRecord row, string columnName, int? value) => row.SetInt32OrNull(row.GetOrdinal(columnName), value);
    public static void SetInt32OrNull(this SqlDataRecord row, int columnId, int? value)
    {
        if (value is not null)
            row.SetInt32(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetInt32OrDefault(this SqlDataRecord row, string columnName, int? value, int defaultValue = default) => row.SetInt32OrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetInt32OrDefault(this SqlDataRecord row, int columnId, int? value, int defaultValue = default)
    {
        row.SetInt32(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetInt64(this SqlDataRecord row, string columnName, long value) => row.SetInt64(row.GetOrdinal(columnName), value);

    public static void SetInt64OrNull(this SqlDataRecord row, string columnName, long? value) => row.SetInt64OrNull(row.GetOrdinal(columnName), value);
    public static void SetInt64OrNull(this SqlDataRecord row, int columnId, long? value)
    {
        if (value is not null)
            row.SetInt64(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetInt64OrDefault(this SqlDataRecord row, string columnName, long? value, long defaultValue = default) => row.SetInt64OrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetInt64OrDefault(this SqlDataRecord row, int columnId, long? value, long defaultValue = default)
    {
        row.SetInt64(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetTimeSpan(this SqlDataRecord row, string columnName, TimeSpan value) => row.SetTimeSpan(row.GetOrdinal(columnName), value);

    public static void SetTimeSpanOrNull(this SqlDataRecord row, string columnName, TimeSpan? value) => row.SetTimeSpanOrNull(row.GetOrdinal(columnName), value);
    public static void SetTimeSpanOrNull(this SqlDataRecord row, int columnId, TimeSpan? value)
    {
        if (value is not null)
            row.SetTimeSpan(columnId, value.GetValueOrDefault());
        else
            row.SetDBNull(columnId);
    }

    public static void SetTimeSpanOrDefault(this SqlDataRecord row, string columnName, TimeSpan? value, TimeSpan defaultValue = default) => row.SetTimeSpanOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetTimeSpanOrDefault(this SqlDataRecord row, int columnId, TimeSpan? value, TimeSpan defaultValue = default)
    {
        row.SetTimeSpan(columnId, value.GetValueOrDefault(defaultValue));
    }

    public static void SetString(this SqlDataRecord row, string columnName, string value) => row.SetString(row.GetOrdinal(columnName), value);

    public static void SetStringOrNull(this SqlDataRecord row, string columnName, string? value) => row.SetStringOrNull(row.GetOrdinal(columnName), value);
    public static void SetStringOrNull(this SqlDataRecord row, int columnId, string? value)
    {
        if (value is not null)
            row.SetString(columnId, value);
        else
            row.SetDBNull(columnId);
    }

    public static void SetStringOrDefault(this SqlDataRecord row, string columnName, string? value, string? defaultValue = default) => row.SetStringOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetStringOrDefault(this SqlDataRecord row, int columnId, string? value, string? defaultValue = default)
    {
        if (value is not null)
            row.SetString(columnId, value);
        else if (defaultValue is not null)
            row.SetString(columnId, defaultValue);
        else
            row.SetDBNull(columnId);
    }

    public static void SetStringOrEmpty(this SqlDataRecord row, string columnName, string? value) => row.SetStringOrEmpty(row.GetOrdinal(columnName), value);
    public static void SetStringOrEmpty(this SqlDataRecord row, int columnId, string? value)
    {
        row.SetString(columnId, value ?? "");
    }

    public static void SetBytes(this SqlDataRecord row, string columnName, long fieldOffset, byte[] value, int bufferOffset, int length) => row.SetBytes(row.GetOrdinal(columnName), fieldOffset, value, bufferOffset, length);

    public static void SetBytes(this SqlDataRecord row, int columnId, byte[] value) => row.SetBytes(columnId, 0, value, 0, value.Length);
    public static void SetBytes(this SqlDataRecord row, string columnName, byte[] value) => row.SetBytes(row.GetOrdinal(columnName), value);

    public static void SetBytesOrDefault(this SqlDataRecord row, string columnName, byte[]? value, byte[]? defaultValue = default) => row.SetBytesOrDefault(row.GetOrdinal(columnName), value, defaultValue);
    public static void SetBytesOrDefault(this SqlDataRecord row, int columnId, byte[]? value, byte[]? defaultValue = default)
    {
        if (value is not null)
            row.SetBytes(columnId, value);
        else if (defaultValue is not null)
            row.SetBytes(columnId, defaultValue);
        else
            row.SetDBNull(columnId);
    }

    public static void SetBytesOrNull(this SqlDataRecord row, string columnName, byte[]? value) => row.SetBytesOrNull(row.GetOrdinal(columnName), value);
    public static void SetBytesOrNull(this SqlDataRecord row, int columnId, byte[]? value)
    {
        if (value is not null)
            row.SetBytes(columnId, value);
        else
            row.SetDBNull(columnId);
    }

    public static void SetBytesOrEmpty(this SqlDataRecord row, string columnName, byte[]? value) => row.SetBytesOrEmpty(row.GetOrdinal(columnName), value);
    public static void SetBytesOrEmpty(this SqlDataRecord row, int columnId, byte[]? value)
    {
        row.SetBytes(columnId, value ?? []);
    }
}
