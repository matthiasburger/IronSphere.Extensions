using System;
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
    {
        using RNGCryptoServiceProvider cryptoServiceProvider = new();
        byte[] buffer = new byte[4];

        cryptoServiceProvider.GetBytes(buffer);
        int result = BitConverter.ToInt32(buffer, 0);

        return new System.Random(result).Next(min, max);
    }
}