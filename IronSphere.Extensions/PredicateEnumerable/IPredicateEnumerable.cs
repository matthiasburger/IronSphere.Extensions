using System;
using System.Collections.Generic;

namespace IronSphere.Extensions.PredicateEnumerable
{
    /// <summary>
    /// ITD with v4
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPredicateEnumerable<out T> : IEnumerable<T>
    {
        /// <summary>
        /// ITD with v4
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> If(Func<IEnumerable<T>, T, bool> expression);
    }
}