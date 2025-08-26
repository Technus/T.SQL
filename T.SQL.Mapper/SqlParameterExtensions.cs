using Microsoft.Data.SqlClient;

namespace T.SQL.Mapper;

public static class SqlParameterExtensions
{
    public static bool IsDBNull(this SqlParameter parameter) => parameter.Value is null || Convert.IsDBNull(parameter.Value);

    public static TimeSpan GetTimeSpan(this SqlParameter parameter) => (TimeSpan)parameter.Value;

    public static TimeSpan GetTimeSpanOrDefault(this SqlParameter parameter, TimeSpan defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetTimeSpan();

    public static TimeSpan? GetTimeSpanOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetTimeSpan();

    public static DateTime GetDateTime(this SqlParameter parameter) => (DateTime)parameter.Value;

    public static DateTime GetDateTimeOrDefault(this SqlParameter parameter, DateTime defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetDateTime();

    public static DateTime? GetDateTimeOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetDateTime();

    public static bool GetBoolean(this SqlParameter parameter) => (bool)parameter.Value;

    public static bool GetBooleanOrDefault(this SqlParameter parameter, bool defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetBoolean();

    public static bool? GetBooleanOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetBoolean();

    public static byte GetByte(this SqlParameter parameter) => (byte)parameter.Value;

    public static byte GetByteOrDefault(this SqlParameter parameter, byte defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetByte();

    public static byte? GetByteOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetByte();

    public static short GetInt16(this SqlParameter parameter) => (short)parameter.Value;

    public static short GetInt16OrDefault(this SqlParameter parameter, short defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetInt16();

    public static short? GetInt16OrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetInt16();

    public static int GetInt32(this SqlParameter parameter) => (int)parameter.Value;

    public static int GetInt32OrDefault(this SqlParameter parameter, int defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetInt32();

    public static int? GetInt32OrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetInt32();

    public static long GetInt64(this SqlParameter parameter) => (long)parameter.Value;

    public static long GetInt64OrDefault(this SqlParameter parameter, long defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetInt64();

    public static long? GetInt64OrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetInt64();

    public static float GetFloat(this SqlParameter parameter) => (float)parameter.Value;

    public static float GetFloatOrDefault(this SqlParameter parameter, float defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetFloat();

    public static float? GetFloatOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetFloat();

    public static double GetDouble(this SqlParameter parameter) => (double)parameter.Value;

    public static double GetDoubleOrDefault(this SqlParameter parameter, double defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetDouble();

    public static double? GetDoubleOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetDouble();

    public static decimal GetDecimal(this SqlParameter parameter) => (decimal)parameter.Value;

    public static decimal GetDecimalOrDefault(this SqlParameter parameter, decimal defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetDecimal();

    public static decimal? GetDecimalOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetDecimal();

    public static char GetChar(this SqlParameter parameter) => (char)parameter.Value;

    public static char GetCharOrDefault(this SqlParameter parameter, char defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetChar();

    public static char? GetCharOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetChar();

    public static string GetString(this SqlParameter parameter) => (string)parameter.Value;

#if NET6_0_OR_GREATER
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
#endif
    public static string? GetStringOrDefault(this SqlParameter parameter, string? defaultValue = default) => parameter.IsDBNull() ? defaultValue : parameter.GetString();

    public static string? GetStringOrNull(this SqlParameter parameter) => parameter.IsDBNull() ? null : parameter.GetString();

    public static string GetStringOrEmpty(this SqlParameter parameter) => parameter.IsDBNull() ? "" : parameter.GetString();
}