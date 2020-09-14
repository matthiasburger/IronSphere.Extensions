using System;

namespace IronSphere.Extensions
{
    public static class TimeSpanExtension
    {
        public static bool IsAfter(this TimeSpan @this, TimeSpan timeSpan) => @this > timeSpan;
        
        public static bool IsBefore(this TimeSpan @this, TimeSpan timeSpan) => @this < timeSpan;
                           
        public static TimeSpan Round(this TimeSpan time, TimeSpan roundingInterval, MidpointRounding roundingType) {
            return new TimeSpan(
                Convert.ToInt64(Math.Round(time.Ticks / (decimal)roundingInterval.Ticks, roundingType)) * roundingInterval.Ticks
            );
        }
    }
}
