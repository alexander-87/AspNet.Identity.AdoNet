namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides <see cref="DatabaseCommand"/> objects for the methods within the <see cref="UserLoginsTable"/>.</summary>
    public interface IUserLoginsTableCommands : ITableCommands
    {
        /// <summary>
        ///     Gets the <see cref="UserLoginsTableNomenclature"/> containing information
        ///     about the each of the external logins for the application's users.
        /// </summary>
        UserLoginsTableNomenclature TableNomenclature { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserLoginsTable.AddNewUserLogin(Microsoft.AspNet.Identity.IUser{string}, Microsoft.AspNet.Identity.UserLoginInfo)"/> method is invoked.
        /// </summary>
        DatabaseCommand AddNewUserLogin { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserLoginsTable.DeleteAllLoginsForUserById(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand DeleteAllLoginsForUserById { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserLoginsTable.DeleteUserLogin(Microsoft.AspNet.Identity.IUser{string}, Microsoft.AspNet.Identity.UserLoginInfo)"/> method is invoked.
        /// </summary>
        DatabaseCommand DeleteUserLogin { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserLoginsTable.GetAllUserLoginsForUserId(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetAllUserLoginsForUserId { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserLoginsTable.GetUserIdByLogin(Microsoft.AspNet.Identity.UserLoginInfo)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetUserIdByLogin { get; }
    }
}