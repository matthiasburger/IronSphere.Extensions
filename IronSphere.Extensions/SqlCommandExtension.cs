using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

using JetBrains.Annotations;

namespace IronSphere.Extensions
{
    /// <summary>
    /// This class provides extension methods for <see cref="SqlCommand"/>
    /// </summary>
    public static class SqlCommandExtensions
    {
        /// <summary>
        /// Sets the SqlCommands command-text and adds parameters
        /// </summary>
        /// <param name="this">The actual SqlCommand</param>
        /// <param name="command">The command to set</param>
        /// <param name="parameters">The parameters to add as an anonymous object.</param>
        /// <example>
        ///<![CDATA[
        /// SqlCommand command = new SqlCommand();
        /// command.SetCommandText("select * from user where userId = @user", new{user="admin"});
        /// ]]>
        /// </example>
        /// <returns>The modified DbCommand</returns>
        [Obsolete("Is getting removed in v4! Only the method-name changes, use SetCommandWithParameters instead.")]
        public static DbCommand SetCommandText([NotNull]this SqlCommand @this, [NotNull]string command,
            [CanBeNull]object parameters)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            @this.CommandText = command;
            if (parameters == null)
                return @this;

            PropertyInfo[] properties = parameters.GetType().GetProperties();

            foreach (PropertyInfo parameter in properties)
                @this.Parameters.AddWithValue($"@{parameter.Name}", parameter.GetValue(parameters));

            return @this;
        }

        /// <summary>
        /// Sets the SqlCommands command-text and adds parameters
        /// </summary>
        /// <param name="this">The actual SqlCommand</param>
        /// <param name="command">The command to set</param>
        /// <param name="parameters">The parameters to add as a dictionary.</param>
        /// <example>
        ///<![CDATA[
        /// Dictionary<string, object> paramsDictionary = new Dictionary<string, object>(){
        ///     { "user", "admin" }
        /// };
        /// 
        /// SqlCommand command = new SqlCommand();
        /// command.SetCommandText("select * from user where userId = @user", paramsDictionary);
        /// ]]>
        /// </example>
        /// <returns>The modified DbCommand</returns>
        [Obsolete("Is getting removed in v4! Only the method-name changes, use SetCommandWithParameters instead")]
        public static DbCommand SetCommandText([NotNull]this SqlCommand @this, [NotNull]string command,
            [CanBeNull]Dictionary<string, object> parameters)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            if (command is null)
                throw new ArgumentNullException(nameof(command));

            @this.CommandText = command;
            if (parameters == null)
                return @this;

            foreach (KeyValuePair<string, object> pair in parameters)
                @this.Parameters.AddWithValue($"@{pair.Key}", pair.Value);

            return @this;
        }

        /// <summary>
        /// Sets the SqlCommands command-text and adds parameters
        /// </summary>
        /// <param name="this">The actual SqlCommand</param>
        /// <param name="command">The command to set</param>
        /// <param name="parameters">The parameters to add as an anonymous object.</param>
        /// <example>
        ///<![CDATA[
        /// SqlCommand command = new SqlCommand();
        /// command.SetCommandWithParameters("select * from user where userId = @user", new{user="admin"});
        /// ]]>
        /// </example>
        /// <returns>The modified DbCommand</returns>
        public static DbCommand SetCommandWithParameters([NotNull]this SqlCommand @this, [NotNull]string command,
            [CanBeNull]object parameters)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            @this.CommandText = command;
            if (parameters == null)
                return @this;

            PropertyInfo[] properties = parameters.GetType().GetProperties();

            foreach (PropertyInfo parameter in properties)
                @this.Parameters.AddWithValue($"@{parameter.Name}", parameter.GetValue(parameters));

            return @this;
        }

        /// <summary>
        /// Sets the SqlCommands command-text and adds parameters
        /// </summary>
        /// <param name="this">The actual SqlCommand</param>
        /// <param name="command">The command to set</param>
        /// <param name="parameters">The parameters to add as a dictionary.</param>
        /// <example>
        ///<![CDATA[
        /// Dictionary<string, object> paramsDictionary = new Dictionary<string, object>(){
        ///     { "user", "admin" }
        /// };
        /// 
        /// SqlCommand command = new SqlCommand();
        /// command.SetCommandWithParameters("select * from user where userId = @user", paramsDictionary);
        /// ]]>
        /// </example>
        /// <returns>The modified DbCommand</returns>
        public static DbCommand SetCommandWithParameters([NotNull] this SqlCommand @this, [NotNull] string command,
            [CanBeNull] Dictionary<string, object> parameters)
        {
            if (@this is null)
                throw new ArgumentNullException(nameof(@this));

            if (command is null)
                throw new ArgumentNullException(nameof(command));

            @this.CommandText = command;
            if (parameters == null)
                return @this;

            foreach (KeyValuePair<string, object> pair in parameters)
                @this.Parameters.AddWithValue($"@{pair.Key}", pair.Value);

            return @this;
        }
    }
}