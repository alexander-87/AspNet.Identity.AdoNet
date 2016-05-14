using Oracle.ManagedDataAccess.Client;

namespace AspNet.Identity.AdoNet.Oracle
{
    using System;

    /// <summary>Implementation of <see cref="IdentityDbContext"/> for use with an Oracle database.</summary>
    public class OracleIdentityDbContext : IdentityDbContext
    {
        readonly string connectionString;
        readonly bool enableCaseInsensitiveSearching;

        /// <summary>
        ///     Creates a new instance of the <see cref="OracleIdentityDbContext"/> class with
        ///     the specified connections string and <see cref="IRolesTableCommands"/>.
        /// </summary>
        /// <param name="connectionString">The connection string to use when connecting to the Oracle database.</param>
        /// <param name="contextNomenclature">
        ///     Instance of <see cref="IContextNomenclature"/> containing the naming settings for each of the database objects.
        /// </param>
        /// <param name="enableCaseInsensitiveSearching">
        ///     A <see cref="bool"/> value indicating whether case insensitive searches should be used when querying the database.
        ///     <para>
        ///         When set to <c>true</c>, the following Oracle session parameters are set:
        ///         <list type="bullet">
        ///         <item>
        ///             <term>NLS_SORT</term>
        ///             <description>"BINARY_CI"</description>
        ///         </item>
        ///         <item>
        ///             <term>NLS_SORT</term>
        ///             <description>"LINGUISTIC"</description>
        ///         </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="connectionString"/> parameter is
        ///     <c>null</c>, an empty string, or only consists of white space characters.
        /// </exception>
        /// <seealso cref="http://docs.oracle.com/cd/B28359_01/server.111/b28320/initparams145.htm#REFRN10127">
        ///     Oracle Database Reference: NLS_SORT
        /// </seealso>
        /// <seealso cref="http://docs.oracle.com/cd/B28359_01/server.111/b28320/initparams135.htm#REFRN10117">
        ///     Oracle Database Reference: NLS_COMP
        /// </seealso>
        public OracleIdentityDbContext(string connectionString, IContextNomenclature contextNomenclature = null, bool enableCaseInsensitiveSearching = true)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            this.connectionString = connectionString;
            ContextNomenclature = contextNomenclature ?? new OracleContextNomenclature();
            this.enableCaseInsensitiveSearching = enableCaseInsensitiveSearching;

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "We're passing the IDbConnection to the caller, so we don't want to dispose of it - that's their job.")]
        public override System.Data.IDbConnection CreateDbConnection()
        {
            var connection = new OracleConnection(connectionString);

            // See: Case-insensitive searching in Oracle http://stackoverflow.com/a/5391234/1796930
            if (enableCaseInsensitiveSearching)
            {
                connection.Open(); // The connection has to be open before we can set any session info

                OracleGlobalization info = connection.GetSessionInfo();
                info.Sort = "BINARY_CI"; // NLS_SORT: 
                info.Comparison = "LINGUISTIC"; // NLS_COMP: 
                connection.SetSessionInfo(info);
            }

            return connection;
        }

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