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
        public static byte[] GetBytes(this string? @this, Encoding? encoding = null)
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
        public static bool IsNullOrEmpty(this string? @this) => string.IsNullOrEmpty(@this);

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="this">The string to test.</param>
        /// <returns>true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.</returns>
        [MustUseReturnValue]
        public static bool IsNullOrWhiteSpace(this string? @this) => string.IsNullOrWhiteSpace(@this);

        [MustUseReturnValue]
        public static string ValueIfNullOrEmpty(this string? @this, string defaultValue) =>
            @this is null || string.IsNullOrEmpty(@this) ? defaultValue : @this;

        [MustUseReturnValue]
        public static string ValueIfNullOrWhiteSpace(this string? @this, string defaultValue) =>
            @this is null || string.IsNullOrWhiteSpace(@this) ? defaultValue : @this;

        /// <summary>
        /// Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
        /// </summary>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="this">The string to use as a separator. separator is included in the returned string only if value has more than one element.</param>
        /// <param name="elements">An array that contains the elements to concatenate.</param>
        /// <returns>A string that consists of the members of values delimited by the separator string. If values has no members, the method returns Empty.</returns>
        [MustUseReturnValue]
        public static string Join<T>(this string? @this, IEnumerable<T> elements)
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
        public static string Join<T>(this string? @this, IEnumerable<T>? elements, Func<T, string> toString)
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
        public static bool StartsWithAny(this string? @this, params string[]? parameter)
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
        public static bool EndsWithAny(this string? @this, params string[]? parameter)
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
        public static bool ContainsAny(this string? @this, params string[]? parameter)
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
        [MustUseReturnValue]
        public static IEnumerable<string> Split(this string @this, int position)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            if (position <= 0)
            {
                yield return @this;
                yield break;
            }

            StringBuilder stringPart = new();
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
        public static string CutAt(this string @this, int position, string? endConcat,
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
        public static int? ToIntOrNull(this string? @this)
        {
            if (@this is null)
                return null;

            return int.TryParse(@this, out int result) ? result : null;
        }

        /// <summary>
        /// Removes all diacritics in a string
        /// </summary>
        /// <param name="this">The actual string to remove diacritics from</param>
        /// <returns>A string without any diacritics.</returns>
        [MustUseReturnValue]
        public static string? RemoveDiacritics(this string? @this)
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
        public static string UpholsterLeft(this string @this, int count, char character = Space)
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
        public static string UpholsterRight(this string @this, int count, char character = Space)
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
        public static string Upholster(this string @this, int count, char character = Space)
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
        public static string Format(this string @this, object anonymousObject)
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
        public static string Format(this string @this, IDictionary<string, object> values)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            return _stringFormat(@this, values);
        }

        private static string _stringFormat(string @this, IDictionary<string, object> values)
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

        public static int NthIndexOf(this string @this, string value, int occurrence)
        {
            int count = 1;
            int index = 0;

            while (count <= occurrence && (index = @this.IndexOf(value, index + 1, StringComparison.Ordinal)) != -1)
            {
                if (count == occurrence)
                    return index;

                count++;
            }

            return -1;
        }

        public static bool Like(this string? @this, string? pattern)
        {
            if (@this is null || pattern is null || string.IsNullOrEmpty(pattern))
                return false;

            string regexPattern = $"^{pattern}$";

            regexPattern = regexPattern
                .Replace(@"\[!", "[^")
                .Replace(@"\[", "[")
                .Replace(@"\]", "]")
                .Replace(@"\?", ".")
                .Replace(@"\*", ".*")
                .Replace(@"\#", @"\d");

            try
            {
                return Regex.IsMatch(@this, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid pattern: {pattern}", ex);
            }
        }
        
        public static string? Substring(this string @this, string startText, string endText, StringComparison stringComparison = StringComparison.Ordinal) 
        {
            if (string.IsNullOrEmpty(startText) || string.IsNullOrEmpty(endText))
                throw new ArgumentException("Start Text and End Text cannot be empty.");

            int start = @this.IndexOf(startText, stringComparison);
            if (start < 0) return null;

            int end = @this.IndexOf(endText, start, stringComparison);
            if (end < 0) return null;

            return @this.Substring(start, end - start);
        }


        [Obsolete("Renamed, will be removed after version 21.12.0.0. Use @this.Substring(startText, endText, stringComparison)")]
        public static string? SubString(this string @this, string startText, string endText, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(startText) || string.IsNullOrEmpty(endText))
                throw new ArgumentException("Start Text and End Text cannot be empty.");

            int start = @this.IndexOf(startText, stringComparison);
            if (start < 0) return null;

            int end = @this.IndexOf(endText, start, stringComparison);
            if (end < 0) return null;

            return @this.Substring(start, end - start);
        }

        /// <summary>
        /// capitalizes a string
        /// </summary>
        /// <param name="this">the actual string</param>
        /// <returns>a capitalized version of the actual string</returns>
        public static string Capitalize(this string? @this)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            
            if (string.IsNullOrWhiteSpace(@this))
                return @this;

            return $"{char.ToUpper(@this[0])}{@this.Remove(0, 1)}";
        }

        /// <summary>
        /// splits a string at a specific point. you can decide whether it should include the char you split on, or not.
        /// </summary>
        /// <param name="this">the actual string</param>
        /// <param name="onExclude">a func on where to split the string, and doesn't include the char you split on</param>
        /// <param name="onInclude">a func on where to split the string, and includes the char you split on into the next string</param>
        /// <returns>yields all string-parts where you split</returns>
        public static IEnumerable<string> Split(this string? @this, Func<char, bool>? onExclude = null, Func<char, bool>? onInclude = null)
        {
            if (@this is null || string.IsNullOrWhiteSpace(@this))
                yield break;

            StringBuilder stringBuilder = new();
            foreach (char c in @this)
            {
                if (onExclude is not null && onExclude(c))
                {
                    if (stringBuilder.Length > 0)
                    {
                        yield return stringBuilder.ToString();
                        stringBuilder.Clear();
                    }

                    continue;
                }

                if (onInclude is not null && onInclude(c))
                {
                    if (stringBuilder.Length > 0)
                    {
                        yield return stringBuilder.ToString();
                        stringBuilder.Clear();
                    }
                }

                stringBuilder.Append(c);
            }

            if (stringBuilder.Length > 0)
                yield return stringBuilder.ToString();
        }

        /// <summary>
        /// camel-cases a string
        /// splits the string at char.Upper, whitespace, dash or underscore
        /// </summary>
        /// <param name="this">the actual string</param>
        /// <returns>a camelCasedVersion of the actual string</returns>
        public static string CamelCase(this string? @this)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            
            if (string.IsNullOrWhiteSpace(@this))
                return @this;

            string[] parts = @this.Split(c => c.In(' ', '-', '_'), char.IsUpper).ToArray();
            if (parts.Length == 1)
                return parts[0].ToLower();

            return $"{parts[0].ToLower()}{string.Concat(parts.Skip(1).Select(Capitalize))}";
        }

        /// <summary>
        /// pascal-cases a string
        /// splits the string at whitespace, dash or underscore
        /// </summary>
        /// <param name="this">the actual string</param>
        /// <returns>a PascalCasedVersion of the actual string</returns>
        public static string PascalCase(this string? @this)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            
            if (string.IsNullOrEmpty(@this))
                return @this;

            return string.Concat(@this.Split(' ', '-', '_').Select(Capitalize));
        }
    }
}