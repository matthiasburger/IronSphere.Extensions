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
    }
}
