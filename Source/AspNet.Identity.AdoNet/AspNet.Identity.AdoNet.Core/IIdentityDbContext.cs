namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Data;

    /// <summary>
    ///     Provides members for creating a new connection to, and interacting with an application's identity database.
    /// </summary>
    public interface IIdentityDbContext : IDisposable // NOTE: IDisposable is really only here to appease OWIN.
    {
        /// <summary>Creates a new <see cref="IDbConnection"/> from the current context.</summary>
        /// <returns>A new instance of <see cref="IDbConnection"/>.</returns>
        IDbConnection CreateDbConnection();

        /// <summary>Gets the instance of <see cref="IRolesTableCommands"/> configured for the current context.</summary>
        IRolesTableCommands RolesTableCommands { get; }

        /// <summary>Gets the instance of <see cref="IUserRolesTableCommands"/> configured for the current context.</summary>
        IUserRolesTableCommands UserRolesTableCommands { get; }

        /// <summary>Gets the instance of <see cref="IUserClaimsTableCommands"/> configured for the current context.</summary>
        IUserClaimsTableCommands UserClaimsTableCommands { get; }

        /// <summary>Gets the instance of <see cref="IUserLoginsTableCommands"/> configured for the current context.</summary>
        IUserLoginsTableCommands UserLoginsTableCommands { get; }

        /// <summary>Gets the instance of <see cref="IUsersTableCommands"/> configured for the current context.</summary>
        IUsersTableCommands UsersTableCommands { get; }

        /// <summary>Gets an instance of <see cref="IContextNomenclature"/> containing the naming settings for each of the database objects.</summary>
        IContextNomenclature ContextNomenclature { get; }

        /// <summary>Gets a string containing the DDL necessary for creating the ASP.NET Identity database objects.</summary>
        /// <returns>A string containing the DDL necessary for creating the ASP.NET Identity database objects.</returns>
        string GenerateObjectCreationSql();
    }
}