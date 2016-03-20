namespace AspNet.Identity.AdoNet
{
    using System;

    /// <summary>Base class for providing naming information about a database table and it's columns.</summary>
    public abstract class TableNomenclature
    {
        /// <summary>Creates a new instance of the <see cref="TableNomenclature"/> class with a specific table name.</summary>
        /// <param name="tableName">The name of the table.</param>
        protected TableNomenclature(string tableName)
        {
            ThrowIfParameterIsEmpty(tableName, nameof(tableName));

            TableName = tableName;
        }

        /// <summary>Gets the name of the table.</summary>
        public string TableName { get; protected set; }

        /// <summary>
        ///     Checks the value of a <see cref="string"/> parameter and if it's <c>null</c>, an empty string, or
        ///     only consists of white space characters, then an <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        /// <param name="value">THe value to check.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        protected static void ThrowIfParameterIsEmpty(string value, string parameterName)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(parameterName);
        }
    }
}