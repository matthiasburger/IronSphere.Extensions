#if !NET45
#define Supported
#endif

#if Supported

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using IronSphere.Extensions.Reflection;

namespace IronSphere.Extensions.AspNetCore.Reflection
{
    public static class ConstructorInfoExtension
    {
        /// <summary>
        /// Gets the xml-documentation member-name of a constructor
        /// </summary>
        /// <param name="this">the actual constructor</param>
        /// <returns>A string representing the xml member-name</returns>
        public static string GetXmlMemberName(this ConstructorInfo @this)
        {
            StringBuilder builder = new StringBuilder(@this.DeclaringType.GetXmlMemberName())
                .Append(@this.IsStatic ? ".#cctor" : ".#ctor");

            ParameterInfo[] parameters = @this.GetParameters();
            if (!parameters.Any())
                return builder.ToString();

            IEnumerable<string> c = parameters.Select(x => x.GetParameterString());
            
            return builder.Append($"({string.Join(",", c)})").ToString();
        }

    }
}
#endif