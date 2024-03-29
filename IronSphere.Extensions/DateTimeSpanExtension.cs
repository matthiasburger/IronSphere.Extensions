﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions;

/// <summary>
/// This class provides extension methods for <see cref="DateTimeSpan"/>
/// </summary>
public static class DateTimeSpanExtension
{
    public static IEnumerable<CalendarWeek> GetCalendarWeekRange(this DateTimeSpan @this)
    {
        IEnumerable<DateTimeSpan> ranges = @this.Split(@this.Where(x => x.DayOfWeek == DayOfWeek.Monday).ToArray())
            .Where(w => w.Start != w.End);
        foreach ((DateTime start, DateTime _) in ranges.ToList())
        {
            DateTime lastWeekDay = start.GetLastOfWeek();
            int yearOfWeek = start.Year;
            if (start.Year != lastWeekDay.Year)
            {
                if (new DateTime(lastWeekDay.Year, 1, 1).DayOfWeek <= DayOfWeek.Thursday)
                    yearOfWeek = lastWeekDay.Year;
            }
                
            yield return new CalendarWeek(start.GetWeekOfYear(), yearOfWeek);
        }
    }

    /// <summary>
    /// Creates a new DateTimeSpan-object from a tuple of dates
    /// </summary>
    /// <param name="dateTuple">the actual dates for the range</param>
    /// <param name="spanType">the interval type for enumeration</param>
    /// <param name="step">the frequency for enumeration</param>
    /// <returns>the SpanType</returns>
    public static DateTimeSpan Range(this (DateTime start, DateTime end) dateTuple,
        DateTimeSpanType spanType = DateTimeSpanType.Days, int step = 1)
    {
        (DateTime start, DateTime end) = dateTuple;
        return new DateTimeSpan(start, end)
        {
            SpanType = spanType,
            Step = step
        };
    }

    /// <summary>
    /// Splits a <see cref="DateTimeSpan"/> at a <see cref="DateTime"/> into 2 spans
    /// </summary>
    /// <param name="this">the actual span</param>
    /// <param name="date">the date where to split</param>
    /// <returns>the split <see cref="DateTimeSpan"/> objects</returns>
    public static DateTimeSpan[] Split(this DateTimeSpan @this, DateTime date)
    {
        DateTimeSpan[] dateTimeSpans = new DateTimeSpan[2];

        if (@this.Start > date || @this.End < date)
            return new[] { @this };

        dateTimeSpans[0] = new DateTimeSpan(@this.Start, date);
        dateTimeSpans[1] = new DateTimeSpan(date, @this.End);

        return dateTimeSpans;
    }

    /// <summary>
    /// Splits a <see cref="DateTimeSpan"/> at a <see cref="DateTime"/> into multiple spans
    /// </summary>
    /// <param name="this">the actual span</param>
    /// <param name="dateToSplit">the dates where to split</param>
    /// <returns>the split <see cref="DateTimeSpan"/> objects</returns>
    public static IEnumerable<DateTimeSpan> Split(this DateTimeSpan @this, params DateTime[] dateToSplit)
    {
        Stack<DateTimeSpan> dateTimeSpans = new();
        dateTimeSpans.Push(@this);

        foreach (DateTime splitDate in dateToSplit)
        {
            Stack<DateTimeSpan> newStack = new();

            while (dateTimeSpans.Count > 0)
            {
                DateTimeSpan span = dateTimeSpans.Pop();
                if (span.Start > splitDate || span.End < splitDate)
                {
                    newStack.Push(span);
                    continue;
                }

                newStack.Push(new DateTimeSpan(span.Start, splitDate));
                newStack.Push(new DateTimeSpan(splitDate, span.End));
            }

            dateTimeSpans = newStack;
        }
        return dateTimeSpans.OrderBy(x => x.Start);
    }          
}