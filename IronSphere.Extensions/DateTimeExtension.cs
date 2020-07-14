// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// A static array of days contained by a weekend
        /// </summary>
        public static readonly IReadOnlyList<DayOfWeek> Weekend = new []{ DayOfWeek.Saturday, DayOfWeek.Sunday };

        /// <summary>
        /// Calculates the first day of a week.
        /// </summary>
        /// <param name="this">The actual date-time</param>
        /// <param name="startOfWeek">The first day of the week, default is monday.</param>
        /// <returns>The first weekday of the week for the actual date-time.</returns>
        public static DateTime GetFirstOfWeek(this DateTime @this, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = @this.DayOfWeek - startOfWeek;
            if (diff < 0) diff += 7;
            return @this.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Calculates the last day of a week.
        /// </summary>
        /// <param name="this">The actual date-time.</param>
        /// <param name="startOfWeek">The first day of the week, default is monday.</param>
        /// <returns>The last weekday of the week for the actual date-time.</returns>
        public static DateTime GetLastOfWeek(this DateTime @this, DayOfWeek startOfWeek = DayOfWeek.Monday)
            => GetFirstOfWeek(@this, startOfWeek).AddDays(6);

        /// <summary>
        /// Calculates the first day of a month.
        /// </summary>
        /// <param name="this">The actual date-time.</param>
        /// <returns>The first day of the month for the actual date-time.</returns>
        public static DateTime GetFirstOfMonth(this DateTime @this) => new DateTime(@this.Year, @this.Month, 1).Date;

        /// <summary>
        /// Calculates the last day of a month.
        /// </summary>
        /// <param name="this">The actual date-time.</param>
        /// <returns>The last day of the month for the actual date-time.</returns>
        public static DateTime GetLastOfMonth(this DateTime @this) => GetFirstOfMonth(@this).AddMonths(1).AddDays(-1);

        /// <summary>
        /// Determines whether the year of the given date is a leap year
        /// </summary>
        /// <param name="this">The actual date-time.</param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime @this) => DateTime.IsLeapYear(@this.Year);

        /// <summary>
        /// Determines, if a convertible object is between two objects of the same type
        /// </summary>
        /// <param name="this">The actual object.</param>
        /// <param name="lower">The lower limit.</param>
        /// <param name="higher">The higher limit.</param>
        /// <returns>True, if the actual object is higher than the lower limit and lower than the higher limit.</returns>
        public static bool Between(this DateTime @this, DateTime lower, DateTime higher) =>
            @this.CompareTo(lower) >= 0 && @this.CompareTo(higher) <= 0;

        /// <summary>
        /// Calculates the age (years) from a date.
        /// </summary>
        /// <param name="this">the actual date</param>
        /// <returns>The age of the date</returns>
        public static int GetAge(this DateTime @this)
        {
            int age = DateTime.Today.Year - @this.Year;

            if (@this.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }

        /// <summary>
        /// Gets the calendar-week of a date dependent to a culture with ISO 8601
        /// </summary>
        /// <param name="dateTime">the actual datetime</param>
        /// <param name="cultureInfo">the culture to use</param>
        /// <param name="weekOfYearStandard">the standard to use</param>
        /// <returns>the week of year for the specified datetime</returns>
        public static int GetWeekOfYear(this DateTime dateTime, [CanBeNull]CultureInfo cultureInfo = null, WeekOfYearStandard weekOfYearStandard = WeekOfYearStandard.Iso8601)
        {
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;

            switch (weekOfYearStandard)
            {
                case WeekOfYearStandard.DotNet:
                    return GetWeekOfYearNetStandard(dateTime, cultureInfo);
                case WeekOfYearStandard.Iso8601:
                    return GetWeekOfYearIso8601(dateTime, cultureInfo);
                default:
                    throw new ArgumentOutOfRangeException(nameof(weekOfYearStandard), weekOfYearStandard, null);
            }
        }

        private static int GetWeekOfYearIso8601(DateTime dateTime, [NotNull]CultureInfo cultureInfo)
        {
            if (cultureInfo is null)
                throw new ArgumentNullException(nameof(cultureInfo));

            DayOfWeek day = cultureInfo.Calendar.GetDayOfWeek(dateTime);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                dateTime = dateTime.AddDays(3);

            return cultureInfo.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private static int GetWeekOfYearNetStandard(DateTime dateTime, [NotNull]CultureInfo cultureInfo)
        {
            if (cultureInfo is null)
                throw new ArgumentNullException(nameof(cultureInfo));

            DayOfWeek day = cultureInfo.Calendar.GetDayOfWeek(dateTime);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                dateTime = dateTime.AddDays(3);

            return cultureInfo.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// determines whether a date is in weekend
        /// </summary>
        /// <param name="this">the actual date to check</param>
        /// <returns>if the date is in weekend</returns>
        public static bool IsWeekend(this DateTime @this) => Weekend.Any(x => x == @this.DayOfWeek);

        public static DateTime SetTime(this DateTime @this, TimeSpan timeSpan)
            => @this.Date + timeSpan;

        public static DateTime SetTime(this DateTime @this, (int hours, int minutes, int seconds) time)
            => @this.Date + new TimeSpan(time.hours, time.minutes, time.seconds);

        public static DateTime SetTime(this DateTime @this, (int hours, int minutes) time)
            => @this.Date + new TimeSpan(time.hours, time.minutes, 0);

        public static bool Between(this DateTime @this, DateTimeSpan span)
            => @this.CompareTo(span.Start) >= 0 && @this.CompareTo(span.End) <= 0;

        public static DateTimeSpan SpanTo(this DateTime @this, DateTime end) 
            => new DateTimeSpan(@this, end);

        public static DateTimeSpan SpanTo(this DateTime @this, int amount, DateTimeSpanType spanType) 
            => new DateTimeSpan(@this, spanType, amount);
    }
}
