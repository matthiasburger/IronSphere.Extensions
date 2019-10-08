using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="ICollection{T}"/>
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// adds all elements in a parametrized list into an existing collection
        /// </summary>
        /// <typeparam name="T">underlying type of collection</typeparam>
        /// <param name="this">the actual collection to add elements to</param>
        /// <param name="elementsToAdd">the elements to add</param>
        /// <returns>the updated collection</returns>
        public static ICollection<T> Add<T>(this ICollection<T> @this, IEnumerable<T> elementsToAdd)
        {
            foreach (T element in elementsToAdd)
                @this.Add(element);

            return @this;
        }

        /// <summary>
        /// adds all elements in a parametrized list into an existing collection
        /// if the collection already contains an element it skips it
        /// </summary>
        /// <typeparam name="T">underlying type of collection</typeparam>
        /// <param name="this">the actual collection to add elements to</param>
        /// <param name="elementsToAdd">the elements to add</param>
        /// <returns>the updated collection</returns>
        public static ICollection<T> AddMissing<T>(this ICollection<T> @this, IEnumerable<T> elementsToAdd)
        {
            foreach (T element in elementsToAdd.Where(w => !@this.Contains(w)))
                @this.Add(element);

            return @this;
        }

        /// <summary>
        /// adds all elements in a parametrized list into an existing collection
        /// if the collection already contains an element it skips it
        /// </summary>
        /// <typeparam name="T">underlying type of collection</typeparam>
        /// <typeparam name="TSelectorType"></typeparam>
        /// <param name="this">the actual collection to add elements to</param>
        /// <param name="elementsToAdd">the elements to add</param>
        /// <param name="selector">elements that should be skipped if duplicated</param>
        /// <returns>the updated collection</returns>
        public static ICollection<T> AddMissing<T, TSelectorType>
            (this ICollection<T> @this, IEnumerable<T> elementsToAdd, Func<T, TSelectorType> selector)
        {
            foreach (T element in elementsToAdd)
            {
                if (@this.Select(selector).Contains(selector(element)))
                    continue;

                @this.Add(element);
            }

            return @this;
        }
    }
}
