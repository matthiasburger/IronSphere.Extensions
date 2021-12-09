#nullable disable
#nullable disable warnings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using IronSphere.Extensions.Reflection;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension-methods for working with <see cref="LambdaExpression"/>
    /// </summary>
    public static class LambdaExpressionExtensions
    {
        /// <summary>
        /// Sets an objects property to a value by using <see cref="LambdaExpression"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target"></param>
        /// <param name="memberLambda"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue<T, TValue>(this T target, LambdaExpression memberLambda, TValue value)
        {
            _set<T, TValue>(memberLambda, value).Compile()(target);
        }

        /// <summary>
        /// Sets an objects property to a value by using an <see cref="Expression"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target"></param>
        /// <param name="expression"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T, TValue>> expression, TValue value)
        {
            LambdaExpression lambdaExpression = Expression.Lambda(expression);
            _set<T, TValue>(lambdaExpression, value).Compile()(target);
        }

        private static Expression<Action<TEntity>> _set<TEntity, TValue>(LambdaExpression propertyGetExpression, TValue valueExpression)
        {
            if ((object)valueExpression == DBNull.Value)
                return null;

            ParameterExpression entityParameterExpression = (ParameterExpression)((MemberExpression)propertyGetExpression.Body).Expression;
            Expression value = Expression.Constant(valueExpression);

            return Expression.Lambda<Action<TEntity>>(
                Expression.Assign(propertyGetExpression.Body, value),
                entityParameterExpression);
        }

        /// <summary>
        /// converts a lambda-expression to a readable string-representation
        /// basic expressions are nearly like the written ones, complex expressions may differ 
        /// not all expression-types are completely implemented (and perhaps won't be readable at all) 
        /// </summary>
        /// <param name="this">the actual expression</param>
        /// <returns>a string representation for the expression</returns>
        public static string GetReadableExpressionBody(this LambdaExpression @this)
        {
            return $"({string.Join(", ", @this.Parameters.Select(_getReadableExpressionBody))}) => {_getReadableExpressionBody(@this.Body)}";
        }

        private static string _getReadableExpressionBody(Expression expression)
        {
            switch (expression)
            {
                case MemberExpression m:
                    if (_isStaticMember(m.Member))
                        return $"{m.Member.DeclaringType?.GetShortReadableName()}.{m.Member.Name}";
                    string expressionBody = _getReadableExpressionBody(m.Expression);
                    return expressionBody != null ? $"{expressionBody}.{m.Member.Name}" : m.Member.Name;
                case UnaryExpression { Operand: MemberExpression m }:
                    return _getReadableExpressionBody(m);
                case BinaryExpression b:
                    return $"({_getReadableExpressionBody(b.Left)} {_getReadableNodeType(b.NodeType, _getReadableExpressionBody(b.Right))})";
                case ConstantExpression c:
                    return _getValueOfConstantExpression(c);
                case UnaryExpression u:
                    return _getReadableNodeType(u.NodeType, _getReadableExpressionBody(u.Operand));
                case ParameterExpression p:
                    return p.Name;
                case ConditionalExpression b:
                    return $"{_getReadableExpressionBody(b.Test)} ? {_getReadableExpressionBody(b.IfTrue)} : {_getReadableExpressionBody(b.IfFalse)}";
                case MethodCallExpression b:
                    return _getReadableMethodCallExpression(b);
                case TypeBinaryExpression b:
                    return $"{_getReadableExpressionBody(b.Expression)} {_getReadableNodeType(b.NodeType, b.TypeOperand.GetShortReadableName())}";
                case ListInitExpression b:
                    List<List<string>> initializerExpressions = b.Initializers
                        .Select(elementInit => 
                            elementInit.Arguments.Select(_getReadableExpressionBody).ToList()
                            ).ToList();
                    return _getReadableNodeType(b.NodeType, _getReadableExpressionBody(b.NewExpression)) + "{" + string.Join(", ", initializerExpressions.Select(x => $"{{{string.Join(", ", x)}}}")) + "}";
                case NewArrayExpression b:
                    return _getReadableNodeType(b.NodeType, string.Join(", ", b.Expressions.Select(_getReadableExpressionBody)));
                case NewExpression b:
                    string typeName = b.Type.GetShortReadableName();
                    return _getReadableNodeType(b.NodeType, typeName + "(" + string.Join(", ", b.Arguments.Select(_getReadableExpressionBody)) + ")");
                case InvocationExpression b:
                    return _getReadableNodeType(b.NodeType, _getReadableExpressionBody(b.Expression) + "(" + string.Join(", ", b.Arguments.Select(_getReadableExpressionBody)) + ")");

                case LoopExpression b: return b.ToString();
                case MemberInitExpression b: return b.ToString();
                case DynamicExpression b: return b.ToString();
                case BlockExpression b: return b.ToString();
                case LambdaExpression b: return b.ToString();
                case RuntimeVariablesExpression b: return b.ToString();
                case DebugInfoExpression b: return b.ToString();
                case DefaultExpression b: return b.ToString();
                case GotoExpression b: return b.ToString();
                case IndexExpression b: return b.ToString();
                case LabelExpression b: return b.ToString();
                case SwitchExpression b: return b.ToString();
                case TryExpression b: return b.ToString();
            }

            return expression.ToString();
        }

        private static string _getReadableMethodCallExpression(MethodCallExpression b)
        {
            string invoking = b.Method.IsStatic
                ? b.Method.DeclaringType?.GetShortReadableName()
                : _getReadableExpressionBody(b.Object);

            if (b.Method.IsExtensionMethod())
            {
                IEnumerable<string> arguments = b.Arguments.Select(_getReadableExpressionBody).ToList();

                return
                    $"{arguments.First()}.{b.Method.Name}({string.Join(", ", arguments.Skip(1))})";
            }

            if (b.Method.IsIndexerPropertyMethod())
                return $"{invoking}[{string.Join(", ", b.Arguments.Select(_getReadableExpressionBody))}]";
            return $"{invoking}.{b.Method.Name}({string.Join(", ", b.Arguments.Select(_getReadableExpressionBody))})";
        }

        private static bool _isStaticMember(MemberInfo memberInfo)
        {
            return memberInfo is PropertyInfo member && member.GetMethod.IsStatic
                   || memberInfo is FieldInfo { IsStatic: true } or MethodBase { IsStatic: true } or FieldInfo { IsStatic: true };
        }

        private static string _getValueOfConstantExpression(ConstantExpression constantExpression)
        {
            switch (constantExpression.Value)
            {
                case string value:
                    return $"\"{value}\"";
                case char value:
                    return $"'{value}'";
                case decimal value:
                    return $"{value}m";
                case float value:
                    return $"{value}f";
                case double value:
                    return $"{value}d";
                case long value:
                    return $"{value}L";
                case uint value:
                    return $"{value}U";
                case ulong value:
                    return $"{value}UL";
            }

            Type expressionType = constantExpression.Value.GetType();
            if (expressionType.IsValueType)
                return constantExpression.Value.ToString();

            string classType = expressionType.GetShortReadableName();
            return classType.StartsWith("<>") ? null : classType;
        }


        private static string _getReadableNodeType(ExpressionType type, string value)
        {
            switch (type)
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    return $"+ {value}";
                case ExpressionType.And:
                    return $"& {value}";
                case ExpressionType.AndAlso:
                    return $"&& {value}";
                case ExpressionType.ArrayLength:
                    break;
                case ExpressionType.ArrayIndex:
                    return $"[{value}]";
                case ExpressionType.Call:
                    break;
                case ExpressionType.Coalesce:
                    return $"?? {value}";
                case ExpressionType.Conditional:
                    break;
                case ExpressionType.Constant:
                    break;
                case ExpressionType.Convert:
                    break;
                case ExpressionType.ConvertChecked:
                    break;
                case ExpressionType.Divide:
                    break;
                case ExpressionType.Equal:
                    return $"== {value}";
                case ExpressionType.ExclusiveOr:
                    return $"^ {value}";
                case ExpressionType.GreaterThan:
                    return $"> {value}";
                case ExpressionType.GreaterThanOrEqual:
                    return $">= {value}";
                case ExpressionType.Invoke:
                    return $"{value}";
                case ExpressionType.Lambda:
                    break;
                case ExpressionType.LeftShift:
                    break;
                case ExpressionType.LessThan:
                    return $"< {value}";
                case ExpressionType.LessThanOrEqual:
                    return $"<= {value}";
                case ExpressionType.ListInit:
                    return $"{value}";
                case ExpressionType.MemberAccess:
                    break;
                case ExpressionType.MemberInit:
                    break;
                case ExpressionType.Modulo:
                    return $"% {value}";
                case ExpressionType.Multiply:
                    break;
                case ExpressionType.MultiplyChecked:
                    break;
                case ExpressionType.Negate:
                    break;
                case ExpressionType.UnaryPlus:
                    break;
                case ExpressionType.NegateChecked:
                    break;
                case ExpressionType.New:
                    return $"new {value}";
                case ExpressionType.NewArrayInit:
                    return $"new []{{{value}}}";
                case ExpressionType.NewArrayBounds:
                    break;
                case ExpressionType.Not:
                    return $"! {value}";
                case ExpressionType.NotEqual:
                    return $"!= {value}";
                case ExpressionType.Or:
                    return $"| {value}";
                case ExpressionType.OrElse:
                    return $"|| {value}";
                case ExpressionType.Parameter:
                    break;
                case ExpressionType.Power:
                    break;
                case ExpressionType.Quote:
                    break;
                case ExpressionType.RightShift:
                    break;
                case ExpressionType.Subtract:
                    break;
                case ExpressionType.SubtractChecked:
                    break;
                case ExpressionType.TypeAs:
                    break;
                case ExpressionType.TypeIs:
                    return $"is {value}";
                case ExpressionType.Assign:
                    return $"= {value}";
                case ExpressionType.Block:
                    break;
                case ExpressionType.DebugInfo:
                    break;
                case ExpressionType.Decrement:
                    return $"- {value}";
                case ExpressionType.Dynamic:
                    break;
                case ExpressionType.Default:
                    break;
                case ExpressionType.Extension:
                    break;
                case ExpressionType.Goto:
                    break;
                case ExpressionType.Increment:
                    return $"++ {value}";
                case ExpressionType.Index:
                    break;
                case ExpressionType.Label:
                    break;
                case ExpressionType.RuntimeVariables:
                    break;
                case ExpressionType.Loop:
                    break;
                case ExpressionType.Switch:
                    break;
                case ExpressionType.Throw:
                    break;
                case ExpressionType.Try:
                    break;
                case ExpressionType.Unbox:
                    break;
                case ExpressionType.AddAssign:
                    return $"+= {value}";
                case ExpressionType.AndAssign:
                    break;
                case ExpressionType.DivideAssign:
                    break;
                case ExpressionType.ExclusiveOrAssign:
                    break;
                case ExpressionType.LeftShiftAssign:
                    break;
                case ExpressionType.ModuloAssign:
                    break;
                case ExpressionType.MultiplyAssign:
                    break;
                case ExpressionType.OrAssign:
                    return $"|= {value}";
                case ExpressionType.PowerAssign:
                    break;
                case ExpressionType.RightShiftAssign:
                    break;
                case ExpressionType.SubtractAssign:
                    break;
                case ExpressionType.AddAssignChecked:
                    break;
                case ExpressionType.MultiplyAssignChecked:
                    break;
                case ExpressionType.SubtractAssignChecked:
                    break;
                case ExpressionType.PreIncrementAssign:
                    break;
                case ExpressionType.PreDecrementAssign:
                    break;
                case ExpressionType.PostIncrementAssign:
                    break;
                case ExpressionType.PostDecrementAssign:
                    break;
                case ExpressionType.TypeEqual:
                    break;
                case ExpressionType.OnesComplement:
                    break;
                case ExpressionType.IsTrue:
                    break;
                case ExpressionType.IsFalse:
                    break;
                default:
                    return $"{type} {value}";
            }
            return $"{type} {value}";
        }
    }
}