namespace AspNet.Identity.AdoNet
{
    /// <remarks>This is a non-generic version of the <see cref="RolesTable{TRole}"/> class to allow simplified access to the constants herein.</remarks>
    public abstract class RolesTable : Table
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="RolesTable"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if the <paramref name="dbContext"/> parameter is <c>null</c>.
        /// </exception>
        protected RolesTable(IIdentityDbContext dbContext) : base(dbContext) { }

        /// <summary>Contains constants for each of the parameters used in queries, organized by method name.</summary>
        public static class Parameters
        {
            /// <summary>Contains constants for each of the parameter names used by <see cref="RolesTable{TRole}.DeleteRoleById(string)"/>.</summary>
            public static class DeleteRoleById
            {
                /// <summary>The name of the "RoleId" parameter used in the query.</summary>
                public const string RoleId = "ID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="RolesTable{TRole}.InsertRole(TRole)"/>.</summary>
            public static class InsertRole
            {
                /// <summary>The name of the "RoleId" parameter used in the query.</summary>
                public const string RoleId = "ID";

                /// <summary>The name of the "RoleName" parameter used in the query.</summary>
                public const string RoleName = "NAME";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="RolesTable{TRole}.GetRoleNameById(string)"/>.</summary>
            public static class GetRoleNameById
            {
                /// <summary>The name of the "RoleId" parameter used in the query.</summary>
                public const string RoleId = "ID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="RolesTable{TRole}.GetRoleIdByName(string)"/>.</summary>
            public static class GetRoleIdByName
            {
                /// <summary>The name of the "RoleName" parameter used in the query.</summary>
                public const string RoleName = "NAME";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="RolesTable{TRole}.UpdateRole(TRole)"/>.</summary>
            public static class UpdateRole
            {
                /// <summary>The name of the "RoleId" parameter used in the query.</summary>
                public const string RoleId = "ID";

                /// <summary>The name of the "RoleName" parameter used in the query.</summary>
                public const string RoleName = "NAME";
            }
        }
    }
}