using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions;

/// <summary>
/// This class provides extension methods for <see cref="IEnumerable{T}"/>
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    /// Pendent to Linq IEnumerable{TSource}.Take(int) but returns all when count is null
    /// </summary>
    /// <typeparam name="TSource">the enumerable element-type</typeparam>
    /// <param name="source">the actual enumerable source</param>
    /// <param name="count">the number of elements to take (or null if take all)</param>
    /// <returns>A specified number of contiguous elements elements from the start of a sequence.</returns>
    public static IEnumerable<TSource> LexTake<TSource>(this IEnumerable<TSource> source, int? count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return !count.HasValue ? source.Skip(0) : source.Take(count.Value);
    }

    public static IEnumerable<TSource> LexSkipLast<TSource>(this IEnumerable<TSource> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        TSource[] buffer = new TSource[count];

        using IEnumerator<TSource> e = source.GetEnumerator();
        for (int i = 0; i < buffer.Length; i++)
        {
            if (!e.MoveNext())
                yield break;

            buffer[i] = e.Current;
        }

        int index = 0;
        while (e.MoveNext())
        {
            yield return buffer[index];
            buffer[index] = e.Current;
            index = (index + 1) % count;
        }
    }

    public static IEnumerable<TSource> LexTakeLast<TSource>(this IEnumerable<TSource> source, int count)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
            
        TSource[] buffer = new TSource[count];

        using (IEnumerator<TSource> e = source.GetEnumerator())
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                if (!e.MoveNext())
                    yield break;

                buffer[i] = e.Current;
            }

            int index = 0;
            while (e.MoveNext())
            {
                buffer[index] = e.Current;
                index = (index + 1) % count;
            }
        }
		
        foreach(TSource element in buffer)
            yield return element;
    }

    /// <summary>
    /// Pendent to Linq IEnumerable{TSource}.Skip(int) but skips all when count is null
    /// </summary>
    /// <typeparam name="TSource">the enumerable element-type</typeparam>
    /// <param name="source">the actual enumerable source</param>
    /// <param name="count">the number of elements to skip (or null if skip all)</param>
    /// <returns>A specified number of contiguous elements elements from the start of a sequence.</returns>
    public static IEnumerable<TSource> LexSkip<TSource>(this IEnumerable<TSource> source, int? count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return !count.HasValue ? source.Take(0) : source.Skip(count.Value);
    }

    /// <summary>
    /// Performs a left join over two enumerable sequences
    /// </summary>
    /// <typeparam name="TSource">the source sequences element-type</typeparam>
    /// <typeparam name="TJoin">the sequences element type to join</typeparam>
    /// <typeparam name="TKey">the type of values that get compared on join</typeparam>
    /// <param name="source">the source sequence</param>
    /// <param name="inner">the sequence to join</param>
    /// <param name="outerKeySelector">the sources key-property</param>
    /// <param name="innerKeySelector">the joined tables key-property</param>
    /// <returns>An IJoinSet after the left join.</returns>
    [Obsolete("This function may be removed in future - tests failed")]
    public static IEnumerable<IJoinSet<TSource, TJoin>> LexLeftJoin<TSource, TJoin, TKey>(
        this IEnumerable<TSource> source,
        IEnumerable<TJoin> inner,
        Func<TSource, TKey> outerKeySelector,
        Func<TJoin, TKey> innerKeySelector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (inner == null)
            throw new ArgumentNullException(nameof(inner));
        if (outerKeySelector == null)
            throw new ArgumentNullException(nameof(outerKeySelector));
        if (innerKeySelector == null)
            throw new ArgumentNullException(nameof(innerKeySelector));

        return source
            .GroupJoin(inner, outerKeySelector, innerKeySelector, (main, sub) => new { Main = main, Sub = sub })
            .SelectMany(left => left.Sub.DefaultIfEmpty(), (s, _) => new JoinSet<TSource, TJoin> { Main = s.Main, Sub = s.Sub });
    }

    /// <summary>
    /// Performs a right join over two enumerable sequences
    /// </summary>
    /// <typeparam name="TSource">the source sequences element-type</typeparam>
    /// <typeparam name="TJoin">the sequences element type to join</typeparam>
    /// <typeparam name="TKey">the type of values that get compared on join</typeparam>
    /// <param name="source">the source sequence</param>
    /// <param name="inner">the sequence to join</param>
    /// <param name="outerKeySelector">the sources key-property</param>
    /// <param name="innerKeySelector">the joined tables key-property</param>
    /// <returns>An IJoinSet after the right join.</returns>
    [Obsolete("This function may be removed in future - tests failed")]
    public static IEnumerable<IJoinSet<TJoin, TSource>> LexRightJoin<TSource, TJoin, TKey>(
        this IEnumerable<TSource> source,
        IEnumerable<TJoin> inner,
        Func<TSource, TKey> outerKeySelector,
        Func<TJoin, TKey> innerKeySelector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (inner == null)
            throw new ArgumentNullException(nameof(inner));
        if (outerKeySelector == null)
            throw new ArgumentNullException(nameof(outerKeySelector));
        if (innerKeySelector == null)
            throw new ArgumentNullException(nameof(innerKeySelector));

        return inner
            .GroupJoin(source, innerKeySelector, outerKeySelector, (main, sub) => new { Main = main, Sub = sub })
            .SelectMany(left => left.Sub.DefaultIfEmpty(), (s, _) => new JoinSet<TJoin, TSource> { Main = s.Main, Sub = s.Sub });
    }
    /// <summary>
    /// Returns distinct elements from a sequence by using a selected property to compare values.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of property to remove duplicated elements.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="groupingSelector">The property on which duplicated elements shall be removed.</param>
    /// <returns>An IEnumerable{TSource} that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> LexDistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> groupingSelector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (groupingSelector == null)
            throw new ArgumentNullException(nameof(groupingSelector));
        return source
            .GroupBy(groupingSelector)
            .Select(x => x.FirstOrDefault());
    }

    /// <inheritdoc />
    /// <summary>
    /// A private implementation of IJoinSet used for left/right joins
    /// </summary>
    /// <typeparam name="TMain"></typeparam>
    /// <typeparam name="TSub"></typeparam>
    private class JoinSet<TMain, TSub> : IJoinSet<TMain, TSub>
    {
        public TMain Main { get; set; } = default!;
        public IEnumerable<TSub> Sub { get; set; } = new List<TSub>();
    }
}