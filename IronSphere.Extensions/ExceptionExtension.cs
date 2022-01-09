using System;

namespace IronSphere.Extensions;

public static class ExceptionExtension
{
    public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName)
        where T : class
    {
        if (obj == null) 
            throw new ArgumentNullException(parameterName);
    }

    public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName, string message) 
        where T : class 
    {
        if (obj == null) 
            throw new ArgumentNullException(parameterName, message);
    }

    public static void ThrowIfArgumentIsNull<T, TInner>(this T obj, string message, TInner innerException) 
        where T : class
        where TInner: Exception
    {
        if (obj == null) 
            throw new ArgumentNullException(message, innerException);
    }
}