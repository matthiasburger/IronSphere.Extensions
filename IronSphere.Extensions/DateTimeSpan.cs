using System;
using System.Collections;
using System.Collections.Generic;

namespace IronSphere.Extensions
{
    /// <inheritdoc />
    /// <summary>
    /// This class describes a range between two date-times
    /// </summary>
    public class DateTimeSpan : IEnumerable<DateTime>
    {
        private static readonly Dictionary<DateTimeSpanType, Func<DateTime, int, DateTime>> NextDateTimeFuncDictionary =
            new Dictionary<DateTimeSpanType, Func<DateTime, int, DateTime>>
            {
                {DateTimeSpanType.Ticks, (datetime, count) => datetime.AddTicks(count)},
                {DateTimeSpanType.Milliseconds, (datetime, count) => datetime.AddMilliseconds(count)},
                {DateTimeSpanType.Seconds, (datetime, count) => datetime.AddSeconds(count)},
                {DateTimeSpanType.Minutes, (datetime, count) => datetime.AddMinutes(count)},
                {DateTimeSpanType.Hours, (datetime, count) => datetime.AddHours(count)},
                {DateTimeSpanType.Days, (datetime, count) => datetime.AddDays(count)},
                {DateTimeSpanType.Months, (datetime, count) => datetime.AddMonths(count)},
                {DateTimeSpanType.Years, (datetime, count) => datetime.AddYears(count)}
            };

        /// <summary>
        /// Creates a new object from type <see cref="DateTimeSpan"/>
        /// </summary>
        /// <param name="start">start date of a datetime-span</param>
        /// <param name="end">end date of a datetime-span</param>
        public DateTimeSpan(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Creates a new object from type <see cref="DateTimeSpan"/>
        /// </summary>
        /// <param name="start">start date of a datetime-span</param>
        /// <param name="spanType">the span-type for iterating</param>
        /// <param name="step">the frequency to iterate</param>
        public DateTimeSpan(DateTime start, DateTimeSpanType spanType, int step)
        {
            Start = start;
            End = NextDateTimeFuncDictionary[spanType](start, step);
        }

        /// <summary>
        /// Gets the start-date for a DateTimeSpan
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Gets the end-date for a DateTimeSpan
        /// </summary>
        public DateTime End { get; }

        /// <summary>
        /// Gets or sets the span-type of type <see cref="DateTimeSpanType"/>
        /// </summary>
        public DateTimeSpanType SpanType { get; set; } = DateTimeSpanType.Days;

        /// <summary>
        /// Gets or sets the frequency for iterating
        /// </summary>
        public int Step { get; set; } = 1;

        /// <summary>
        /// Returns an enumerator to iterate over the sequence of <see cref="DateTime"/>
        /// </summary>
        /// <param name="spanType">The span-type for iterating</param>
        /// <param name="step">The frequency for iterating</param>
        /// <returns>The enumerator to iterate over</returns>
        public IEnumerator<DateTime> GetEnumerator(DateTimeSpanType spanType, int step)
        {
            Func<DateTime, int, DateTime> nextDateTimeFunc = NextDateTimeFuncDictionary[spanType];

            for (DateTime startDate = Start; startDate < End; startDate = nextDateTimeFunc(startDate, step))
                yield return startDate;
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns an enumerator to iterate over the sequence of <see cref="T:System.DateTime" />
        /// </summary>
        /// <returns>The enumerator to iterate over</returns>
        public IEnumerator<DateTime> GetEnumerator() => GetEnumerator(SpanType, Step);

        /// <inheritdoc />
        /// <summary>
        /// Returns an enumerator to iterate over the sequence of <see cref="DateTime" />
        /// </summary>
        /// <returns>The enumerator to iterate over</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Deconstructs a DateTimeSpan to a value-tuple
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void Deconstruct(out DateTime start, out DateTime end)
        {
            start = Start;
            end = End;
        }
    }
}
