using System;
using System.Collections.Generic;

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
            
            if (startIndex > endIndex)
                throw new ArgumentException("endIndex must be null or lower than startIndex", nameof(startIndex));

            if (items == null)
                return new T[0];

            endIndex = endIndex ?? items.Length;
            int length = endIndex.Value - startIndex;

            T[] result = new T[length];
            Array.Copy(items, startIndex, result, 0, length);
            
            return result;
        }

        public static IEnumerable<T[]> Subdivide<T>(this T[] @this, int splitAt)
        {
            T[] arrayOfElements = new T[splitAt.Max(@this.Length)];

            for (int index = 0; index < @this.Length; index++)
            {
                if (index != 0 && index % splitAt == 0)
                {
                    yield return arrayOfElements;
                    arrayOfElements = new T[splitAt.Max(@this.Length - index)];
                }

                arrayOfElements[index % splitAt] = @this[index];
            }

            if (arrayOfElements.Length > 0)
                yield return arrayOfElements;
        }
    }
}
