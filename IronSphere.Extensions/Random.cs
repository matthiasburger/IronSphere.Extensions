using System.Security.Cryptography;

namespace IronSphere.Extensions;

/// <summary>
/// This class provides random-methods
/// </summary>
internal static class Random
{
    /// <summary>
    /// returns a random integer between two integers
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    internal static int NextInt(int min, int max) 
        => RandomNumberGenerator.GetInt32(min, max+1);
}