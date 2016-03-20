namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides <see cref="DatabaseCommand"/> objects for the methods within the <see cref="UserRolesTable"/>.</summary>
    public interface IUserRolesTableCommands : ITableCommands
    {
        /// <summary>Gets the <see cref="AdoNet.UserRolesTableNomenclature"/> for the current commands.</summary>
        UserRolesTableNomenclature UserRolesTableNomenclature { get; }

        /// <summary>Gets the <see cref="AdoNet.RolesTableNomenclature"/> for the current commands.</summary>
        RolesTableNomenclature RolesTableNomenclature { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserRolesTable.GetRolesForUserId(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetRolesForUserId { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserRolesTable.DeleteByUserId(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand DeleteByUserId { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserRolesTable.AddUserToRole(Microsoft.AspNet.Identity.IUser{string}, string)"/> method is invoked.
        /// </summary>
        DatabaseCommand AddUserToRole { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserRolesTable.RemoveUserFromFromRole(Microsoft.AspNet.Identity.IUser{string}, string)"/> method is invoked.
        /// </summary>
        DatabaseCommand RemoveUserFromFromRole { get; }
    }
}