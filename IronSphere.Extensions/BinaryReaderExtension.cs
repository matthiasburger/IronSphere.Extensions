using System.IO;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="BinaryReader"/>
    /// </summary>
    public static class BinaryReaderExtension
    {
        /// <summary>
        /// Reads all bytes and writes them into an array
        /// </summary>
        /// <param name="reader">the actual binary-reader object</param>
        /// <returns>the result of bytes</returns>
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            const int bufferSize = 4096;
            
            using MemoryStream ms = new();
            
            byte[] buffer = new byte[bufferSize];
            int count;
            while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                ms.Write(buffer, 0, count);
            return ms.ToArray();
        }
    }
}
