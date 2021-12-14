using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions
{
    public static class GenericArrayExtension
    {
        public static T[] Slice<T>(this T[] items, int startIndex = 0, int? endIndex = null)
        {
            if (startIndex < 0)
                throw new ArgumentException("startIndex must be positive", nameof(startIndex));
            
            if (startIndex > endIndex)
                throw new ArgumentException("endIndex must be null or lower than startIndex", nameof(startIndex));
            
            if (items is not { Length: > 0 })
                return Array.Empty<T>();

            if(startIndex > items.Length)
                return Array.Empty<T>();

            endIndex ??= items.Length;
            int length = endIndex.Value - startIndex;

            T[] result = new T[length];
            Array.Copy(items, startIndex, result, 0, length);
            
            return result;
        }

        public static IEnumerable<T[]> Subdivide<T>(this T[] @this, int splitAt)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            if (splitAt <= 0)
                throw new ArgumentException("splitAt has to be greater than 0 (zero)");
            
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
