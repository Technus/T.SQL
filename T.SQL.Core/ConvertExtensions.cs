namespace T.SQL.Core;

public static class ConvertExtensions
{
    public static DateTime ToDateTime(this object value) => Convert.ToDateTime(value);

    public static bool ToBoolean(this object value) => Convert.ToBoolean(value);

    public static sbyte ToSByte(this object value) => Convert.ToSByte(value);

    public static byte ToByte(this object value) => Convert.ToByte(value);

    public static short ToInt16(this object value) => Convert.ToInt16(value);

    public static ushort ToUInt16(this object value) => Convert.ToUInt16(value);

    public static int ToInt32(this object value) => Convert.ToInt32(value);

    public static uint ToUInt32(this object value) => Convert.ToUInt32(value);

    public static long ToInt64(this object value) => Convert.ToInt64(value);

    public static ulong ToUInt64(this object value) => Convert.ToUInt64(value);

    public static float ToSingle(this object value) => Convert.ToSingle(value);

    public static double ToDouble(this object value) => Convert.ToDouble(value);

    public static decimal ToDecimal(this object value) => Convert.ToDecimal(value);

    public static char ToChar(this object value) => Convert.ToChar(value);
}