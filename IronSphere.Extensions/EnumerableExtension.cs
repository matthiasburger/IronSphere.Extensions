// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtension
    {
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
        public static bool IsNullOrEmpty<T>([CanBeNull]this IEnumerable<T> @this)
        {
            if (@this == null) return true;
            using (IEnumerator<T> enumerator = @this.GetEnumerator())
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
        public static bool IsSingle<T>([CanBeNull]this IEnumerable<T> @this)
        {
            if (@this == null) return false;

            using (IEnumerator<T> enumerator = @this.GetEnumerator())
                return enumerator.MoveNext() && !enumerator.MoveNext();
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
        public static bool IsSingle<T>([CanBeNull]this IEnumerable<T> @this, Func<T, bool> predicate)
        {
            return @this != null && @this.Count(predicate) == 1;
        }

        /// <summary>
        /// Randomizes the items of a list
        /// </summary>
        /// <typeparam name="T">Thy generic list-type.</typeparam>
        /// <param name="this">The actual list to randomize.</param>
        /// <returns>A new list-instance with all items of the list but in a random order.</returns>
        public static IEnumerable<T> Randomize<T>([NotNull]this IEnumerable<T> @this)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            List<T> actualList = @this.ToList();
            T[] instance = new T[actualList.Count];
            List<int> positions = Enumerable.Range(0, actualList.Count).ToList();

            foreach (T item in actualList)
            {
                int position;
                while (!(position = Random.NextInt(0, actualList.Count)).In(positions)) { }

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
        public static IEnumerable<T> Distinct<T, TType>([NotNull]this IEnumerable<T> @this, Func<T, TType> expression)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            HashSet<TType> seenKeys = new HashSet<TType>();
            foreach (T element in @this)
                if (seenKeys.Add(expression(element)))
                    yield return element;
        }
    }
}
