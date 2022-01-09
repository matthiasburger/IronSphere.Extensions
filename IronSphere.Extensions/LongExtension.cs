// ReSharper disable MemberCanBePrivate.Global

using System;

namespace IronSphere.Extensions;

/// <summary>
/// This class provides extension methods for <see cref="long"/>
/// </summary>
public static class LongExtension
{
    /// <summary>
    /// Checks whether the actual value is between specified lower and higher.
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <param name="lower">the lower value</param>
    /// <param name="higher">the higher value</param>
    /// <returns>A value indicating whether the actual value is between two values.</returns>
    public static bool Between(this long @this, long lower, long higher) =>
        @this.CompareTo(lower) > 0 && @this.CompareTo(higher) < 0;

    /// <summary>
    /// Checks whether the actual value is greater than zero.
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <returns>A value indicating whether the actual value is positive.</returns>
    public static bool IsPositive(this long @this) => @this.CompareTo(0) > 0;

    /// <summary>
    /// Checks whether the actual value is smaller than zero.
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <returns>A value indicating whether the actual value is negative.</returns>
    public static bool IsNegative(this long @this) => @this.CompareTo(0) < 0;

    /// <summary>
    /// Checks whether the actual value is equal to zero.
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <returns>A value indicating whether the actual value is equal to zero.</returns>
    public static bool IsZero(this long @this) => @this.CompareTo(0) == 0;

    /// <summary>
    /// Checks whether the actual value is greater than an other one.
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <param name="other">the other value</param>
    /// <returns>A value indicating whether the actual value is greater than a second value.</returns>
    public static bool IsGreaterThan(this long @this, long other) => @this.CompareTo(other) > 0;

    /// <summary>
    /// Checks whether the actual value is lower than an other one.
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <param name="other">the other value</param>
    /// <returns>A value indicating whether the actual value is lower than a second value.</returns>
    public static bool IsLowerThan(this long @this, long other) => @this.CompareTo(other) < 0;

    /// <summary>
    /// Compares two values and returns the greater one
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <param name="minimum">the minimum value</param>
    /// <returns>The actual value if its greater than the specified comparison-value. Otherwise it returns the minimum-value.</returns>
    public static long Min(this long @this, long minimum) => @this.IsGreaterThan(minimum) ? @this : minimum;

    /// <summary>
    /// Compares two values and returns the lower one
    /// </summary>
    /// <param name="this">the actual value</param>
    /// <param name="maximum">the maximum value</param>
    /// <returns>The actual value if its lower than the specified comparison-value. Otherwise it returns the maximum-value.</returns>
    public static long Max(this long @this, long maximum) => @this.IsLowerThan(maximum) ? @this : maximum;

    /// <summary>Returns the absolute value of a 64-bit signed integer.</summary>
    /// <param name="this">A number that is greater than <see cref="F:System.Int64.MinValue"></see>, but less than or equal to <see cref="F:System.Int64.MaxValue"></see>.</param>
    /// <returns>A 64-bit signed integer, x, such that 0 ≤ x ≤<see cref="F:System.Int64.MaxValue"></see>.</returns>
    /// <exception cref="T:System.OverflowException"><paramref name="this">value</paramref> equals <see cref="F:System.Int64.MinValue"></see>.</exception>
    public static long Absolute(this long @this) => Math.Abs(@this);
}