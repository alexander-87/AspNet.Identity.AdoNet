namespace AspNet.Identity.AdoNet
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>Represents a SQL command that can be executed against a database.</summary>
    public sealed class DatabaseCommand
    {
        /// <summary>The command (i.e. SQL query or a stored-procedure name) to execute.</summary>
        public string CommandText { get; set; }

        /// <summary>Gets or sets the type of command that the <see cref="CommandText"/> represents.</summary>
        public CommandType? CommandType { get; set; } = default(CommandType?);

        /// <summary>
        ///     Gets or sets the parameters associated with the command.
        ///     <para>
        ///         NOTE: The values for each parameter will be set at run-time when the
        ///         methods in the class inheriting from <see cref="Table"/> are invoked.
        ///     </para>
        /// </summary>
        public IEnumerable<IDataParameter> Parameters { get; set; }
    }
}