namespace AspNet.Identity.AdoNet
{
    using System;

    /// <summary>Class that implements the key ASP.NET Identity user store interfaces.</summary>
    /// <typeparam name="TUser">They type of user.</typeparam>
    public sealed partial class UserStore<TUser> : IDisposable
        where TUser : IdentityUser, new()
    {
        readonly UsersTable<TUser> usersTable;
        readonly RolesTable<IdentityRole> rolesTable;
        readonly UserRolesTable userRolesTable;
        readonly UserClaimsTable userClaimsTable;
        readonly UserLoginsTable userLoginsTable;

        /// <summary>
        ///     Creates a new instance of the <see cref="UserStore{TUser}"/>
        ///     class using the provided <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">The <see cref="IIdentityDbContext"/> to use.</param>
        public UserStore(IIdentityDbContext dbContext)
            : this(new UsersTable<TUser>(dbContext),
                   new RolesTable<IdentityRole>(dbContext),
                   new UserRolesTable(dbContext),
                   new UserClaimsTable(dbContext),
                   new UserLoginsTable(dbContext))
        { }

        /// <remarks>This constructor is only intended to be used during testing.</remarks>
        internal UserStore(UsersTable<TUser> usersTable,
                           RolesTable<IdentityRole> rolesTable,
                           UserRolesTable userRolesTable,
                           UserClaimsTable userClaimsTable,
                           UserLoginsTable userLoginsTable)
        {
            this.usersTable = usersTable;
            this.rolesTable = rolesTable;
            this.userRolesTable = userRolesTable;
            this.userClaimsTable = userClaimsTable;
            this.userLoginsTable = userLoginsTable;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose() { }
    }
}