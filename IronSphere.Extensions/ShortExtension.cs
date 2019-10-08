// ReSharper disable MemberCanBePrivate.Global

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="short"/>
    /// </summary>
    public static class ShortExtension
    {
        /// <summary>
        /// Checks whether the actual value is between specified lower and higher.
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <param name="lower">the lower value</param>
        /// <param name="higher">the higher value</param>
        /// <returns>A value indicating whether the actual value is between two values.</returns>
        public static bool Between(this short @this, short lower, short higher) =>
            @this.CompareTo(lower) > 0 && @this.CompareTo(higher) < 0;

        /// <summary>
        /// Checks whether the actual value is greater than zero.
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <returns>A value indicating whether the actual value is positive.</returns>
        public static bool IsPositive(this short @this) => @this.CompareTo(0) > 0;

        /// <summary>
        /// Checks whether the actual value is smaller than zero.
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <returns>A value indicating whether the actual value is negative.</returns>
        public static bool IsNegative(this short @this) => @this.CompareTo(0) < 0;

        /// <summary>
        /// Checks whether the actual value is equal to zero.
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <returns>A value indicating whether the actual value is equal to zero.</returns>
        public static bool IsZero(this short @this) => @this.CompareTo(0) == 0;

        /// <summary>
        /// Checks whether the actual value is greater than an other one.
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <param name="other">the other value</param>
        /// <returns>A value indicating whether the actual value is greater than a second value.</returns>
        public static bool IsGreaterThan(this short @this, short other) => @this.CompareTo(other) > 0;

        /// <summary>
        /// Checks whether the actual value is lower than an other one.
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <param name="other">the other value</param>
        /// <returns>A value indicating whether the actual value is lower than a second value.</returns>
        public static bool IsLowerThan(this short @this, short other) => @this.CompareTo(other) < 0;

        /// <summary>
        /// Compares two values and returns the greater one
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <param name="minimum">the minimum value</param>
        /// <returns>The actual value if its greater than the specified comparison-value. Otherwise it returns the minimum-value.</returns>
        public static short Min(this short @this, short minimum) => @this.IsGreaterThan(minimum) ? @this : minimum;

        /// <summary>
        /// Compares two values and returns the lower one
        /// </summary>
        /// <param name="this">the actual value</param>
        /// <param name="maximum">the maximum value</param>
        /// <returns>The actual value if its lower than the specified comparison-value. Otherwise it returns the maximum-value.</returns>
        public static short Max(this short @this, short maximum) => @this.IsLowerThan(maximum) ? @this : maximum;
    }
}
