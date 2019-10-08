using System.Text;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for an <see cref="System.Array"/> of <see cref="byte"/>
    /// </summary>
    public static class ByteArrayExtension
    {
        /// <summary>
        /// Decodes all bytes in a specified array into a string.
        /// </summary>
        /// <param name="bytes">Byte-array to decode.</param>
        /// <param name="encoding">Encoding to use for decoding. If none is entered, the default one is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The decoded string.</returns>
        /// <example>
        /// <![CDATA[
        /// const string originalStringValue = "my original value with ä ö and ü";
        /// byte[] originalUtf8Bytes = originalStringValue.GetBytes();
        /// string itsString = originalUtf8Bytes.GetString();
        /// ]]>
        /// </example>
        public static string GetString(this byte[] bytes, Encoding encoding = null) =>
            (encoding ?? Encoding.UTF8).GetString(bytes);
    }
}