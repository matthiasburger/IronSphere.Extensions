using System;
using System.Collections.Generic;
using System.Linq;

namespace IronSphere.Extensions;

public static class Toolbox
{
    public static IEnumerable<TEnum> GetEnumValues<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }
}