namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides naming information about the database table containing each of the application's roles.</summary>
    public sealed class RolesTableNomenclature : TableNomenclature
    {
        /// <summary>Creates a new instance of the <see cref="RolesTableNomenclature"/> class.</summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="roleIdColumnName">The name of the column containing the role's unique ID.</param>
        /// <param name="roleNameColumnName">The name of the column containing the role's name.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if any of the parameters are <c>null</c>, an empty string, or only consist of white space characters.
        /// </exception>
        public RolesTableNomenclature(string tableName, string roleIdColumnName, string roleNameColumnName)
            : base(tableName)
        {
            ThrowIfParameterIsEmpty(roleIdColumnName, nameof(roleIdColumnName));
            ThrowIfParameterIsEmpty(roleNameColumnName, nameof(roleNameColumnName));

            RoleIdColumnName = roleIdColumnName;
            RoleNameColumnName = roleNameColumnName;
        }

        /// <summary>Gets the name of the column containing the role's unique ID.</summary>
        public string RoleIdColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the role's name.</summary>
        public string RoleNameColumnName { get; private set; }
    }
}