namespace AspNet.Identity.AdoNet
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserTwoFactorStore<TUser, string>
    {
        /// <summary>Gets a value indicating whether two factor authentication is enabled for a given user.</summary>
        /// <param name="user">The user for which to check whether two factor authentication is enabled.</param>
        /// <returns>
        ///     A <see cref="bool"/> value indicating whether two factor authentication is enabled for the given user.
        /// </returns>
        public Task<bool> GetTwoFactorEnabledAsync(TUser user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        /// <summary>Sets whether two factor authentication is enabled for a given user.</summary>
        /// <param name="user">The use for which to set whether two factor authentication is enabled.</param>
        /// <param name="enabled">The value indicating whether two factor authentication is enabled.</param>
        /// <returns></returns>
        public Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            usersTable.UpdateUser(user);

            return Task.FromResult(0);
        }
    }
}