using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace IronSphere.Extensions.Reflection
{
    /// <summary>
    /// This class provides extension methods for <see cref="MethodInfo"/>
    /// </summary>
    public static class MethodInfoExtension
    {
        /// <summary>
        /// Gets the xml-documentation member-name of a method
        /// </summary>
        /// <param name="this">the actual method</param>
        /// <returns>A string representing the xml member-name</returns>
        public static string GetXmlMemberName(this MethodInfo @this)
        {
            Type[] genericMethodArguments = @this.IsGenericMethod ? @this.GetGenericArguments() : Type.EmptyTypes;
            IEnumerable<string?> c = @this.GetParameters().Select(x => x.GetParameterString());

            return new StringBuilder(@this.DeclaringType?.GetXmlMemberName())
                .Append($".{@this.Name}")
                .Append(@this.IsGenericMethod ? $"``{genericMethodArguments.Length}" : string.Empty)
                .Append($"({string.Join(",", c)})").ToString();
        }

        /// <summary>
        /// Indicated whether a method is an extension-method
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsExtensionMethod(this MethodInfo @this)
        {
           return @this.GetCustomAttributes<ExtensionAttribute>().Any();
        }


        public static bool IsIndexerPropertyMethod(this MethodInfo method)
        {
            Type? declaringType = method.DeclaringType;
            if (declaringType is null) return false;
            PropertyInfo? indexerProperty = GetIndexerProperty(declaringType);
            if (indexerProperty is null) return false;
            return method == indexerProperty.GetMethod || method == indexerProperty.SetMethod;
        }

        private static PropertyInfo? GetIndexerProperty(this Type type)
        {
            DefaultMemberAttribute? defaultPropertyAttribute = type.GetCustomAttributes<DefaultMemberAttribute>()
                .FirstOrDefault();
            if (defaultPropertyAttribute is null) return null;
            return type.GetProperty(defaultPropertyAttribute.MemberName, 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

    }
}
