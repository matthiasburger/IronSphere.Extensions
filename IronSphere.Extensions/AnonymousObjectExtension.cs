using System;
using System.Collections.Generic;
using System.Reflection;

using IronSphere.Extensions.Reflection;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for an <see cref="object"/> of anonymous type
    /// </summary>
    public static class AnonymousObjectExtension
    {
        /// <summary>
        /// Creates a dictionary from an anonymous type where the properties names are the keys and their values are the values
        /// </summary>
        /// <typeparam name="T">The dictionaries type of values</typeparam>
        /// <param name="source">the anonymous type to create a dictionary from</param>
        /// <returns>A dictionary representing the anonymous-type object</returns>
        /// <example>
        /// <![CDATA[
        /// // use it like:
        /// var source = new { a = 3, c = 7 };
        /// IDictionary<string, int> generatedDictionary = source.ToDictionary<int>();
        /// ]]>
        /// </example>
        /// <exception cref="ArgumentNullException">the source object is null</exception>
        public static IDictionary<string, T> ToDictionary<T>(this object? source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            Dictionary<string, T> dictionary = new();
            foreach (PropertyInfo property in source.GetType().GetProperties())
            {
                object value = property.GetValue(source);
                if (value is T value1)
                    dictionary.Add(property.Name, value1);

                else throw new InvalidCastException($"type of {value}[{value?.GetType().GetShortReadableName()}] is not {typeof(T).GetShortReadableName()}");
            }
            return dictionary;
        }

    }
}
