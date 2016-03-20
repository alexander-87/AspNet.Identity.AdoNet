namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>Base class for objects that encapsulate database table access.</summary>
    public abstract class Table
    {
        readonly IIdentityDbContext dbContext;

        /// <summary>
        ///     Creates a new instance of the <see cref="Table"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="dbContext"/> parameter is <c>null</c>.
        /// </exception>
        protected internal Table(IIdentityDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this.dbContext = dbContext;
        }

        /// <summary>Gets the currently configured <see cref="IIdentityDbContext"/>.</summary>
        protected IIdentityDbContext DbContext => dbContext;

        /// <summary>
        ///     Executes a <see cref="DatabaseCommand"/> against the <see cref="IDbConnection"/>
        ///     created via the <see cref="DbContext"/>, and returns the number of rows affected.
        /// </summary>
        /// <param name="databaseCommand">The <see cref="DatabaseCommand"/> to execute.</param>
        /// <param name="callingMethodName">
        ///     There is no need to specify a value for this parameter;
        ///     it will automatically be set to the calling method's name.
        /// </param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the <paramref name="databaseCommand"/> parameter is <c>null</c>.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Only way to use the CallerMemberName attribute.")]
        protected int ExecuteNonQuery(DatabaseCommand databaseCommand, [CallerMemberName] string callingMethodName = "")
        {
            return ExecuteNonQuery(databaseCommand, null, callingMethodName);
        }

        /// <summary>
        ///     Executes a <see cref="DatabaseCommand"/> against the <see cref="IDbConnection"/>
        ///     created via the <see cref="DbContext"/>, and returns the number of rows affected.
        /// </summary>
        /// <param name="databaseCommand">The <see cref="DatabaseCommand"/> to execute.</param>
        /// <param name="parameterValues">Parameter values to use when executing the command.</param>
        /// <param name="callingMethodName">
        ///     There is no need to specify a value for this parameter;
        ///     it will automatically be set to the calling method's name.
        /// </param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the <paramref name="databaseCommand"/> parameter is <c>null</c>.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Only way to use the CallerMemberName attribute.")]
        protected int ExecuteNonQuery(DatabaseCommand databaseCommand, IDictionary<string, object> parameterValues, [CallerMemberName] string callingMethodName = "")
        {
            ThrowExceptionIfDatabaseCommandIsNull(databaseCommand, callingMethodName);

            using (var connection = DbContext.CreateDbConnection())
            using (var command = CreateIDbCommand(connection, databaseCommand, parameterValues))
                return command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Executes a <see cref="DatabaseCommand"/> against the <see cref="IDbConnection"/>
        ///     created via the <see cref="DbContext"/>, and returns a <see cref="DataTable"/>
        ///     containing the results of the query.
        /// </summary>
        /// <param name="databaseCommand">The <see cref="DatabaseCommand"/> to execute.</param>
        /// <param name="callingMethodName">
        ///     There is no need to specify a value for this parameter;
        ///     it will automatically be set to the calling method's name.
        /// </param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the <paramref name="databaseCommand"/> parameter is <c>null</c>.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Only way to use the CallerMemberName attribute.")]
        protected DataTable ExecuteReader(DatabaseCommand databaseCommand, [CallerMemberName] string callingMethodName = "")
        {
            return ExecuteReader(databaseCommand, null, callingMethodName);
        }

        /// <summary>
        ///     Executes a <see cref="DatabaseCommand"/> against the <see cref="IDbConnection"/>
        ///     created via the <see cref="DbContext"/>, and returns a <see cref="DataTable"/>
        ///     containing the results of the query.
        /// </summary>
        /// <param name="databaseCommand">The <see cref="DatabaseCommand"/> to execute.</param>
        /// <param name="parameterValues">Parameter values to use when executing the command.</param>
        /// <param name="callingMethodName">
        ///     There is no need to specify a value for this parameter;
        ///     it will automatically be set to the calling method's name.
        /// </param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the <paramref name="databaseCommand"/> parameter is <c>null</c>.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Only way to use the CallerMemberName attribute.")]
        protected DataTable ExecuteReader(DatabaseCommand databaseCommand, IDictionary<string, object> parameterValues, [CallerMemberName] string callingMethodName = "")
        {
            ThrowExceptionIfDatabaseCommandIsNull(databaseCommand, callingMethodName);

            var dataTable = new DataTable();
            dataTable.Locale = CultureInfo.InvariantCulture;

            using (var connection = DbContext.CreateDbConnection())
            using (var reader = CreateIDbCommand(connection, databaseCommand, parameterValues).ExecuteReader())
                dataTable.Load(reader);

            return dataTable;
        }

        /// <summary>
        ///     Executes a <see cref="DatabaseCommand"/> against the <see cref="IDbConnection"/> created via the
        ///     <see cref="DbContext"/>, and returns a single result from the query as <typeparamref name="T"/>.
        /// </summary>
        /// <param name="databaseCommand">The <see cref="DatabaseCommand"/> to execute.</param>
        /// <param name="callingMethodName">
        ///     There is no need to specify a value for this parameter;
        ///     it will automatically be set to the calling method's name.
        /// </param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the <paramref name="databaseCommand"/> parameter is <c>null</c>.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Only way to use the CallerMemberName attribute.")]
        protected T ExecuteScalar<T>(DatabaseCommand databaseCommand, [CallerMemberName] string callingMethodName = "")
        {
            return ExecuteScalar<T>(databaseCommand, null, callingMethodName);
        }

        /// <summary>
        ///     Executes a <see cref="DatabaseCommand"/> against the <see cref="IDbConnection"/> created via the
        ///     <see cref="DbContext"/>, and returns a single result from the query as <typeparamref name="T"/>.
        /// </summary>
        /// <param name="databaseCommand">The <see cref="DatabaseCommand"/> to execute.</param>
        /// <param name="parameterValues">Parameter values to use when executing the command.</param>
        /// <param name="callingMethodName">
        ///     There is no need to specify a value for this parameter;
        ///     it will automatically be set to the calling method's name.
        /// </param>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the <paramref name="databaseCommand"/> parameter is <c>null</c>.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Only way to use the CallerMemberName attribute.")]
        protected T ExecuteScalar<T>(DatabaseCommand databaseCommand, IDictionary<string, object> parameterValues, [CallerMemberName] string callingMethodName = "")
        {
            ThrowExceptionIfDatabaseCommandIsNull(databaseCommand, callingMethodName);

            using (var connection = DbContext.CreateDbConnection())
            using (var command = CreateIDbCommand(connection, databaseCommand, parameterValues))
                return command.ExecuteScalar()
                              .ChangeType<T>();
        }

        /// <summary>
        ///     Inspects an instance of <see cref="DatabaseCommand"/> to see whether it is <c>null</c>, and
        ///     if it is, throws a <see cref="NullReferenceException"/> with a descriptive error message.
        /// </summary>
        /// <param name="databaseCommand">
        ///     The instance of <see cref="DatabaseCommand"/> to check for a <c>null</c> value.
        /// </param>
        /// <param name="callingMethodName">
        ///     No need to specify a value for this parameter; it will automatically be set to the calling method's name.
        /// </param>
        static DatabaseCommand ThrowExceptionIfDatabaseCommandIsNull(DatabaseCommand databaseCommand, string callingMethodName)
        {
            if (databaseCommand == null)
            {
                var message = String.Format(CultureInfo.InvariantCulture,
                                            "Unable to execute {0} because a SQL command has not been specified.",
                                            callingMethodName);
                throw new ArgumentException(message);
            }

            return databaseCommand;
        }

        /// <summary>
        ///     Checks the given instance of <see cref="IIdentityDbContext"/> to see whether the specified instance of
        ///     <see cref="ITableCommands"/> is <c>null</c>; if so, an <see cref="ArgumentException"/> is thrown.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="propertyToCheck"></param>
        protected static void ThrowIfTableCommandsIsNull(IIdentityDbContext dbContext, Func<IIdentityDbContext, ITableCommands> propertyToCheck)
        {
            if (propertyToCheck == null)
                throw new ArgumentNullException(nameof(propertyToCheck));

            ITableCommands tableCommands = propertyToCheck(dbContext);
            if (tableCommands == null)
            {
                var paramName = nameof(dbContext);
                var message =
                    String.Format(CultureInfo.InvariantCulture,
                    "The table commands specified for the database context cannot be null.{0}Table Commands: {1}",
                    Environment.NewLine,
                    nameof(dbContext.RolesTableCommands));
                throw new ArgumentException(message, paramName);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities",
            Justification = "The database object names are dynamic, so we have to use string concatenation.")]
        static IDbCommand CreateIDbCommand(IDbConnection connection, DatabaseCommand databaseCommand, IDictionary<string, object> parameterValues)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (databaseCommand == null)
                throw new ArgumentNullException(nameof(databaseCommand));

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            var command = connection.CreateCommand();

            // If we have an Oracle connection, make sure the "BindByName" property is set to "true".
            SetBindByNamePropertyToTrueIfPresent(command);

            command.CommandText = databaseCommand.CommandText;

            if (databaseCommand.CommandType.HasValue)
                command.CommandType = databaseCommand.CommandType.Value;

            if (databaseCommand.Parameters != null)
            {
                // Creating a new list here so we work on a copy of the parameters instead of the original values.
                var listOfParams = new List<IDataParameter>(databaseCommand.Parameters);
                foreach (var paramValue in parameterValues)
                {
                    var currentParamName = paramValue.Key;
                    var paramWithValue = listOfParams.FirstOrDefault(paramDef => paramDef.ParameterName == currentParamName);

                    // Just ignore parameters that haven't been defined.
                    if (paramWithValue != null)
                        paramWithValue.Value = paramValue.Value;

                    command.Parameters.Add(paramWithValue);
                }
            }

            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <remarks>
        ///     The original code for this is from Dapper:
        ///     https://github.com/StackExchange/dapper-dot-net/blob/52b1ccb79a93205f53cc100928b687367377f7a3/Dapper/CommandDefinition.cs#L149
        /// </remarks>
        static void SetBindByNamePropertyToTrueIfPresent(IDbCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var commandType = command.GetType();
            var bindByName = GetBasicPropertySetter(commandType, "BindByName", typeof(bool));
            if (bindByName != null)
                bindByName.Invoke(command, new object[] { true });
        }

        static MethodInfo GetBasicPropertySetter(Type declaringType, string name, Type expectedType)
        {
            var prop = declaringType.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite && prop.PropertyType == expectedType && prop.GetIndexParameters().Length == 0)
                return prop.GetSetMethod();

            return null;
        }
    }
}