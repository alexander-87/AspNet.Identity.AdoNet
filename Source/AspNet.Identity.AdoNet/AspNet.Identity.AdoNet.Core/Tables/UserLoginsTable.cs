namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.AspNet.Identity;

    /// <summary>
    ///     Represents the table in the database containing information about
    ///     the external logins associated with each of the application's users.
    /// </summary>
    public sealed partial class UserLoginsTable : Table
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="UserLoginsTable"/>
        ///     class with the specified <see cref="IdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <see cref="IIdentityDbContext.UserLoginsTableCommands"/>
        ///     property of the <paramref name="dbContext"/> parameter is <c>null</c>.
        /// </exception>
        internal UserLoginsTable(IIdentityDbContext dbContext)
            : base(dbContext)
        {
            ThrowIfTableCommandsIsNull(dbContext, x => x.UserLoginsTableCommands);
        }

        /// <summary>Adds a new <see cref="UserLoginInfo"/> for a specific <see cref="IUser"/>.</summary>
        /// <param name="user">
        ///     User to associate with the <see cref="UserLoginInfo"/> provided in the <paramref name="loginInfo"/> parameter.
        /// </param>
        /// <param name="loginInfo">The <see cref="UserLoginInfo"/> to be added for the specified user.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public int AddNewUserLogin(IUser<string> user, UserLoginInfo loginInfo)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (loginInfo == null)
                throw new ArgumentNullException(nameof(loginInfo));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.AddNewUserLogin.ProviderName] = loginInfo.LoginProvider,
                [Parameters.AddNewUserLogin.ProviderKey] = loginInfo.ProviderKey,
                [Parameters.AddNewUserLogin.UserId] = user.Id
            };
            return ExecuteNonQuery(DbContext.UserLoginsTableCommands.AddNewUserLogin, parameterValues);
        }

        /// <summary>
        /// Deletes all Logins from a user in the UserLogins table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public int DeleteAllLoginsForUserById(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.DeleteAllLoginsForUserById.UserId] = userId
            };
            return ExecuteNonQuery(DbContext.UserLoginsTableCommands.DeleteAllLoginsForUserById, parameterValues);
        }

        /// <summary>
        /// Deletes a login from a user in the UserLogins table
        /// </summary>
        /// <param name="user">User to have login deleted</param>
        /// <param name="loginInfo">Login to be deleted from user</param>
        /// <returns></returns>
        public int DeleteUserLogin(IUser<string> user, UserLoginInfo loginInfo)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (loginInfo == null)
                throw new ArgumentNullException(nameof(loginInfo));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.DeleteUserLogin.UserId] = user.Id,
                [Parameters.DeleteUserLogin.ProviderName] = loginInfo.LoginProvider,
                [Parameters.DeleteUserLogin.ProviderKey] = loginInfo.ProviderKey
            };
            return ExecuteNonQuery(DbContext.UserLoginsTableCommands.DeleteUserLogin, parameterValues);
        }

        /// <summary>Gets am <see cref="List{T}"/> of all <see cref="UserLoginInfo"/>s associated with a specific user.</summary>
        /// <param name="userId">The user's ID.</param>
        /// <returns></returns>
        public IList<UserLoginInfo> GetAllUserLoginsForUserId(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetAllUserLoginsForUserId.UserId] = userId
            };
            using (var dataTable = ExecuteReader(DbContext.UserLoginsTableCommands.GetAllUserLoginsForUserId, parameterValues))
            {
                var logins = new List<UserLoginInfo>();
                var table = DbContext.UserLoginsTableCommands.TableNomenclature;
                foreach (DataRow record in dataTable.Rows)
                {
                    var loginProvider = record.Field<string>(table.ProviderNameColumnName);
                    var providerKey = record.Field<string>(table.ProviderKeyColumnName);
                    logins.Add(new UserLoginInfo(loginProvider, providerKey));
                }
                return logins;
            }
        }

        /// <summary>Gets the unique ID for a user associated with a given <see cref="UserLoginInfo"/>.</summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public string GetUserIdByLogin(UserLoginInfo loginInfo)
        {
            if (loginInfo == null)
                throw new ArgumentNullException(nameof(loginInfo));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetUserIdByLogin.ProviderName] = loginInfo.LoginProvider,
                [Parameters.GetUserIdByLogin.ProviderKey] = loginInfo.ProviderKey
            };
            return ExecuteScalar<string>(DbContext.UserLoginsTableCommands.GetUserIdByLogin, parameterValues);
        }
    }
}