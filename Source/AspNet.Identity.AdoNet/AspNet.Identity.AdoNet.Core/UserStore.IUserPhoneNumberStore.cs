namespace AspNet.Identity.AdoNet
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserPhoneNumberStore<TUser>
    {
        /// <summary>Get the phone number associated with the given user.</summary>
        /// <param name="user">The user whose phone number is to be retrieved.</param>
        /// <returns>The phone number associated with the given user.</returns>
        public Task<string> GetPhoneNumberAsync(TUser user)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        /// <summary>Checks whether the phone number for the given user has been confirmed; otherwise, false.</summary>
        /// <param name="user">The user whose phone number confirmation is to be checked.</param>
        /// <returns>True if the phone number for the given user has been confirmed; otherwise, false.</returns>
        public Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        /// <summary>Set the phone number for the given user.</summary>
        /// <param name="user">The user whose phone number is to be set.</param>
        /// <param name="phoneNumber">The phone number to associate with the given <paramref name="user"/>.</param>
        /// <returns></returns>
        public Task SetPhoneNumberAsync(TUser user, string phoneNumber)
        {
            user.PhoneNumber = phoneNumber;
            usersTable.UpdateUser(user);

            return Task.FromResult(0);
        }

        /// <summary>Sets whether the phone number has been confirmed for a given user.</summary>
        /// <param name="user">The user whose phone number confirmation is to be set.</param>
        /// <param name="confirmed">The value indicating whether the user's phone number has been confirmed.</param>
        /// <returns></returns>
        public Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed)
        {
            user.PhoneNumberConfirmed = confirmed;
            usersTable.UpdateUser(user);

            return Task.FromResult(0);
        }
    }
}