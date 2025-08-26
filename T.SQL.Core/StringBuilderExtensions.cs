using System.Text;

namespace T.SQL.Core;

public static class StringBuilderExtensions
{
    public static StringBuilder Backspace(this StringBuilder stringBuilder)
    {
        if (stringBuilder.Length != 0)
            stringBuilder.Length--;
        return stringBuilder;
    }

    public static StringBuilder AppendLineIfNotEmpty(this StringBuilder stringBuilder)
    {
        if (stringBuilder.Length != 0)
            stringBuilder.AppendLine();
        return stringBuilder;
    }

    public static StringBuilder AppendRowsAndLine(this StringBuilder stringBuilder, IEnumerable<string> join) =>
        stringBuilder.AppendRows(join).AppendLine();

    public static StringBuilder AppendRowsAndLine<T>(this StringBuilder stringBuilder, IEnumerable<T> join, Action<StringBuilder, T> appender) =>
        stringBuilder.AppendRows(join, appender).AppendLine();

    public static StringBuilder AppendJoinAndLine(this StringBuilder stringBuilder, string separator, IEnumerable<string> join) =>
        stringBuilder.AppendJoin(separator, join).AppendLine();

    public static StringBuilder AppendJoinAndLine<T>(this StringBuilder stringBuilder, string separator, IEnumerable<T> join, Action<StringBuilder, T> appender) =>
        stringBuilder.AppendJoin(separator, join, appender).AppendLine();

    /// <summary>
    /// Same as <see cref="AppendJoin(StringBuilder, string, IEnumerable{string})"/> with <see cref="Environment.NewLine"/> as separator
    /// </summary>
    /// <param name="stringBuilder"></param>
    /// <param name="join"></param>
    /// <returns></returns>
    public static StringBuilder AppendRows(this StringBuilder stringBuilder, IEnumerable<string> join) =>
        AppendJoin(stringBuilder, Environment.NewLine, join);

    /// <summary>
    /// Same as <see cref="AppendJoin{T}(StringBuilder, string, IEnumerable{T}, Action{StringBuilder, T})"/> with <see cref="Environment.NewLine"/> as separator
    /// </summary>
    /// <param name="stringBuilder"></param>
    /// <param name="join"></param>
    /// <returns></returns>
    public static StringBuilder AppendRows<T>(this StringBuilder stringBuilder, IEnumerable<T> join, Action<StringBuilder, T> appender) =>
        AppendJoin(stringBuilder, Environment.NewLine, join, appender);

    /// <summary>
    /// Faster version of appending string join result.
    /// Instead of string joining with separate internal string builder, joins into target one.
    /// </summary>
    /// <param name="stringBuilder"></param>
    /// <param name="separator"></param>
    /// <param name="join"></param>
    /// <returns></returns>
    public static StringBuilder AppendJoin(this StringBuilder stringBuilder, string separator, IEnumerable<string> join)
    {
        using var enumerator = join.GetEnumerator();

        if (!enumerator.MoveNext())
            return stringBuilder;

        if (enumerator.Current is not null)
            stringBuilder.Append(enumerator.Current);

        while (enumerator.MoveNext())
        {
            stringBuilder.Append(separator);
            if (enumerator.Current is not null)
                stringBuilder.Append(enumerator.Current);
        }
        return stringBuilder;
    }

    /// <summary>
    /// same as <see cref="AppendJoin(StringBuilder, string, IEnumerable{string})"/> But allows to provide custom item appender
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stringBuilder"></param>
    /// <param name="separator"></param>
    /// <param name="join"></param>
    /// <param name="appender"></param>
    /// <returns></returns>
    public static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, string separator, IEnumerable<T> join, Action<StringBuilder, T> appender)
    {
        using var enumerator = join.GetEnumerator();

        if (!enumerator.MoveNext())
            return stringBuilder;

        if (enumerator.Current is not null)
            appender(stringBuilder, enumerator.Current);

        while (enumerator.MoveNext())
        {
            stringBuilder.Append(separator);
            if (enumerator.Current is not null)
                appender(stringBuilder, enumerator.Current);
        }

        return stringBuilder;
    }

    /// <summary>
    /// Trims whitespace from end
    /// </summary>
    /// <param name="sb"></param>
    /// <returns></returns>
    public static StringBuilder TrimEnd(this StringBuilder sb)
    {
        if (sb == null || sb.Length == 0) return sb;

        int i = sb.Length - 1;

        for (; i >= 0; i--)
            if (!char.IsWhiteSpace(sb[i]))
                break;

        if (i < sb.Length - 1)
            sb.Length = i + 1;

        return sb;
    }

    /// <summary>
    /// Trims <see langword="char"/>s from end matching any <see langword="char"/>s from <paramref name="charsString"/>
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="charsString"></param>
    /// <returns></returns>
    public static StringBuilder TrimEnd(this StringBuilder sb, string charsString)
    {
        if (sb == null || sb.Length == 0) return sb;

        int i = sb.Length - 1;

        for (; i >= 0; i--)
            if (!charsString.Contains(sb[i]))
                break;

        if (i < sb.Length - 1)
            sb.Length = i + 1;

        return sb;
    }

    /// <summary>
    /// Trims <see langword="char"/>s from end matching <paramref name="c"/>
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static StringBuilder TrimEnd(this StringBuilder sb, char c)
    {
        if (sb == null || sb.Length == 0) return sb;

        int i = sb.Length - 1;

        for (; i >= 0; i--)
            if (sb[i] != c)
                break;

        if (i < sb.Length - 1)
            sb.Length = i + 1;

        return sb;
    }
}