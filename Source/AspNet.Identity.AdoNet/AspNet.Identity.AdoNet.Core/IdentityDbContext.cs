namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Data;

    /// <summary>
    ///     Provides members for creating a new connection to, and interacting with an application's identity database.
    /// </summary>
    public abstract class IdentityDbContext : IIdentityDbContext, IDisposable
    {
        /// <summary>Gets the instance of <see cref="IRolesTableCommands" /> configured for the current context.</summary>
        public IRolesTableCommands RolesTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUserRolesTableCommands"/> configured for the current context.</summary>
        public IUserRolesTableCommands UserRolesTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUserClaimsTableCommands"/> configured for the current context.</summary>
        public IUserClaimsTableCommands UserClaimsTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUserLoginsTableCommands"/> configured for the current context.</summary>
        public IUserLoginsTableCommands UserLoginsTableCommands { get; protected set; }

        /// <summary>Gets the instance of <see cref="IUsersTableCommands"/> configured for the current context.</summary>
        public IUsersTableCommands UsersTableCommands { get; protected set; }

        /// <summary>Gets an instance of <see cref="IContextNomenclature"/> containing the naming settings for each of the database objects.</summary>
        public IContextNomenclature ContextNomenclature { get; protected set; }

        /// <summary>Creates a new <see cref="IDbConnection"/> from the current context.</summary>
        /// <returns>A new instance of <see cref="IDbConnection"/>.</returns>
        public abstract IDbConnection CreateDbConnection();

        /// <summary>Gets a string containing the DDL necessary for creating the ASP.NET Identity database objects.</summary>
        /// <returns>A string containing the DDL necessary for creating the ASP.NET Identity database objects.</returns>
        public abstract string GenerateObjectCreationSql();

        #region IDisposable Support

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing">Value indicating whether <see cref="Dispose()"/> is invoking this method.</param>
        /// <remarks>This is really only here to appease OWIN.</remarks>
        /// <example>
        /// <code lang="C#">
        /// 
        /// &lt;summary&gt;Used to detect redundant calls to &lt;see cref="Dispose()"/&gt;.&lt;/summary&gt;
        /// bool disposedValue;
        /// 
        /// public override void Dispose()
        /// {
        ///     if (!disposedValue)
        ///     {
        ///         if (disposing)
        ///         {
        ///             // TODO: dispose managed state (managed objects).
        ///         }
        ///
        ///         // TODO: free unmanaged resources (unmanaged objects) and override a finalizer.
        ///         // TODO: set large fields to null.
        ///         
        ///         disposedValue = true;
        ///     }
        /// }
        /// </code>
        /// </example>
        protected virtual void Dispose(bool disposing) { }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        #endregion
    }
}