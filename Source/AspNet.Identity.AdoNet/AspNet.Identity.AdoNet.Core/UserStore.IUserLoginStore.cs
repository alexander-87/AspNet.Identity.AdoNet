namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserLoginStore<TUser>
    {
        /// <summary>Adds a login for the given user with the specified provider and key.</summary>
        /// <param name="user">The user to add the login for.</param>
        /// <param name="login">The <see cref="UserLoginInfo"/> to add for the user.</param>
        /// <returns></returns>
        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (login == null)
                throw new ArgumentNullException(nameof(login));
            
            return Task.FromResult(userLoginsTable.AddNewUserLogin(user, login));
        }

        /// <summary>Returns the user associated with the specified login.</summary>
        /// <returns>The <see cref="UserLoginInfo"/> associated with the user.</returns>
        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            var userId = userLoginsTable.GetUserIdByLogin(login);
            if (userId == null)
                return Task.FromResult<TUser>(null);
            
            return Task.FromResult(usersTable.GetUserById(userId));
        }

        /// <summary>Returns the linked accounts for the given user.</summary>
        /// <param name="user">The user who' logins are to be retrieved.</param>
        /// <returns></returns>
        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            
            return Task.FromResult(userLoginsTable.GetAllUserLoginsForUserId(user.Id));
        }

        /// <summary>Removes the login for the given user, if it exists.</summary>
        /// <param name="user">The user who's login is to be removed.</param>
        /// <param name="login">The <see cref="UserLoginInfo"/> to remove.</param>
        /// <returns></returns>
        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (login == null)
                throw new ArgumentNullException(nameof(login));

            userLoginsTable.DeleteUserLogin(user, login);

            return Task.FromResult<object>(null);
        }
    }
}