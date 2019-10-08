using System;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    public static class GenericArrayExtension
    {
        [NotNull]
        public static T[] Slice<T>([CanBeNull] this T[] items, int startIndex = 0, int? endIndex = null)
        {
            if (startIndex < 0)
                throw new ArgumentException("startIndex must be positive", nameof(startIndex));
            
            if (endIndex.HasValue && startIndex > endIndex)
                throw new ArgumentException("endIndex must be null or lower than startIndex", nameof(startIndex));

            if (items == null)
                return new T[0];

            endIndex = endIndex ?? items.Length;
            int length = endIndex.Value - startIndex;

            T[] result = new T[length];
            Array.Copy(items, startIndex, result, 0, length);
            
            return result;
        }
    }
}
