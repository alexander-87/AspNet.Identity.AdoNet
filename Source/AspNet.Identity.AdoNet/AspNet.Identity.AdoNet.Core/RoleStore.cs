namespace AspNet.Identity.AdoNet
{
    using System;

    /// <summary>Class that implements the key ASP.NET Identity role store interfaces.</summary>
    public sealed partial class RoleStore<TRole> : IDisposable
        where TRole : IdentityRole, new()
    {
        readonly RolesTable<TRole> rolesTable;

        /// <summary>
        ///     Creates a new instance of the <see cref="RoleStore{TRole}"/>
        ///     class using the provided <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     The instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        public RoleStore(IIdentityDbContext dbContext) : this(new RolesTable<TRole>(dbContext)) { }

        /// <remarks>This constructor is only intended to be used during testing.</remarks>
        internal RoleStore(RolesTable<TRole> rolesTable)
        {
            this.rolesTable = rolesTable;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose() { }
    }
}