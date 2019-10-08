using System.Collections.Generic;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This interface is used by LexJoin-methods
    /// </summary>
    /// <typeparam name="TMain"></typeparam>
    /// <typeparam name="TSub"></typeparam>
    public interface IJoinSet<out TMain, out TSub>
    {
        /// <summary>
        /// Gets the main-object of join
        /// </summary>
        TMain Main { get; }

        /// <summary>
        /// Gets a sub-elements-collection from main
        /// </summary>
        IEnumerable<TSub> Sub { get; }
    }
}