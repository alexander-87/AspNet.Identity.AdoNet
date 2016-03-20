namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserLockoutStore<TUser, string>
    {
        /// <summary>
        ///     Returns the current number of failed access attempts.
        ///     This number usually will be reset whenever the
        ///     password is verified or the account is locked out.
        /// </summary>
        /// <param name="user">The user whose number of failed access attempts is to be retrieved.</param>
        /// <returns></returns>
        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        /// <summary>
        ///     Gets a value indicating whether the user can be locked out.
        ///     <para>
        ///         NOTE: This does not return a value indicating whether the user
        ///         is locked out, only whether their account CAN be locked out.
        ///     </para>
        /// </summary>
        /// <param name="user">The user to see whether their account can be locked out.</param>
        /// <returns>A <see cref="bool"/> value indicating whether the user can be locked out.</returns>
        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        /// <summary>
        ///     Returns the <see cref="DateTimeOffset"/> that represents the end of a
        ///     user's lockout; any time in the past should be considered not locked out.
        /// </summary>
        /// <param name="user">The user whose lockout end date is to be retrieved.</param>
        /// <returns>
        ///     The <see cref="DateTimeOffset"/> that represents the end of a user's
        ///     lockout; any time in the past should be considered not locked out.
        /// </returns>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        /// <summary>
        ///     Increments the number of failed authentication attempts for a given user.
        ///     Used to record when an attempt to access the user has failed.
        /// </summary>
        /// <param name="user">The user whose authentication attempt failed.</param>
        /// <returns></returns>
        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            user.AccessFailedCount++;
            usersTable.UpdateUser(user);

            return Task.FromResult(user.AccessFailedCount);
        }

        /// <summary>Used to reset the access failed count, typically after the account is successfully accessed.</summary>
        /// <param name="user">The user whose failed authentication count is to be reset.</param>
        /// <returns></returns>
        public Task ResetAccessFailedCountAsync(TUser user)
        {
            user.AccessFailedCount = 0;

            return Task.FromResult(usersTable.UpdateUser(user));
        }

        /// <summary>
        ///     Sets whether the user can be locked out.
        ///     <para>
        ///         NOTE: This does not change whether the user is locked
        ///         out, only whether their account CAN be locked out.
        ///     </para>
        /// </summary>
        /// <param name="user">The user whose account can/can't be locked out.</param>
        /// <param name="enabled">A value indicating whether the account can be locked out.</param>
        /// <returns></returns>
        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            
            return Task.FromResult(usersTable.UpdateUser(user));
        }

        /// <summary>Locks a user out until the specified end date (set to a past date, to unlock a user).</summary>
        /// <param name="user">The user whose lockout end date is to be set.</param>
        /// <param name="lockoutEnd">The <see cref="DateTimeOffset"/> representing the lockout end date.</param>
        /// <returns></returns>
        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            
            return Task.FromResult(usersTable.UpdateUser(user));
        }
    }
}