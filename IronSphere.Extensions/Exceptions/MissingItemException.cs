using System;

namespace IronSphere.Extensions.Exceptions;

/// <summary>
/// Throw this exception, if no items was found but minimum one was expected.
/// </summary>
[Serializable]
public class MissingItemException : Exception
{
    ///<summary>
    ///</summary>
    public MissingItemException() { }
    ///<summary>
    ///</summary>
    ///<param name="message"></param>
    public MissingItemException(string message) : base(message) { }
    ///<summary>
    ///</summary>
    ///<param name="message"></param>
    ///<param name="inner"></param>
    public MissingItemException(string message, Exception inner) : base(message, inner) { }
}