namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides <see cref="DatabaseCommand"/> objects for the methods within the <see cref="RolesTable"/>.</summary>
    public interface IRolesTableCommands : ITableCommands
    {
        /// <summary>
        ///     Gets the <see cref="RolesTableNomenclature"/> containing information
        ///     about the database table containing each of the application's roles.
        /// </summary>
        RolesTableNomenclature TableNomenclature { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="RolesTable{TRole}.DeleteRoleById(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand DeleteRoleById { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="RolesTable{TRole}.GetAllRoles"/> method is invoked.
        /// </summary>
        DatabaseCommand GetAllRoles { get; }
        
        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="RolesTable{TRole}.GetRoleIdByName(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetRoleIdByName { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="RolesTable{TRole}.GetRoleNameById(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetRoleNameById { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="RolesTable{TRole}.InsertRole(TRole)"/> method is invoked.
        /// </summary>
        DatabaseCommand InsertRole { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="RolesTable{TRole}.UpdateRole(TRole)"/> method is invoked.
        /// </summary>
        DatabaseCommand UpdateRole { get; }
    }
}