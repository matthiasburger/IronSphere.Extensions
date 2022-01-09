using System;
using System.Collections.Generic;

namespace IronSphere.Extensions;

/// <summary>
/// This class provides extension methods for an <see cref="System.Array"/> of <see cref="char"/>
/// </summary>
public static class CharArrayExtension
{
    /// <summary>
    /// Concatenates a sequence of chars to its string representation
    /// </summary>
    /// <param name="this">the actual sequence of chars</param>
    /// <returns>the string representation</returns>
    public static string GetString(this IEnumerable<char>? @this)
    {
        if(@this is null)
            throw new ArgumentNullException(nameof(@this));

        return string.Concat(@this);
    }
}