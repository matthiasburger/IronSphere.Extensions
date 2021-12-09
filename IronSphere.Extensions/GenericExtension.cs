// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for a generic type T
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// // use it like:
    /// bool listContainsInt = 5.In(4,5,6);
    /// string replacedText = "test".ReplaceIf(s=>s == "test", s=> s+" succeeded");
    /// ]]>
    /// </example>
    public static class GenericExtension
    {
        /// <summary>
        /// Determines if an object is contained in a list
        /// </summary>
        /// <typeparam name="T">The type of object to search for.</typeparam>
        /// <param name="this">The actual item to search in the list.</param>
        /// <param name="listOfItems">The list of items to search in.</param>
        /// <returns>True if the item is found in the list; otherwise false.</returns>
        public static bool In<T>(this T @this, IEnumerable<T> listOfItems)
        {
            if (listOfItems is null)
                throw new ArgumentNullException(nameof(listOfItems));

            return listOfItems.Contains(@this);
        }

        /// <summary>
        /// Determines if an object is contained in a list
        /// </summary>
        /// <typeparam name="T">The type of object to search for.</typeparam>
        /// <param name="this">The actual item to search in the list.</param>
        /// <param name="listOfItems">The list of items to search in.</param>
        /// <returns>True if the item is found in the list; otherwise false.</returns>
        public static bool In<T>(this T @this, params T[] listOfItems)
        {
            if (listOfItems is null)
                throw new ArgumentNullException(nameof(listOfItems));

            return listOfItems.Contains(@this);
        }

        /// <summary>
        /// Determines if an object is not contained in a list
        /// </summary>
        /// <typeparam name="T">The type of object to search for.</typeparam>
        /// <param name="this">The actual item to search in the list.</param>
        /// <param name="listOfItems">The list of items to search in.</param>
        /// <returns>True if the item is not found in the list; otherwise false.</returns>
        public static bool NotIn<T>(this T @this, params T[] listOfItems)
        {
            if (listOfItems is null)
                throw new ArgumentNullException(nameof(listOfItems));

            return !listOfItems.Contains(@this);
        }

        /// <summary>
        /// Replaces an object with another value of the same type, if the expression returns true
        /// </summary>
        /// <typeparam name="T">The type of the actual object</typeparam>
        /// <param name="this">The actual type.</param>
        /// <param name="expression">The expression to invoke, to determine whether replacing or not.</param>
        /// <param name="output">The value to replace with, if the expression returns true.</param>
        /// <returns>The new value if replaced, otherwise the old.</returns>
        public static T ReplaceIf<T>(this T @this, Func<T, bool> expression, T output)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return expression(@this) ? output : @this;
        }

        /// <summary>
        /// Replaces an object with another value of the same type, if the expression returns true
        /// </summary>
        /// <typeparam name="T">The type of the actual object</typeparam>
        /// <param name="this">The actual type.</param>
        /// <param name="expression">The expression to invoke, to determine whether replacing or not.</param>
        /// <param name="output">An expression that returns a value of the same type, to replace with, if the expression returns true.</param>
        /// <returns>The new value if replaced, otherwise the old.</returns>
        public static T ReplaceIf<T>(this T @this, Func<T, bool> expression, Func<T, T> output)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (output is null)
                throw new ArgumentNullException(nameof(output));
            
            return expression(@this) ? output(@this) : @this;
        }

        /// <summary>
        /// String representation of any object
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// new Test{ p = 1, q = 2 }.ToString(s => $"{s.p + s.q}") == "3";
        /// ]]>
        /// </example>
        /// <typeparam name="T">The actual type of object.</typeparam>
        /// <param name="this">The actual object.</param>
        /// <param name="resultString">A function that returns a string in dependency to the actual object.</param>
        /// <returns>the representation-string.</returns>
        public static string ToString<T>(this T @this, Func<T, string> resultString)
        {
            if (resultString is null)
                throw new ArgumentNullException(nameof(resultString));

            return resultString(@this);
        }

        public static TResult Map<T, TResult>(this T t, Func<T, TResult> func)
        {
            return func(t);
        }
    }
}
