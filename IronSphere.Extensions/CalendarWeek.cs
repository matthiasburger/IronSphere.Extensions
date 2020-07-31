﻿using System;
using System.Globalization;

namespace IronSphere.Extensions
{
    /// <summary>
    /// struct for calendar-week
    /// </summary>
    public struct CalendarWeek
    {
        /// <summary>
        /// creates a new calendar-week-value
        /// </summary>
        /// <param name="week">the week of calendar-week</param>
        /// <param name="year">the year of calendar-week</param>
        public CalendarWeek(int week, int year)
        {
            Week = week;
            Year = year;
            CultureInfo = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// creates a new calendar-week
        /// </summary>
        /// <param name="week">the week of calendar-week</param>
        /// <param name="year">the year of calendar-week</param>
        /// <param name="cultureInfo">the actual culture</param>
        public CalendarWeek(int week, int year, CultureInfo cultureInfo)
        {
            Week = week;
            Year = year;
            CultureInfo = cultureInfo;
        }

        /// <summary>
        /// the week
        /// </summary>
        public int Week { get; }

        /// <summary>
        /// the year
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// the culture-info
        /// </summary>
        public CultureInfo CultureInfo { get; set; }
            
        private DateTime _getFirstDateOfWeekByWeekNumber()
        {
            switch (CultureInfo.DateTimeFormat.CalendarWeekRule)
            {
                case CalendarWeekRule.FirstFourDayWeek:
                    return _getFirstDateOfWeekByWeekNumber_FirstFourDayWeek();
                case CalendarWeekRule.FirstFullWeek:
                    return _getFirstDateOfWeekByWeekNumber_FirstFullWeek();
                case CalendarWeekRule.FirstDay:
                    return _getFirstDateOfWeekByWeekNumber_FirstDay();
                default:
                    throw new ArgumentOutOfRangeException($"{CultureInfo.DateTimeFormat.CalendarWeekRule} is not implemented");
            }
        }

        private DateTime _getFirstDateOfWeekByWeekNumber_FirstFullWeek()
        {
            DateTime date = new DateTime(Year, 1, 1);

            date = date.AddDays(CultureInfo.DateTimeFormat.FirstDayOfWeek - date.DayOfWeek);

            int weekOfYear = CultureInfo.Calendar.GetWeekOfYear(date, CultureInfo.DateTimeFormat.CalendarWeekRule, CultureInfo.DateTimeFormat.FirstDayOfWeek);

            date = date.AddDays(7 * Math.Sign(weekOfYear - 1));

            return date;
        }
        
        private DateTime _getFirstDateOfWeekByWeekNumber_FirstDay()
        {
            DateTime jan1 = new DateTime(Year, 1, 1);
            int daysOffset = (int)CultureInfo.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = CultureInfo.Calendar.GetWeekOfYear(jan1, CultureInfo.DateTimeFormat.CalendarWeekRule, CultureInfo.DateTimeFormat.FirstDayOfWeek);
            int week = Week;
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3) 
                week -= 1;
            return firstWeekDay.AddDays(week * 7);
        }

        private DateTime _getFirstDateOfWeekByWeekNumber_FirstFourDayWeek()
        {
            DateTime jan1 = new DateTime(Year, 1, 1);

            DateTime firstThursday = jan1.AddDays( DayOfWeek.Thursday - jan1.DayOfWeek);
            
            int firstWeek = CultureInfo.Calendar.GetWeekOfYear(firstThursday, CultureInfo.DateTimeFormat.CalendarWeekRule, CultureInfo.DateTimeFormat.FirstDayOfWeek);

            int weekNum = Week;
            if (firstWeek == 1) 
                weekNum -= 1;

            DateTime result = firstThursday.AddDays(weekNum * 7);

            return result.AddDays(-3);
        }

        /// <summary>
        /// calculates the first weekday of actual calendar-week
        /// </summary>
        /// <returns>a <see cref="DateTime"/> representing the first day of the calendar-week</returns>
        public DateTime GetFirstWeekDay() => _getFirstDateOfWeekByWeekNumber();

        /// <summary>
        /// calculates the datetime-span for the calendar-week
        /// </summary>
        /// <returns>a datetime-span for the actual calendar-week</returns>
        public DateTimeSpan GetDateTimeSpan()
        {
            DateTime firstDateOfWeek = _getFirstDateOfWeekByWeekNumber();
            return new DateTimeSpan(firstDateOfWeek, firstDateOfWeek.GetLastOfWeek());
        }

        /// <summary>
        /// returns a string-representation for the calendar-week
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Week}/{Year}";
        }

        /// <summary>
        /// returns a string-representation for the calendar-week
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            format = format
                    .Replace("ww", Week.ToString("00"))
                    .Replace("w", Week.ToString());

            return _getFirstDateOfWeekByWeekNumber().ToString(format);
        }
    }
}
