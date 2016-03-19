namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserPasswordStore<TUser>
    {
        /// <summary>Get the password hash for the given user.</summary>
        /// <param name="user">The user whose password hash is to be retrieved.</param>
        /// <returns>The password hash for the given user.</returns>
        public Task<string> GetPasswordHashAsync(TUser user)
        {
            var passwordHash = usersTable.GetPasswordHashForUser(user.Id);

            return Task.FromResult(passwordHash);
        }

        /// <summary>Checks whether the given user has a password set.</summary>
        /// <param name="user">The user to check for the presence of a password.</param>
        /// <returns>True if the given user has a password set; otherwise false.</returns>
        public Task<bool> HasPasswordAsync(TUser user)
        {
            var hasPassword = !String.IsNullOrEmpty(usersTable.GetPasswordHashForUser(user.Id));

            return Task.FromResult(Boolean.Parse(hasPassword.ToString()));
        }

        /// <summary>Sets the password hash for the given user.</summary>
        /// <param name="user">The user to set the password hash for.</param>
        /// <param name="passwordHash">The password hash value.</param>
        /// <returns></returns>
        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult<object>(null);
        }
    }
}