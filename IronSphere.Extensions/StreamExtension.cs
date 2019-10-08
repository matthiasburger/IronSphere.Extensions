using System;
using System.IO;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="Stream"/>
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// transforms a stream into the byte-array.
        /// </summary>
        /// <param name="this">The actual stream.</param>
        /// <param name="length">the length of bytes</param>
        /// <returns>The actual stream as a byte-array.</returns>
        public static byte[] GetBytes([NotNull]this Stream @this, int length = 16 * 1024)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "argument length must not be negative"); 

            byte[] buffer = new byte[length];

            using (MemoryStream memoryStream = new MemoryStream())
            {
                int read;
                while ((read = @this.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, read);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Copies all bytes from a <see cref="Stream"/> into a byte-array
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(this Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
