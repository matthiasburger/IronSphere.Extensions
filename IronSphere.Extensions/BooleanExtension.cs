namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="bool"/>
    /// </summary>
    public static class BooleanExtension
    {
        /// <summary>
        /// converts a bool to its int-representation
        /// </summary>
        /// <param name="this">the actual boolean value</param>
        /// <returns>1 if value is true, if not then false</returns>
        public static int GetInt(this bool @this) => @this ? 1 : 0;
    }
}
