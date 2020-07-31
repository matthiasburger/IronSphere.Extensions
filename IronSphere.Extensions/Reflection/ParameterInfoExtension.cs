using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IronSphere.Extensions.Reflection
{
    /// <summary>
    /// This class provides extension methods for <see cref="ParameterInfo"/>
    /// </summary>
    internal static class ParameterInfoExtension
    {
        /// <summary>
        /// Builds a methods parameter-string
        /// </summary>
        /// <param name="this">the actual parameter</param>
        /// <returns>A string representing the code of a parameter</returns>
        public static string GetParameterString(this ParameterInfo @this)
        {
            Type parameterType = @this.ParameterType;

            if (parameterType.IsGenericParameter)
                return $"{(parameterType.IsGenericMethodParameter() ? "``" : "`")}{parameterType.GenericParameterPosition}";

            if (!parameterType.IsGenericType)
                return parameterType.FullName;

            IEnumerable<string> args = parameterType.GetGenericArguments().Select(BuildGenericArgument);
            return $"{parameterType.GetNonGenericTypeName()}{{{string.Join(",", args)}}}";
        }

        private static string BuildGenericArgument(Type type)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (type.IsGenericType)
            {
                stringBuilder.Append(type.GetNonGenericTypeName() + "{");
                IList<string> listOfArgs = type.GetGenericArguments().Select(BuildGenericArgument).ToList();
                stringBuilder.Append(string.Join(",", listOfArgs)).Append("}");
            }
            else
            {
                if (type.IsGenericMethodParameter())
                    stringBuilder.Append($"``{type.GenericParameterPosition}");
                else if (type.IsGenericTypeParameter())
                    stringBuilder.Append($"`{type.GenericParameterPosition}");
                else
                    stringBuilder.Append(type.FullName);
            }

            return stringBuilder.ToString();
        }
    }
}
