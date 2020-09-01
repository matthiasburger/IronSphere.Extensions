// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FlagArgument

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtension
    {
        private const char Space = ' ';

        /// <summary>
        /// Encodes all the characters in the specified string into a sequence of bytes
        /// </summary>
        /// <param name="this">the actual string to encode</param>
        /// <param name="encoding">the encoding to use</param>
        /// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
        [MustUseReturnValue]
        public static byte[] GetBytes([NotNull]this string @this, [CanBeNull]Encoding encoding = null)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            return (encoding ?? Encoding.UTF8).GetBytes(@this);
        }

        /// <summary>
        /// Indicates whether the specified string is null or an empty string ("").
        /// </summary>
        /// <param name="this">The actual string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        [MustUseReturnValue]
        public static bool IsNullOrEmpty([CanBeNull]this string @this) => string.IsNullOrEmpty(@this);

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <returns>true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.</returns>
        [MustUseReturnValue]
        public static bool IsNullOrWhiteSpace([CanBeNull]this string @this) => string.IsNullOrWhiteSpace(@this);

        [MustUseReturnValue, NotNull]
        public static string ValueIfNullOrEmpty([CanBeNull] this string @this, string defaultValue) =>
            string.IsNullOrEmpty(@this) ? defaultValue : @this;

        [MustUseReturnValue, NotNull]
        public static string ValueIfNullOrWhiteSpace([CanBeNull] this string @this, string defaultValue) =>
            string.IsNullOrWhiteSpace(@this) ? defaultValue : @this;

        /// <summary>
        /// Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
        /// </summary>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="this">The string to use as a separator. separator is included in the returned string only if value has more than one element.</param>
        /// <param name="elements">An array that contains the elements to concatenate.</param>
        /// <returns>A string that consists of the members of values delimited by the separator string. If values has no members, the method returns Empty.</returns>
        [MustUseReturnValue]
        public static string Join<T>([CanBeNull]this string @this, [NotNull]IEnumerable<T> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            return string.Join(@this ?? string.Empty, elements);
        }

        /// <summary>
        /// Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
        /// </summary>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="this">The string to use as a separator. separator is included in the returned string only if value has more than one element.</param>
        /// <param name="elements">An array that contains the elements to concatenate.</param>
        /// <param name="toString"></param>
        /// <returns>A string that consists of the members of values delimited by the separator string. If values has no members, the method returns Empty.</returns>
        [MustUseReturnValue]
        public static string Join<T>([CanBeNull]this string @this, [NotNull]IEnumerable<T> elements, Func<T, string> toString)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            return string.Join(@this ?? string.Empty, elements.Select(toString));
        }

        /// <summary>
        /// Indicates whether a specified string starts with any parametrized string
        /// </summary>
        /// <param name="this">The actual string</param>
        /// <param name="parameter">All strings to test with</param>
        /// <returns>true if the actual string starts with any of the parametrized strings, otherwise false.</returns>
        [MustUseReturnValue]
        public static bool StartsWithAny([NotNull]this string @this, [NotNull] params string[] parameter)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (parameter is null)
                throw new ArgumentNullException(nameof(parameter));

            return parameter.Any(@this.StartsWith);
        }

        /// <summary>
        /// Indicates whether a specified string ends with any parametrized string
        /// </summary>
        /// <param name="this">The actual string</param>
        /// <param name="parameter">All strings to test with</param>
        /// <returns>true if the actual string ends with any of the parametrized strings, otherwise false.</returns>
        [MustUseReturnValue]
        public static bool EndsWithAny([NotNull]this string @this, [NotNull]params string[] parameter)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (parameter is null)
                throw new ArgumentNullException(nameof(parameter));

            return parameter.Any(@this.EndsWith);
        }

        /// <summary>
        /// Indicates whether a specified string starts with any parametrized string
        /// </summary>
        /// <param name="this">The actual string</param>
        /// <param name="parameter">All strings to test with</param>
        /// <returns>true if the actual string starts with any of the parametrized strings, otherwise false.</returns>
        [MustUseReturnValue]
        public static bool ContainsAny([NotNull]this string @this, [NotNull]params string[] parameter)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (parameter is null)
                throw new ArgumentNullException(nameof(parameter));

            return parameter.Any(@this.Contains);
        }

        /// <summary>
        /// Splits a string after a specified position
        /// </summary>
        /// <param name="this">the actual string to split</param>
        /// <param name="position">the position to split the string at</param>
        /// <returns>a list if strings</returns>
        [NotNull, ItemNotNull, MustUseReturnValue]
        public static IEnumerable<string> Split([NotNull]this string @this, int position)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            if (position <= 0)
            {
                yield return @this;
                yield break;
            }

            StringBuilder stringPart = new StringBuilder();
            for (int index = 0; index < @this.Length; index++)
            {
                char character = @this[index];
                stringPart.Append(character);

                if ((index + 1) % position != 0) continue;

                yield return stringPart.ToString();
                stringPart.Clear();
            }

            if (stringPart.Length > 0)
                yield return stringPart.ToString();
        }

        /// <summary>
        /// Cuts a string at a specified position. The string can be at the end concatenated with a suffix. By specifying waitForWhitespace the string will be cut after the next whitespace after position.
        /// </summary>
        /// <param name="this">The actual string.</param>
        /// <param name="position">The position to get the string at.</param>
        /// <param name="endConcat">The suffix to append</param>
        /// <param name="waitForWhitespace">specifies hard or soft cut.</param>
        /// <returns>Returns the cut string, concatenated with the suffix.</returns>
        [MustUseReturnValue]
        [SuppressMessage("ReSharper", "MethodTooLong")]
        public static string CutAt([NotNull]this string @this, int position, [CanBeNull]string endConcat,
            bool waitForWhitespace = false)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position), "argument position must not be negative");

            string actualString = string.Empty;

            foreach (string part in @this.Split(position))
            {
                if (actualString.IsNullOrWhiteSpace())
                {
                    if ((actualString = part).Last() == Space || !waitForWhitespace)
                        break;
                    continue;
                }

                if (part.Contains(Space))
                {
                    actualString += part.Split(Space).First();
                    break;
                }

                actualString += part;
            }

            actualString = actualString.TrimEnd();
            if (!endConcat.IsNullOrWhiteSpace() && actualString.Length < @this.Length)
                actualString += endConcat;
            return actualString;
        }

        /// <summary>
        /// Parses a string to its int representation
        /// </summary>
        /// <param name="this">the actual string to parse</param>
        /// <returns>The parsed value or null if parsing failed.</returns>
        [MustUseReturnValue]
        public static int? ToIntOrNull([CanBeNull]this string @this)
        {
            if (@this is null)
                return null;

            return int.TryParse(@this, out int result) ? result : (int?)null;
        }

        /// <summary>
        /// Removes all diacritics in a string
        /// </summary>
        /// <param name="this">The actual string to remove diacritics from</param>
        /// <returns>A string without any diacritics.</returns>
        [MustUseReturnValue]
        public static string RemoveDiacritics([CanBeNull]this string @this)
        {
            if (@this is null) return null;
            IEnumerable<char> chars =
                from c in @this.Normalize(NormalizationForm.FormD).ToCharArray()
                let uc = CharUnicodeInfo.GetUnicodeCategory(c)
                where uc != UnicodeCategory.NonSpacingMark
                select c;

            return new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// upholsters a string on the left with a specific character
        /// </summary>
        /// <param name="this"></param>
        /// <param name="count"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string UpholsterLeft([NotNull]this string @this, int count, char character = Space)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "argument count must not be negative");

            return $"{Enumerable.Repeat(character, count).GetString()}{@this}";
        }

        /// <summary>
        /// upholsters a string on the right with a specific character
        /// </summary>
        /// <param name="this"></param>
        /// <param name="count"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string UpholsterRight([NotNull]this string @this, int count, char character = Space)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "argument count must not be negative");

            return $"{@this}{Enumerable.Repeat(character, count).GetString()}";
        }

        /// <summary>
        /// upholsters a string on the left and right with a specific character
        /// </summary>
        /// <param name="this"></param>
        /// <param name="count"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string Upholster([NotNull]this string @this, int count, char character = Space)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "argument count must not be negative");

            string upholsterString = Enumerable.Repeat(character, count).GetString();
            return $"{upholsterString}{@this}{upholsterString}";
        }

        /// <summary>
        /// formats a string with values in an anonymous object
        /// </summary>
        /// <param name="this"></param>
        /// <param name="anonymousObject"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MustUseReturnValue]
        public static string Format([NotNull]this string @this, [NotNull]object anonymousObject)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (anonymousObject is null)
                throw new ArgumentNullException(nameof(anonymousObject));

            IDictionary<string, object> values = anonymousObject.ToDictionary<object>();

            return _stringFormat(@this, values);
        }

        /// <summary>
        /// formats a string with values in a dictionary
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MustUseReturnValue]
        public static string Format([NotNull]this string @this, [NotNull]IDictionary<string, object> values)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            return _stringFormat(@this, values);
        }

        private static string _stringFormat([NotNull]string @this, [NotNull]IDictionary<string, object> values)
        {
            MatchCollection matches = Regex.Matches(@this, @"\{(.+?)\}");
            List<string> words = (from Match match in matches select match.Groups[1].Value).ToList();

            string current = @this;

            foreach (string key in words)
            {
                int colonIndex = key.IndexOf(':');
                if (colonIndex <= 0)
                    current = current.Replace($"{{{key}}}", values[key].ToString());
                else
                {
                    string colonFormattedString = $"{{0:{key.Substring(colonIndex + 1)}}}";
                    current = current.Replace($"{{{key}}}",
                        string.Format(colonFormattedString, values[key.Substring(0, colonIndex)]));
                }
            }

            return current;
        }
    }
}