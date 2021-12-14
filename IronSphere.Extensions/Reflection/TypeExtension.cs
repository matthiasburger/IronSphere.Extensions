using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace IronSphere.Extensions.Reflection
{
    /// <summary>
    /// This class provides extension methods for <see cref="Type"/>
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Gets the types readable name 
        /// </summary>
        /// <example>
        /// <![CDATA[
        ///     Dictionary<Int32,String>
        ///     // or
        ///     Dictionary<TKey,TValue>
        /// ]]>
        /// </example>
        /// <param name="this">the actual type</param>
        /// <returns></returns>
        public static string GetReadableName(this Type @this) => _getReadableName(@this);

        /// <summary>
        /// Gets the types full readable name
        /// </summary>
        /// <example>
        /// <![CDATA[
        ///     System.Collections.Generic.Dictionary<System.Int32,System.String>
        ///     // or
        ///     System.Collections.Generic.Dictionary<TKey,TValue>
        /// ]]>
        /// </example>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string? GetFullReadableName(this Type @this) => _getFullReadableName(@this);

        private static string? _getFullReadableName(Type type)
        {
            if (type.IsGenericType)
                return type.IsGenericTypeDefinition
                    ? _getGenericTypeDefinitionFullReadableName(type)
                    : _getGenericTypeFullReadableName(type);

            return type.FullName;
        }

        private static string _getGenericTypeDefinitionFullReadableName(Type t)
        {
            Stack<(Type type, Type[] genericArguments)> stack = GetDeclaringGenericStack(t);

            StringBuilder memberName = new(t.Namespace is null ? string.Empty : $"{t.Namespace}.");

            HashSet<string> takenTypes = new();

            while (stack.Any())
            {
                (Type type, Type[] genericArguments) = stack.Pop();

                string typeName = type.Name.Split('`').First();

                IList<string> genericsToAdd = new List<string>();
                foreach (Type arg in genericArguments)
                {
                    if (takenTypes.Contains(arg.Name))
                        continue;

                    string argument = _getGenericArgumentString(arg);

                    takenTypes.Add(arg.Name);
                    genericsToAdd.Add(argument);
                }

                memberName.Append(genericsToAdd.Count > 0 ? $"{typeName}<{string.Join(",", genericsToAdd)}>." : $"{typeName}.");
            }

            return memberName.ToString().TrimEnd('.');
        }

        private static string _getGenericArgumentString(Type arg)
        {
            string argument = arg.Name;

            switch (arg.GenericParameterAttributes)
            {
                case GenericParameterAttributes.Contravariant:
                    return $"in {argument}";
                case GenericParameterAttributes.Covariant:
                    return $"out {argument}";
                case GenericParameterAttributes.None:
                    break;
                case GenericParameterAttributes.VarianceMask:
                    break;
                case GenericParameterAttributes.SpecialConstraintMask:
                    break;
                case GenericParameterAttributes.ReferenceTypeConstraint:
                    break;
                case GenericParameterAttributes.NotNullableValueTypeConstraint:
                    break;
                case GenericParameterAttributes.DefaultConstructorConstraint:
                    break;
                default: return argument;
            }

            return string.Empty;
        }

        private static string _getGenericTypeFullReadableName(Type t)
        {
            Type declaringType = t.GetGenericTypeDefinition();

            Dictionary<int, Type> dictionaryOfTypes = t.GetGenericArguments()
                .Select((x, y) => new { x, y })
                .ToDictionary(y => y.y, x => x.x);

            Stack<(Type type, Type[] genericArguments)> stack = GetDeclaringGenericStack(declaringType);

            StringBuilder memberName = new(t.Namespace is null ? string.Empty : $"{t.Namespace}.");

            HashSet<string> takenTypes = new();
            int typeCount = 0;

            while (stack.Any())
            {
                (Type type, Type[] genericArguments) = stack.Pop();

                string typeName = type.Name.Split('`').First();

                IList<string?> genericsToAdd = new List<string?>();
                foreach (Type arg in genericArguments)
                {
                    if (takenTypes.Contains(arg.Name))
                        continue;

                    string? argument = _getFullReadableName(dictionaryOfTypes[typeCount++]);

                    takenTypes.Add(arg.Name);
                    genericsToAdd.Add(argument);
                }

                memberName.Append(genericsToAdd.Count > 0 ? $"{typeName}<{string.Join(",", genericsToAdd)}>." : $"{typeName}.");
            }

            return memberName.ToString().TrimEnd('.');
        }

        private static string _getReadableName(Type type)
        {
            if (type.IsAnonymousType())
                return "AnonymousType";

            if (type.IsGenericType)
                return type.IsGenericTypeDefinition
                    ? _getGenericTypeDefinitionReadableName(type)
                    : _getGenericTypeReadableName(type);

            return type.Name;
        }

        private static string _getGenericTypeDefinitionReadableName(Type t)
        {
            Stack<(Type type, Type[] genericArguments)> stack = GetDeclaringGenericStack(t);

            IList<string> memberNames = new List<string>();

            HashSet<string> takenTypes = new();

            while (stack.Any())
            {
                (Type type, Type[] genericArguments) = stack.Pop();

                IList<string> genericsToAdd = new List<string>();
                foreach (Type arg in genericArguments)
                {
                    if (takenTypes.Contains(arg.Name))
                        continue;

                    string argument = _getGenericArgumentString(arg);

                    takenTypes.Add(arg.Name);
                    genericsToAdd.Add(argument);
                }

                string typeName = type.Name.Split('`').First();
                memberNames.Add(genericsToAdd.Count > 0 ? $"{typeName}<{string.Join(",", genericsToAdd)}>" : typeName);
            }

            return string.Join(".", memberNames);
        }

        private static string _getGenericTypeReadableName(Type t)
        {
            Type declaringType = t.GetGenericTypeDefinition();

            Dictionary<int, Type> dictionaryOfTypes = t.GetGenericArguments()
                .Select((x, y) => new { x, y })
                .ToDictionary(y => y.y, x => x.x);

            Stack<(Type type, Type[] genericArguments)> stack = GetDeclaringGenericStack(declaringType);

            IList<string> memberNames = new List<string>();
            HashSet<string> takenTypes = new();
            int typeCount = 0;

            while (stack.Any())
            {
                (Type type, Type[] genericArguments) = stack.Pop();

                IList<string> genericsToAdd = new List<string>();
                foreach (Type arg in genericArguments)
                {
                    if (takenTypes.Contains(arg.Name))
                        continue;

                    string argument = _getReadableName(dictionaryOfTypes[typeCount++]);

                    takenTypes.Add(arg.Name);
                    genericsToAdd.Add(argument);
                }

                string typeName = type.Name.Split('`').First();

                memberNames.Add(genericsToAdd.Count > 0 ? $"{typeName}<{string.Join(",", genericsToAdd)}>" : typeName);
            }

            return string.Join(".", memberNames);
        }

        /// <summary>
        /// Gets the xml-documentation member name for a type
        /// </summary>
        /// <param name="this">the actual type</param>
        /// <returns></returns>
        public static string GetXmlMemberName(this Type @this)
        {
            Type? declaringType = @this;

            Stack<string> stack = new();
            while (declaringType != null)
            {
                stack.Push(declaringType.Name);
                declaringType = declaringType.DeclaringType;
            }

            StringBuilder memberName = new(@this.Namespace is null ? string.Empty : $"{@this.Namespace}.");

            while (stack.Any())
                memberName.Append($"{stack.Pop()}.");

            return memberName.ToString().TrimEnd('.');
        }

        /// <summary>
        /// Gets the short readable name of a type, it doesn't add outer classes for nested types
        /// </summary>
        /// <param name="this">the actual type</param>
        /// <returns></returns>
        public static string? GetShortReadableName(this Type @this) => _getShortReadableName(@this);
        
        private static string? _getShortReadableName(Type type)
        {
            if (type.IsAnonymousType())
                return "AnonymousType";

            if (type.IsGenericType)
                return type.IsGenericTypeDefinition
                    ? _getGenericTypeDefinitionShortReadableName(type)
                    : _getGenericTypeShortReadableName(type);

            return type.Name;
        }

        private static string? _getGenericTypeDefinitionShortReadableName(Type t)
        {
            Stack<(Type type, Type[] genericArguments)> stack = GetDeclaringGenericStack(t);

            string? memberName = null;

            HashSet<string> takenTypes = new();

            while (stack.Any())
            {
                (Type type, Type[] genericArguments) = stack.Pop();

                string typeName = type.Name.Split('`').First();

                IList<string> genericsToAdd = new List<string>();
                foreach (Type arg in genericArguments)
                {
                    string argument = arg.Name;

                    if (takenTypes.Contains(argument))
                        continue;

                    takenTypes.Add(argument);
                    genericsToAdd.Add(argument);
                }

                memberName = $"{typeName}<{string.Join(",", genericsToAdd)}>";
            }

            return memberName;
        }

        private static string? _getGenericTypeShortReadableName(Type t)
        {
            Type declaringType = t.GetGenericTypeDefinition();

            Dictionary<int, Type> dictionaryOfTypes = t.GetGenericArguments()
                .Select((x, y) => new { x, y })
                .ToDictionary(y => y.y, x => x.x);

            Stack<(Type type, Type[] genericArguments)> stack = GetDeclaringGenericStack(declaringType);

            string? memberName = null;

            HashSet<string> takenTypes = new();
            int typeCount = 0;

            while (stack.Any())
            {
                (Type type, Type[] genericArguments) = stack.Pop();

                string typeName = type.Name.Split('`').First();

                IList<string?> genericsToAdd = new List<string?>();
                foreach (Type arg in genericArguments)
                {
                    if (takenTypes.Contains(arg.Name))
                        continue;

                    string? argument = _getShortReadableName(dictionaryOfTypes[typeCount++]);

                    takenTypes.Add(arg.Name);
                    genericsToAdd.Add(argument);
                }

                memberName = $"{typeName}<{string.Join(",", genericsToAdd)}>";
            }

            return memberName;
        }

        private static Stack<(Type type, Type[] genericArguments)> GetDeclaringGenericStack(Type type)
        {
            Type? declaringType = type;

            Stack<(Type type, Type[] genericArguments)> stack = new();
            while (declaringType != null)
            {
                stack.Push((declaringType, declaringType.GetGenericArguments()));
                declaringType = declaringType.DeclaringType;
            }

            return stack;
        }

        /// <summary>
        /// Gets the non-generic name for a type
        /// </summary>
        /// <example>
        /// <![CDATA[
        ///     string x = typeof(Dictionary<int, string>).GetNonGenericTypeName();
        ///     bool isTrue = x == "System.Collections.Generic.Dictionary";
        /// ]]>
        /// </example>
        /// <param name="this">the actual type</param>
        /// <returns></returns>
        public static string? GetNonGenericTypeName(this Type @this)
        {
            return (@this.FullName ?? @this.GetGenericTypeDefinition().FullName)?.Split('`').FirstOrDefault();
        }

        /// <summary>
        /// determines if a type is anonymous
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAnonymousType(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && ( type.Name.Contains("AnonymousType") ||  type.Name.Contains("AnonType"))
                   && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                   && type.Attributes.HasFlag(TypeAttributes.NotPublic);
        }

        internal static bool IsGenericTypeParameter(this Type @this)
        {
            return @this.IsGenericParameter && @this.DeclaringMethod is null;
        }
        internal static bool IsGenericMethodParameter(this Type @this)
        {
            return @this.IsGenericParameter && @this.DeclaringMethod != null;
        }

        public static bool IsNullableType(this Type @this)
        {
            return @this.IsGenericType && @this.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type? GetNullableUnderlyingType(this Type @this)
        {
            return Nullable.GetUnderlyingType(@this);
        }
    }
}