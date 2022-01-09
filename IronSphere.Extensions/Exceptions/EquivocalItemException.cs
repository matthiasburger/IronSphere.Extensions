using System;

namespace IronSphere.Extensions.Exceptions;

/// <summary>
/// Throw this exception, if several items were found but only one was expected (e.g. primary key is ambiguous).
/// </summary>
[Serializable]
public class EquivocalItemException : Exception
{
    ///<summary>
    ///</summary>
    public EquivocalItemException() { }
    ///<summary>
    ///</summary>
    ///<param name="message"></param>
    public EquivocalItemException(string message) : base(message) { }
    ///<summary>
    ///</summary>
    ///<param name="message"></param>
    ///<param name="inner"></param>
    public EquivocalItemException(string message, Exception inner) : base(message, inner) { }
}