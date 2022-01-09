using System;

namespace IronSphere.Extensions;

/// <summary>
/// This class provides extension-methods for <see cref="IDisposable"/>
/// </summary>
public static class DisposableExtension
{
    /// <summary>
    /// wrapper for disposing
    /// disposes after execution
    /// </summary>
    /// <typeparam name="T">type of instance of a disposable object</typeparam>
    /// <typeparam name="TResult">type of result</typeparam>
    /// <param name="instance">the disposable object to use in action</param>
    /// <param name="actionToInvoke">the action to invoke that returns the value</param>
    /// <returns></returns>
    public static TResult DisposeAfter<T, TResult>(this T instance, Func<T, TResult> actionToInvoke) where T : IDisposable
    {
        try
        {
            return actionToInvoke(instance);
        }
        finally
        {
            instance.Dispose();
        }
    }
}