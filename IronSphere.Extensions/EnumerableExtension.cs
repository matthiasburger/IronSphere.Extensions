// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IronSphere.Extensions.Exceptions;
using IronSphere.Extensions.PredicateEnumerable;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtension
    {
        private class IndexedItem<TItem> : IIndexedItem<TItem>
        {
            public IndexedItem(TItem item, int index)
            {
                Item = item;
                Index = index;
            }

            public TItem Item { get; }

            public int Index { get; }
        }

        /// <summary>
        /// Determines whether an <see cref="IEnumerable{T}"/> is either null or doesn't contain any elements
        /// </summary>
        /// <param name="this">the actual IEnumerable</param>
        /// <typeparam name="T">the type of elements the IEnumerable contains</typeparam>
        /// <code>
        /// <![CDATA[public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)]]>
        /// </code>
        /// <example>
        /// <![CDATA[
        /// bool isNullOrEmpty = GetAListOfItemsFromSomewhere().IsNullOrEmpty();
        /// ]]>
        /// </example>
        /// <returns>
        /// A value indicating whether the actual enumerable is either null or empty.
        /// </returns>
        /// <remarks>
        /// If the enumerable is null the return value is true.
        /// If the enumerable contains no items, the return value is true.
        /// If the enumerable contains one or more items, the return value is false.
        /// </remarks>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? @this)
        {
            if (@this == null) return true;

            using IEnumerator<T> enumerator = @this.GetEnumerator();
            return !enumerator.MoveNext();
        }

        /// <summary>
        /// Determines if an enumeration contains exactly one element
        /// </summary>
        /// <typeparam name="T">The generic type of the enumerable</typeparam>
        /// <param name="this">The actual enumerable.</param>
        /// <code>
        /// <![CDATA[public static bool IsSingle<T>(this IEnumerable<T> @this)]]>
        /// </code>
        /// <example>
        /// <![CDATA[
        /// bool isSingleUser = Context.Users.Where(w => w.Name == "test").IsSingle();
        /// ]]>
        /// </example>
        /// <returns>A value indicating whether there's exactly one element in the actual enumerable.</returns>
        /// <remarks>
        /// If the enumerable is null the return value is false.
        /// If the enumerable contains no or more than one item, the return value is false.
        /// If there is exactly one item, the value of the item doesn't matter.
        /// </remarks>
        public static bool IsSingle<T>(this IEnumerable<T>? @this)
        {
            if (@this == null) return false;

            using IEnumerator<T> enumerator = @this.GetEnumerator();
            return enumerator.MoveNext() && !enumerator.MoveNext();
        }

        /// <summary>
        /// method checks whether the selected properties of the list are the same
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static bool AllValuesTheSameFor<T, TResult>(this IEnumerable<T>? @this, Func<T, TResult> selector)
        {
            if (@this == null) return false;

            HashSet<TResult> foundResults = new();

            using IEnumerator<T> enumerator = @this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                TResult currentValue = selector(enumerator.Current);
                if (foundResults.Contains(currentValue))
                    continue;

                if (foundResults.Count != 0)
                    return false;

                foundResults.Add(currentValue);
            }

            return foundResults.Count == 1;
        }

        /// <summary>
        /// method checks whether the selected properties of the list are all the same
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        [Obsolete("Misleading name, use AllValuesTheSameFor<T, TResult> instead")]
        public static bool IsSingle<T, TResult>(this IEnumerable<T>? @this, Func<T, TResult> selector)
        {
            if (@this == null) return false;

            HashSet<TResult> foundResults = new();

            using IEnumerator<T> enumerator = @this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                TResult currentValue = selector(enumerator.Current);
                if (foundResults.Contains(currentValue))
                    continue;

                if (foundResults.Count != 0)
                    return false;

                foundResults.Add(currentValue);
            }

            return foundResults.Count == 1;
        }

        /// <summary>
        /// Determines if an enumeration contains exactly one element
        /// </summary>
        /// <typeparam name="T">
        /// The generic type of the enumerable
        /// </typeparam>
        /// <param name="this">
        /// The actual enumerable.
        /// </param>
        /// <param name="predicate">
        /// The predicate to filter for and check if the filtered would be single.
        /// </param>
        /// <code>
        /// <![CDATA[public static bool IsSingle<T>(this IEnumerable<T> @this, Func<T, bool> predicate)]]>
        /// </code>
        /// <example>
        /// <![CDATA[
        /// bool isSingleUser = Context.Users.IsSingle(w => w.Name == "test");
        /// ]]>
        /// </example>
        /// <returns>
        /// A value indicating whether there's exactly one element in the actual enumerable.
        /// </returns>
        /// <remarks>
        /// If the enumerable is null the return value is false.
        /// If the enumerable contains no or more than one item, the return value is false.
        /// If there is exactly one item, the value of the item doesn't matter.
        /// </remarks>
        public static bool IsSingle<T>(this IEnumerable<T>? @this, Func<T, bool> predicate)
        {
            return @this != null && @this.Count(predicate) == 1;
        }

        /// <summary>
        /// Randomizes the items of a list
        /// </summary>
        /// <typeparam name="T">Thy generic list-type.</typeparam>
        /// <param name="this">The actual list to randomize.</param>
        /// <returns>A new list-instance with all items of the list but in a random order.</returns>
        [Obsolete("Use function Shuffle<T> instead")]
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> @this)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            List<T> actualList = @this.ToList();
            T[] instance = new T[actualList.Count];
            List<int> positions = Enumerable.Range(0, actualList.Count).ToList();

            foreach (T item in actualList)
            {
                int position;
                while (!(position = Random.NextInt(0, actualList.Count)).In(positions))
                {
                }

                positions.Remove(position);
                instance[position] = item;
            }

            return instance;
        }
        
        /// <summary>
        /// Randomizes the items of a list
        /// </summary>
        /// <typeparam name="T">Thy generic list-type.</typeparam>
        /// <param name="this">The actual list to randomize.</param>
        /// <returns>A new list-instance with all items of the list but in a random order.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> @this)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            List<T> actualList = @this.ToList();
            T[] instance = new T[actualList.Count];
            List<int> positions = Enumerable.Range(0, actualList.Count).ToList();

            foreach (T item in actualList)
            {
                int position;
                while (!(position = Random.NextInt(0, actualList.Count)).In(positions))
                {
                }

                positions.Remove(position);
                instance[position] = item;
            }

            return instance;
        }

        /// <summary>
        /// Iterates through a list of items and yields all elements but not duplicated.
        /// </summary>
        /// <typeparam name="T">The generic list-type.</typeparam>
        /// <typeparam name="TType">The targets generic list type.</typeparam>
        /// <param name="this">The actual list,</param>
        /// <param name="expression">The expression to distinct all items.</param>
        /// <returns>A new list of items as distinct by the expression.</returns>
        public static IEnumerable<T> Distinct<T, TType>(this IEnumerable<T> @this, Func<T, TType> expression)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            HashSet<TType> seenKeys = new();
            foreach (T element in @this)
                if (seenKeys.Add(expression(element)))
                    yield return element;
        }

        /// <summary>
        /// ITD with v4
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T GetSingleItem<T>(this IEnumerable<T> @this, Expression<Func<T, bool>> filter) where T : class
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            string ErrorMessage(string s) => $"{s} ({filter.GetReadableExpressionBody()})".TrimEnd();

            return _getSingleItemOrNull(@this, filter.Compile(), ErrorMessage)
                   ?? throw new MissingItemException(ErrorMessage("No item in sequence was found."));
        }

        /// <summary>
        /// ITD with v4
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Obsolete("Use GetSingleItemOrDefault<T> - it does the same, but a list of int doesn't return null as default")]
        public static T? GetSingleItemOrNull<T>(this IEnumerable<T> @this, Expression<Func<T, bool>> filter)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            string ErrorMessage(string s) => $"{s} ({filter.GetReadableExpressionBody()})".TrimEnd();

            return _getSingleItemOrNull(@this, filter.Compile(), ErrorMessage);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static T? GetSingleItemOrDefault<T>(this IEnumerable<T> @this, Expression<Func<T, bool>> filter)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            string ErrorMessage(string s) => $"{s} ({filter.GetReadableExpressionBody()})".TrimEnd();

            return _getSingleItemOrNull(@this, filter.Compile(), ErrorMessage);
        }

        private static T? _getSingleItemOrNull<T>(IEnumerable<T> @this, Func<T, bool> filter,
            Func<string, string> errorMessage)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            using IEnumerator<T> enumerator = @this.GetEnumerator();
            int count = 0;
            T? item = default;

            while (enumerator.MoveNext())
            {
                if (!filter(enumerator.Current))
                    continue;

                item = enumerator.Current;

                if (++count > 1)
                    throw new EquivocalItemException(errorMessage("Items in sequence are equivocal."));
            }

            return item;
        }

        internal static IEnumerable<T> AddSingleItem<T>(this IEnumerable<T> @this, T element)
        {
            foreach (T item in @this)
                yield return item;
            yield return element;
        }

        internal static IEnumerable<T> RemoveSingleItem<T>(this IEnumerable<T> @this, T element)
        {
            return @this.Where(item =>
                !ReferenceEquals(item, element) && !EqualityComparer<T>.Default.Equals(item, element));
        }

        /// <summary>
        /// ITD with v4
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IPredicateEnumerable<T> AddItem<T>(this IEnumerable<T> @this, T element)
            => new AddEnumerable<T>(@this, element);

        /// <summary>
        /// ITD with v4
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IPredicateEnumerable<T> RemoveItem<T>(this IEnumerable<T> @this, T element)
            => new RemoveOneItemEnumerable<T>(@this, element);

        /// <summary>
        /// splits a sequence into multiple sequences, where none of the sequences has more than <see cref="count"/> elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> @this, int count)
        {
            if (@this is null)
                throw new ArgumentNullException();
            
            List<T> currentCollection = new(count);
            int index = 0;

            foreach (T currentItem in @this)
            {
                currentCollection.Add(currentItem);

                if (++index != count)
                    continue;

                yield return currentCollection;

                index = 0;
                currentCollection = new List<T>();
            }

            if (currentCollection.Any())
                yield return currentCollection;
        }

        public static TRes? MaxIfAny<T, TRes>(this IEnumerable<T> source, Func<T, TRes> selector, TRes? fallback = null)
            where TRes : struct, IComparable<TRes>
        {
            if (source is null)
                throw new ArgumentNullException();
            
            TRes? result = null;

            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == null) continue;

                    TRes value = selector(enumerator.Current);
                    if (result is null)
                        result = value;
                    else if (value.CompareTo(result.Value) > 0)
                        result = value;
                }
            }

            return result ?? fallback;
        }

        public static TRes? MinIfAny<T, TRes>(this IEnumerable<T> source, Func<T, TRes> selector, TRes? fallback = null)
            where TRes : struct, IComparable<TRes>
        {
            if (source is null)
                throw new ArgumentNullException();
            
            TRes? result = null;

            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == null) continue;

                    TRes value = selector(enumerator.Current);
                    if (result is null)
                        result = value;
                    else if (value.CompareTo(result.Value) < 0)
                        result = value;
                }
            }

            return result ?? fallback;
        }

        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> @this, Func<T, TResult> action, bool toList = true)
        {
            IEnumerable<TResult> selected = @this.Select(action);
            if (toList)
                selected = selected.ToList();
            return selected;
        }

        public static IEnumerable<TResult> TryForEach<T, TResult>(this IEnumerable<T> @this, Func<T, TResult> action)
        {
            IList<TResult> newSequence = new List<TResult>();

            foreach (T item in @this)
            {
                TResult result;
                try
                {
                    result = action(item);
                }
                catch (Exception)
                {
                    continue;
                }

                newSequence.Add(result);
            }

            return newSequence;
        }

        public static IEnumerable<IIndexedItem<TModel>> SelectWithIndex<TModel>(this IEnumerable<TModel> collection)
        {
            return collection.Select((item, x) => new IndexedItem<TModel>(item, x));
        }

        public static bool Loops<T>(this IEnumerable<T> @this, Func<T, T> next) where T:struct
        {
            using IEnumerator<T> enumerator = @this.GetEnumerator();

            enumerator.MoveNext();
            T current = enumerator.Current;

            bool hasNext = false;
            
            while (enumerator.MoveNext())
            {
                hasNext = true;

                T shouldBe = next(current);
                if (shouldBe.Equals(enumerator.Current))
                {
                    current = enumerator.Current;
                    continue;
                }

                return false;
            }

            return hasNext;
        }
    }

    public interface IIndexedItem<out TItem>
    {
        TItem Item { get; }
        int Index { get; }
    }
}