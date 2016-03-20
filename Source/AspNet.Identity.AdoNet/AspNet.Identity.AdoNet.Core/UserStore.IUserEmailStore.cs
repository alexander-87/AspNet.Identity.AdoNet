namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserEmailStore<TUser>
    {
        /// <summary>Gets the user associated with the specified email address.</summary>
        /// <param name="email">The email address associated with the user that is to be retrieved.</param>
        /// <returns>The user associated with the specified email address.</returns>
        public Task<TUser> FindByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var result = usersTable.GetUsersByEmail(email).FirstOrDefault();
            return Task.FromResult(result);
        }

        /// <summary>Get the email address for the given user.</summary>
        /// <param name="user">The user whose email address is to be retrieved.</param>
        /// <returns>The email address for the given user.</returns>
        public Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult(user.Email);
        }

        /// <summary>Checks whether the email address for the given user has been confirmed.</summary>
        /// <param name="user">The user who is to be checked.</param>
        /// <returns>True if the email address for the given user has been confirmed; otherwise, false.</returns>
        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        /// <summary>Set the email address for the given user.</summary>
        /// <param name="user">The user whose email address is to be set.</param>
        /// <param name="email">The email address to associate with the user.</param>
        /// <returns></returns>
        public Task SetEmailAsync(TUser user, string email)
        {
            user.Email = email;
            return Task.FromResult(usersTable.UpdateUser(user));
        }

        /// <summary>Sets whether the email address has been confirmed for a given user.</summary>
        /// <param name="user">The user whose email address confirmation is being set.</param>
        /// <param name="confirmed">The value indicating whether the email address has been confirmed.</param>
        /// <returns></returns>
        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            user.LockoutEnabled = false;
            
            return Task.FromResult(usersTable.UpdateUser(user));
        }
    }
}