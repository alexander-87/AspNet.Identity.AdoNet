namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides <see cref="DatabaseCommand"/> objects for the methods within the <see cref="UserClaimsTable"/>.</summary>
    public interface IUsersTableCommands : ITableCommands
    {
        /// <summary>
        ///     Gets the <see cref="UsersTableNomenclature"/> containing information
        ///     about the database table containing each of the application's roles.
        /// </summary>
        UsersTableNomenclature TableNomenclature { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetUserNameByUserId(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetUserNameByUserId { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetUserIdByUserName(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetUserIdByUserName { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetUserById(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetUserById { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetUsersByUserName(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetUsersByUserName { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetUsersByEmail(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetUsersByEmail { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetPasswordHashForUser(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetPasswordHashForUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.SetPasswordHashForUser(string, string)"/> method is invoked.
        /// </summary>
        DatabaseCommand SetPasswordHashForUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetSecurityStampForUser(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetSecurityStampForUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.AddNewUser(TUser)"/> method is invoked.
        /// </summary>
        DatabaseCommand AddNewUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.DeleteUser(TUser)"/> method is invoked.
        /// </summary>
        DatabaseCommand DeleteUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.UpdateUser(TUser)"/> method is invoked.
        /// </summary>
        DatabaseCommand UpdateUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UsersTable{TUser}.GetAllUsers"/> method is invoked.
        /// </summary>
        DatabaseCommand GetAllUsers { get; }
    }
}