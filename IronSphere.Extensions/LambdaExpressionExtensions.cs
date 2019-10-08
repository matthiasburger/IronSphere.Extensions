using System;
using System.Linq.Expressions;

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
            _set<T, TValue>(memberLambda, value)?.Compile()(target);
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
    }
}
