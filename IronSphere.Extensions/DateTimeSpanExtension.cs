using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="DateTimeSpan"/>
    /// </summary>
    public static class DateTimeSpanExtension
    {
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

            dateTimeSpans[0] = new DateTimeSpan(@this.Start, date.AddMilliseconds(-1));
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
            Stack<DateTimeSpan> dateTimeSpans = new Stack<DateTimeSpan>();
            dateTimeSpans.Push(@this);

            foreach (DateTime splitDate in dateToSplit)
            {
                Stack<DateTimeSpan> newStack = new Stack<DateTimeSpan>();

                while (dateTimeSpans.Count > 0)
                {
                    DateTimeSpan span = dateTimeSpans.Pop();
                    if (span.Start > splitDate || span.End < splitDate)
                    {
                        newStack.Push(span);
                        continue;
                    }

                    newStack.Push(new DateTimeSpan(span.Start, splitDate.AddMilliseconds(-1)));
                    newStack.Push(new DateTimeSpan(splitDate, span.End));
                }

                dateTimeSpans = newStack;
            }
            return dateTimeSpans.OrderBy(x => x.Start);
        }
    }
}
