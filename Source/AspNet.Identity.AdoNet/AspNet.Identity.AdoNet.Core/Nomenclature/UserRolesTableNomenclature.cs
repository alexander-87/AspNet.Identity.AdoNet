namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides naming information about the database table containing user and role associations.</summary>
    public sealed class UserRolesTableNomenclature : TableNomenclature
    {
        /// <summary>Creates a new instance of the <see cref="UserRolesTableNomenclature"/> class.</summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="userIdColumnName">
        ///     The name of the column containing the unique user ID associated with the role.
        /// </param>
        /// <param name="roleIdColumnName">
        ///     The name of the column containing the unique role ID associated with the user.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if any of the parameters are <c>null</c>, an empty string, or only consist of white space characters.
        /// </exception>
        public UserRolesTableNomenclature(string tableName, string userIdColumnName, string roleIdColumnName)
            : base(tableName)
        {
            ThrowIfParameterIsEmpty(userIdColumnName, nameof(userIdColumnName));
            ThrowIfParameterIsEmpty(roleIdColumnName, nameof(roleIdColumnName));

            UserIdColumnName = userIdColumnName;
            RoleIdColumnName = roleIdColumnName;
        }

        /// <summary>Gets the name of the column containing the unique user ID associated with the role.</summary>
        public string UserIdColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the unique role ID associated with the user.</summary>
        public string RoleIdColumnName { get; private set; }
    }
}