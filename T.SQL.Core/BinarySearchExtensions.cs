namespace T.SQL.Core;

public static class BinarySearchExtensions
{
    public static T[] BinarySearchArray<T>(this IReadOnlyList<T> list, T item, IComparer<T> comparer = null) =>
    BinarySearchArray(list, 0, list.Count, item, comparer);

    public static T[] BinarySearchArray<T>(this IReadOnlyList<T> list, int index, int count, T item, IComparer<T> comparer = null)
    {
        var (first, last) = BinarySearchRange(list, index, count, item, comparer);
        var cnt = last - first;
        if (cnt <= 0)
            return [];

        var arr = new T[cnt];
        for (int i = 0, j = first; i < cnt; i++, j++)
        {
            arr[i] = list[j];
        }
        return arr;
    }

    public static IEnumerable<T> BinarySearchEnumerable<T>(this IReadOnlyList<T> list, T item, IComparer<T> comparer = null) =>
        BinarySearchEnumerable(list, 0, list.Count, item, comparer);

    public static IEnumerable<T> BinarySearchEnumerable<T>(this IReadOnlyList<T> list, int index, int count, T item, IComparer<T> comparer = null)
    {
        var (first, last) = BinarySearchRange(list, index, count, item, comparer);
        for (int i = first; i < last; i++)
            yield return list[i];
    }

    public static (int first, int last) BinarySearchRange<T>(this IReadOnlyList<T> list, T item, IComparer<T> comparer = null) =>
        BinarySearchRange(list, 0, list.Count, item, comparer);

    public static (int first, int last) BinarySearchRange<T>(this IReadOnlyList<T> list, int index, int count, T item, IComparer<T> comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        var first = InternalBinarySearchFirst(list, index, count, item, comparer);
        var last = InternalBinarySearchLast(list, index, count, item, comparer);
        return (~first, ~last);
    }

    public static Span<T> BinarySearchSpan<T>(this T[] list, T item, IComparer<T> comparer = null) =>
        BinarySearchSpan(list, 0, list.Length, item, comparer);

    public static Span<T> BinarySearchSpan<T>(this T[] list, int index, int count, T item, IComparer<T> comparer = null)
    {
        var (first, last) = BinarySearchRange(list, index, count, item, comparer);
        return new(list, first, last - first);
    }

    public static IEnumerable<T> BinarySearchEnumerable<T>(this T[] list, T item, IComparer<T> comparer = null) =>
        BinarySearchEnumerable(list, 0, list.Length, item, comparer);

    public static IEnumerable<T> BinarySearchEnumerable<T>(this T[] list, int index, int count, T item, IComparer<T> comparer = null)
    {
        var (first, last) = BinarySearchRange(list, index, count, item, comparer);
        for (int i = first; i < last; i++)
            yield return list[i];
    }

    public static (int first, int last) BinarySearchRange<T>(this T[] list, T item, IComparer<T> comparer = null) =>
        BinarySearchRange(list, 0, list.Length, item, comparer);

    public static (int first, int last) BinarySearchRange<T>(this T[] list, int index, int count, T item, IComparer<T> comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        var first = InternalBinarySearchFirst(list, index, count, item, comparer);
        var last = InternalBinarySearchLast(list, index, count, item, comparer);
        return (~first, ~last);
    }

    public static Span<T> BinarySearchSpan<T>(this Span<T> list, T item, IComparer<T> comparer = null) =>
        BinarySearchSpan(list, 0, list.Length, item, comparer);

    public static Span<T> BinarySearchSpan<T>(this Span<T> list, int index, int count, T item, IComparer<T> comparer = null)
    {
        var (first, last) = BinarySearchRange(list, index, count, item, comparer);
        return list.Slice(first, last - first);
    }

    public static (int first, int last) BinarySearchRange<T>(this Span<T> list, T item, IComparer<T> comparer = null) =>
        BinarySearchRange(list, 0, list.Length, item, comparer);

    public static (int first, int last) BinarySearchRange<T>(this Span<T> list, int index, int count, T item, IComparer<T> comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        var first = InternalBinarySearchFirst(list, index, count, item, comparer);
        var last = InternalBinarySearchLast(list, index, count, item, comparer);
        return (~first, ~last);
    }

    internal static int InternalBinarySearchFirst<T>(Span<T> array, int index, int length, T value, IComparer<T> comparer)
    {
        var num = index;
        var num2 = index + length - 1;
        while (num <= num2)
        {
            var num3 = num + (num2 - num >> 1);
            var num4 = comparer.Compare(array[num3], value);
            //if (num4 == 0)
            //{
            //    return num3;//do not early return seek towards edge, treat 0 as +1
            //}

            if (num4 < 0)
            {
                num = num3 + 1;//branch -1
            }
            else
            {
                num2 = num3 - 1;//branch +1
            }
        }

        return ~num;
    }

    internal static int InternalBinarySearchLast<T>(Span<T> array, int index, int length, T value, IComparer<T> comparer)
    {
        var num = index;
        var num2 = index + length - 1;
        while (num <= num2)
        {
            var num3 = num + (num2 - num >> 1);
            var num4 = comparer.Compare(array[num3], value);
            //if (num4 == 0)
            //{
            //    return num3;//do not early return seek towards edge, treat 0 as -1
            //}

            if (num4 <= 0)
            {
                num = num3 + 1;//branch -1
            }
            else
            {
                num2 = num3 - 1;//branch +1
            }
        }

        return ~num;
    }

    internal static int InternalBinarySearchFirst<L, T>(L array, int index, int length, T value, IComparer<T> comparer) where L : IReadOnlyList<T>
    {
        var num = index;
        var num2 = index + length - 1;
        while (num <= num2)
        {
            var num3 = num + (num2 - num >> 1);
            var num4 = comparer.Compare(array[num3], value);
            //if (num4 == 0)
            //{
            //    return num3;//do not early return seek towards edge, treat 0 as +1
            //}

            if (num4 < 0)
            {
                num = num3 + 1;//branch -1
            }
            else
            {
                num2 = num3 - 1;//branch +1
            }
        }

        return ~num;
    }

    internal static int InternalBinarySearchLast<L, T>(L array, int index, int length, T value, IComparer<T> comparer) where L : IReadOnlyList<T>
    {
        var num = index;
        var num2 = index + length - 1;
        while (num <= num2)
        {
            var num3 = num + (num2 - num >> 1);
            var num4 = comparer.Compare(array[num3], value);
            //if (num4 == 0)
            //{
            //    return num3;//do not early return seek towards edge, treat 0 as -1
            //}

            if (num4 <= 0)
            {
                num = num3 + 1;//branch -1
            }
            else
            {
                num2 = num3 - 1;//branch +1
            }
        }

        return ~num;
    }
}
