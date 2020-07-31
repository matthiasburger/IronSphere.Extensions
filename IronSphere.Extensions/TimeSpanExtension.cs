using System;

namespace IronSphere.Extensions
{
    public static class TimeSpanExtension
    {
        public static bool IsAfter(this TimeSpan @this, TimeSpan timeSpan) => @this > timeSpan;
        
        public static bool IsBefore(this TimeSpan @this, TimeSpan timeSpan) => @this < timeSpan;
    }
}
