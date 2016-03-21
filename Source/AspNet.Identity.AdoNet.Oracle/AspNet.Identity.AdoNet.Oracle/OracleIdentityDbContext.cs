namespace AspNet.Identity.AdoNet.Oracle
{
    using System;

    /// <summary>Implementation of <see cref="IdentityDbContext"/> for use with an Oracle database.</summary>
    public class OracleIdentityDbContext : IdentityDbContext
    {
        readonly string connectionString;

        /// <summary>
        ///     Creates a new instance of the <see cref="OracleIdentityDbContext"/> class with
        ///     the specified connections string and <see cref="IRolesTableCommands"/>.
        /// </summary>
        /// <param name="connectionString">The connection string to use when connecting to the Oracle database.</param>
        /// <param name="contextNomenclature">
        ///     Instance of <see cref="IContextNomenclature"/> containing the naming settings for each of the database objects.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="connectionString"/> parameter is
        ///     <c>null</c>, an empty string, or only consists of white space characters.
        /// </exception>
        public OracleIdentityDbContext(string connectionString, IContextNomenclature contextNomenclature = null)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            this.connectionString = connectionString;
            ContextNomenclature = contextNomenclature ?? new OracleContextNomenclature();

            RolesTableCommands = new RolesTableSqlCommands(ContextNomenclature.RolesTableNomenclature);
            UserClaimsTableCommands = new UserClaimsTableSqlCommands(ContextNomenclature.UserClaimsTableNomenclature);
            UserLoginsTableCommands = new UserLoginsTableSqlCommands(ContextNomenclature.UserLoginsTableNomenclature);
            UserRolesTableCommands = new UserRolesTableSqlCommands(ContextNomenclature.UserRolesTableNomenclature, ContextNomenclature.RolesTableNomenclature);
            UsersTableCommands = new UsersTableSqlCommands(ContextNomenclature.UsersTableNomenclature);
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="OracleIdentityDbContext"/> class configured
        ///     to use the provided connection string and <see cref="IContextNomenclature"/>.
        /// </summary>
        /// <param name="connectionString">The connection string to use when connecting to the Oracle database.</param>
        /// <param name="contextNomenclature">
        ///     The <see cref="IContextNomenclature"/> containing the information on the naming of the database objects.
        /// </param>
        /// <returns>
        ///     A new instance of <see cref="OracleIdentityDbContext"/> configured to use
        ///     the provided connection string and <see cref="IContextNomenclature"/>.
        /// </returns>
        public static IdentityDbContext Create(string connectionString, IContextNomenclature contextNomenclature = null) =>
            new OracleIdentityDbContext(connectionString, contextNomenclature);

        /// <summary>Creates a new <see cref="System.Data.IDbConnection"/> from the current context.</summary>
        /// <returns>A new instance of <see cref="System.Data.IDbConnection"/>.</returns>
        public override System.Data.IDbConnection CreateDbConnection() =>
            new global::Oracle.ManagedDataAccess.Client.OracleConnection(connectionString);

        /// <summary>Gets a string containing the DDL necessary for creating the ASP.NET Identity database objects.</summary>
        /// <returns>A string containing the DDL necessary for creating the ASP.NET Identity database objects.</returns>
        public override string GenerateObjectCreationSql()
        {
            var rolesNomenclature = RolesTableCommands.TableNomenclature;
            var usersNomenclature = UsersTableCommands.TableNomenclature;
            var userClaimsNomenclature = UserClaimsTableCommands.TableNomenclature;
            var userLoginsNomenclature = UserLoginsTableCommands.TableNomenclature;
            var userRolesNomenclature = UserRolesTableCommands.UserRolesTableNomenclature;

            var ddlScript = new System.Text.StringBuilder()
                .AppendLine(RolesTableSqlCommands.GenerateCreationSql(rolesNomenclature))
                .AppendLine(UsersTableSqlCommands.GenerateCreationSql(usersNomenclature))
                .AppendLine(UserClaimsTableSqlCommands.GenerateCreationSql(userClaimsNomenclature))
                .AppendLine(UserLoginsTableSqlCommands.GenerateCreationSql(userLoginsNomenclature, usersNomenclature))
                .AppendLine(UserRolesTableSqlCommands.GenerateCreationSql(userRolesNomenclature, rolesNomenclature, usersNomenclature));

            return ddlScript.ToString();
        }
    }
}