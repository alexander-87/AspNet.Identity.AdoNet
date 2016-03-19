namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserStore<TUser>
    {
        /// <summary>Inserts a new <see name="TUser"/> in the users table.</summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task CreateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            usersTable.AddNewUser(user);

            return Task.FromResult<object>(null);
        }

        /// <summary>Deletes a <typeparamref name="TUser"/> from the database.</summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task DeleteAsync(TUser user)
        {
            if (user != null)
                usersTable.DeleteUser(user);

            return Task.FromResult<object>(null);
        }

        /// <summary>Returns the <typeparamref name="TUser"/> with the specified unique ID.</summary>
        /// <param name="userId">The unique ID of the <typeparamref name="TUser"/> to retrieve.</param>
        /// <returns></returns>
        public Task<TUser> FindByIdAsync(string userId)
        {
            if (String.IsNullOrEmpty(userId))
                throw new ArgumentException($"Null or empty user id.", nameof(userId));

            var result = usersTable.GetUserById(userId);

            return Task.FromResult(result);
        }

        /// <summary>Returns the <typeparamref name="TUser"/> with the specified user name.</summary>
        /// <param name="userName">The user name of the <typeparamref name="TUser"/> to retrieve.</param>
        /// <returns></returns>
        public Task<TUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("Null or empty argument: userName");

            var users = usersTable.GetUsersByUserName(userName);

            // TODO: Should I throw if > 1 user?
            if (users != null && users.Count() == 1)
                return Task.FromResult(users[0]);

            return Task.FromResult<TUser>(null);
        }

        /// <summary>
        ///     Updates the attributes of a <typeparamref name="TUser"/>
        ///     in the database with the provided instance's values.
        /// </summary>
        /// <param name="user">The instance of <typeparamref name="TUser"/> to update.</param>
        /// <returns></returns>
        public Task UpdateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            usersTable.UpdateUser(user);

            return Task.FromResult<object>(null);
        }
    }
}