using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="CultureInfo"/>
    /// </summary>
    public static class CultureInfoExtension
    {
        /// <summary>
        /// Returns all months in the language of the cultures language.
        /// </summary>
        /// <param name="culture">actual culture</param>
        /// <returns>all months in the language of the cultures language</returns>
        public static IEnumerable<(int, string)> GetMonthsOfCulture([NotNull]this CultureInfo culture)
        {
            if (culture is null)
                throw new ArgumentNullException(nameof(culture));

            return Enumerable.Range(1, 12).Select(x => (x, culture.DateTimeFormat.GetMonthName(x)));
        }
    }
}
