using System;
using System.Globalization;

namespace IronSphere.Extensions;

public static class StringCastingExtension
{
    public static bool? ToBool(this string @this)
    {
        if (bool.TryParse(@this.ToLower(), out bool temp))
            return temp;

        return @this is "1";
    }

    public static byte? ToByte(this string @this) => byte.TryParse(@this, out byte temp) ? temp : null;
    public static char? ToChar(this string @this) => char.TryParse(@this, out char temp) ? temp : null;

    public static DateTime? ToDateTime(this string @this)
        => DateTime.TryParse(@this, out DateTime temp) ? temp : null;

    public static DateTime? ToDateTime(this string @this, DateTimeStyles dateTimeStyles, IFormatProvider formatProvider)
        => DateTime.TryParse(@this, formatProvider, dateTimeStyles, out DateTime temp) ? temp : null;

    public static decimal? ToDecimal(this string @this) => decimal.TryParse(@this, out decimal temp) ? temp : null;

    public static decimal? ToDecimal(this string @this, NumberStyles numberStyles, IFormatProvider formatProvider) =>
        decimal.TryParse(@this, numberStyles, formatProvider, out decimal temp) ? temp : null;

    public static double? ToDouble(this string @this) => double.TryParse(@this, out double temp) ? temp : null;

    public static double? ToDouble(this string @this, NumberStyles numberStyles, IFormatProvider formatProvider) =>
        double.TryParse(@this, numberStyles, formatProvider, out double temp) ? temp : null;

    public static float? ToFloat(this string @this) => float.TryParse(@this, out float temp) ? temp : null;
    public static float? ToFloat(this string @this, NumberStyles numberStyles, IFormatProvider formatProvider) => float.TryParse(@this, numberStyles, formatProvider, out float temp) ? temp : null;
    public static int? ToInt(this string @this) => int.TryParse(@this, out int temp) ? temp : null;
    public static int? ToInt(this string @this, NumberStyles numberStyles, IFormatProvider formatProvider) => int.TryParse(@this, numberStyles, formatProvider, out int temp) ? temp : null;
    public static long? ToLong(this string @this) => long.TryParse(@this, out long temp) ? temp : null;
    public static long? ToLong(this string @this, NumberStyles numberStyles, IFormatProvider formatProvider) => long.TryParse(@this, numberStyles, formatProvider, out long temp) ? temp : null;
    public static short? ToShort(this string @this) => short.TryParse(@this, out short temp) ? temp : null;
    public static short? ToShort(this string @this, NumberStyles numberStyles, IFormatProvider formatProvider) => short.TryParse(@this, numberStyles, formatProvider, out short temp) ? temp : null;
}