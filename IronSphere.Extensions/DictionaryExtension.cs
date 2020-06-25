using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="Dictionary{TKey,TValue}"/>
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Searches for a key in a dictionary and returns its value if it exists.
        /// </summary>
        /// <typeparam name="TKey">the dictionaries key-type</typeparam>
        /// <typeparam name="TValue">the dictionaries value-type</typeparam>
        /// <param name="this">the actual dictionary</param>
        /// <param name="key">the key to search for</param>
        /// <param name="fallback">the fallback-value, if the key doesn't exist</param>
        /// <returns>The found value or the fallback if the key doesn't exist.</returns>
        public static TValue GetValue<TKey, TValue>([NotNull]this Dictionary<TKey, TValue> @this, TKey key,
            TValue fallback = default)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            return @this.ContainsKey(key) ? @this[key] : fallback;
        }

        /// <summary>
        /// Searches for a key in a name-value-collection and returns its value if it exists.
        /// </summary>
        /// <typeparam name="TValue">the collections value-type</typeparam>
        /// <param name="this">the actual dictionary</param>
        /// <param name="key">the key to search for</param>
        /// <param name="fallback">the fallback-value, if the key doesn't exist</param>
        /// <returns>The found value or the fallback if the key doesn't exist.</returns>
        public static TValue GetValue<TValue>([NotNull]this NameValueCollection @this, string key,
            TValue fallback = default)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            Type typeToConvert = typeof(TValue);
            Type underlyingType;
            if ((underlyingType = Nullable.GetUnderlyingType(typeToConvert)) != null)
                typeToConvert = underlyingType;

            return @this.AllKeys.Contains(key) ? (TValue)Convert.ChangeType(@this[key], typeToConvert) : fallback;
        }

        /// <summary>
        /// Searches for a key in a generic key-value-sequence and returns its value if it exists.
        /// </summary>
        /// <typeparam name="TValue">the collections value-type</typeparam>
        /// <typeparam name="TKey">the collections key-type</typeparam>
        /// <param name="this">the actual dictionary</param>
        /// <param name="key">the key to search for</param>
        /// <param name="fallback">the fallback-value, if the key doesn't exist</param>
        /// <returns>The found value or the fallback if the key doesn't exist.</returns>
        public static TValue GetValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> @this, TKey key, TValue fallback = default)
        {
            using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = @this.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    if (EqualityComparer<TKey>.Default.Equals(enumerator.Current.Key, key))
                        return enumerator.Current.Value;
            }

            return fallback;
        }

        [NotNull]
        public static IDictionary<TKey, TValue> AddOrUpdate<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> @this, [NotNull] TKey key, TValue value)
        {
            @this[key] = value;
            return @this;
        }

        [NotNull]
        public static TValue GetOrCreate<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> @this, [NotNull] TKey key, Func<TKey, TValue> function)
        {
            if (!@this.ContainsKey(key))
                @this[key] = function(key);

            return @this[key];
        }
    }
}
