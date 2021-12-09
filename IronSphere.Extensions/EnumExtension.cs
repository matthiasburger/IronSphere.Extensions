using System;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension-methods for <see cref="Enum"/>
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Determines whether a flagged enum contains a specific value
        /// </summary>
        /// <typeparam name="T">the type of value</typeparam>
        /// <param name="this">the actual enum</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Has<T>(this Enum @this, T? value)
        {
            if (value is null)
                return false;
            
            try
            {
                return ((int)(object)@this & (int)(object)value) == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether a flagged enum is a specific value
        /// </summary>
        /// <typeparam name="T">the type of value</typeparam>
        /// <param name="this">the actual enum</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Is<T>(this Enum @this, T? value)
        {
            if (value is null)
                return false;
            
            try
            {
                return (int)(object)@this == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a specific value to a flagged enum
        /// </summary>
        /// <typeparam name="T">the type of value</typeparam>
        /// <param name="this">the actual enum</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? Add<T>(this Enum @this, T? value)
        {
            if (value is null)
                return default;
            
            try
            {
                return (T)(object)((int)(object)@this | (int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"Could not append value from enumerated type '{typeof(T).Name}'.", ex);
            }
        }

        /// <summary>
        /// Removes a specific value from a flagged enum
        /// </summary>
        /// <typeparam name="T">the type of value</typeparam>
        /// <param name="this">the actual enum</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? Remove<T>(this Enum @this, T? value)
        {
            if (value is null)
                return default;
            
            try
            {
                return (T)(object)((int)(object)@this & ~(int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"Could not remove value from enumerated type '{typeof(T).Name}'.", ex);
            }
        }
    }
}
