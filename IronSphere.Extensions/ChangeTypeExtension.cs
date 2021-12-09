using System;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension-methods for changing types
    /// </summary>
    public static class ChangeTypeExtension
    {
        /// <summary>
        /// converts any object to type of T
        /// </summary>
        /// <typeparam name="T">the target type</typeparam>
        /// <param name="this">the actual value</param>
        /// <returns>the converted object</returns>
        public static T? To<T>(this object? @this)
        {
            Type? nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(T));

            if (nullableUnderlyingType != null && @this is null)
                return default;

            return (T)Convert.ChangeType(@this, nullableUnderlyingType ?? typeof(T));
        }

        /// <summary>
        /// converts any object to type of T
        /// </summary>
        /// <typeparam name="T">the target type</typeparam>
        /// <param name="this">the actual value</param>
        /// <param name="default">the default-value if conversion threw an exception</param>
        /// <returns>the converted object</returns>
        public static T? ToOrDefault<T>(this object? @this, T? @default = default)
        {
            try
            {
                Type? nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(T));

                if (nullableUnderlyingType != null && @this is null)
                    return default;

                return (T)Convert.ChangeType(@this, nullableUnderlyingType ?? typeof(T));
            }
            catch (Exception e) when (e is FormatException or InvalidCastException)
            {
                return @default;
            }
        }

        /// <summary>
        /// converts any object to type of T
        /// </summary>
        /// <typeparam name="T">the target type</typeparam>
        /// <param name="this">the actual value</param>
        /// <returns>the converted object or null if conversion threw an exception</returns>
        public static T? ToOrNull<T>(this object @this) where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(@this, typeof(T));
            }
            catch (Exception e) when (e is FormatException or InvalidCastException)
            {
                return null;
            }
        }

        public static bool Is<T>(this object item) where T : class
        {
            return item is T;
        }

        public static bool IsNot<T>(this object item) where T : class
        {
            return item is not T;
        }

        public static T? As<T>(this object item) where T : class
        {
            return item as T;
        }
    }
}
