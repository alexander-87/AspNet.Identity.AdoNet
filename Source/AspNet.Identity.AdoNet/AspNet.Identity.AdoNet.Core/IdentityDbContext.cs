namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Data;

    /// <summary>
    ///     Provides members for creating a new connection to, and interacting with an application's identity database.
    /// </summary>
    public abstract class IdentityDbContext : IIdentityDbContext, IDisposable
    {
        /// <summary>Creates a new <see cref="IDbConnection"/> from the current context.</summary>
        /// <returns>A new instance of <see cref="IDbConnection"/>.</returns>
        public abstract IDbConnection CreateDbConnection();

        /// <summary>Gets the instance of <see cref="IRolesTableCommands" /> configured for the current context.</summary>
        public virtual IRolesTableCommands RolesTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUserRolesTableCommands"/> configured for the current context.</summary>
        public virtual IUserRolesTableCommands UserRolesTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUserClaimsTableCommands"/> configured for the current context.</summary>
        public virtual IUserClaimsTableCommands UserClaimsTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUserLoginsTableCommands"/> configured for the current context.</summary>
        public virtual IUserLoginsTableCommands UserLoginsTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUsersTableCommands"/> configured for the current context.</summary>
        public virtual IUsersTableCommands UsersTableCommands { get; protected set; }

        /// <summary>Gets an instance of <see cref="IContextNomenclature"/> containing the naming settings for each of the database objects.</summary>
        public virtual IContextNomenclature ContextNomenclature { get; protected set; }

        /// <summary>Gets a string containing the DDL necessary for creating the ASP.NET Identity database objects.</summary>
        /// <returns>A string containing the DDL necessary for creating the ASP.NET Identity database objects.</returns>
        public abstract string GenerateObjectCreationSql();

        /// <remarks>This is really only here to appease OWIN.</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public abstract void Dispose();
    }
}