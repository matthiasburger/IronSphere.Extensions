using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="IList{T}"/>
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Removes a single element in a list where a condition matches
        /// </summary>
        /// <typeparam name="T">The type of the elements of the source sequence.</typeparam>
        /// <param name="this">The source sequence.</param>
        /// <param name="expression">The expression to search for.</param>
        /// <exception cref="InvalidOperationException">if the sequence contains more than one element where the expression matches.</exception>
        public static void RemoveSingle<T>([NotNull]this IList<T> @this, [NotNull]Func<T, bool> expression)
            where T : class
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            T elementToDelete;
            if ((elementToDelete = @this.SingleOrDefault(expression)) != null)
                @this.Remove(elementToDelete);
        }

        /// <summary>
        /// Removes all elements in a list where a condition matches
        /// </summary>
        /// <typeparam name="T">The type of the elements of the source sequence.</typeparam>
        /// <param name="this">The source sequence.</param>
        /// <param name="expression">The expression to search for.</param>
        public static void RemoveWhere<T>([NotNull]this IList<T> @this, [NotNull]Func<T, bool> expression)
            where T : class
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            foreach (T element in @this.Where(expression))
                @this.Remove(element);
        }

        public static IList<T> AddItemIf<T>(this IList<T> @this, T element, Func<T, bool> expression)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            if (expression(element))
                @this.Add(element);

            return @this;
        }

        public static IList<T> AddItem<T>(this IList<T> @this, T @new)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            @this.Add(@new);
            return @this;
        }

        public static void AddRange<T>(this IList<T> @this, IEnumerable<T> elementsToAdd)
        {
            foreach(T element in elementsToAdd)
                @this.Add(element);
        }
        
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> @this, int count)
        {
            List<T> currentCollection = new List<T>(count);
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

            if(currentCollection.Any())
                yield return  currentCollection;
        }
    }
}
