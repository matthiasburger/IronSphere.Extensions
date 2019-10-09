#if !NET45
#define Supported
#endif

#if Supported

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IronSphere.Extensions.Reflection;

namespace IronSphere.Extensions.AspNetCore.Reflection
{
    public static class MethodInfoExtension
    {
        /// <summary>
        /// Gets the xml-documentation member-name of a method
        /// </summary>
        /// <param name="this">the actual method</param>
        /// <returns>A string representing the xml member-name</returns>
        public static string GetXmlMemberName(this MethodBase @this)
        {
            Type[] genericMethodArguments = @this.IsGenericMethod ? @this.GetGenericArguments() : new Type[0];
            IEnumerable<string> c = @this.GetParameters().Select(x => x.GetParameterString());

            return new StringBuilder(@this.DeclaringType.GetXmlMemberName())
                .Append($".{@this.Name}")
                .Append(@this.IsGenericMethod ? $"``{genericMethodArguments.Length}" : string.Empty)
                .Append($"({string.Join(",", c)})").ToString();
        }

    }
}
#endif