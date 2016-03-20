namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserClaimStore<TUser>
    {
        /// <summary>Adds a new <see cref="Claim"/> for the given user.</summary>
        /// <param name="user">The user to add the <see cref="Claim"/> to.</param>
        /// <param name="claim">The <see cref="Claim"/> to be added.</param>
        /// <returns></returns>
        public Task AddClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (claim == null)
                throw new ArgumentNullException(nameof(claim));
            
            return Task.FromResult(userClaimsTable.AddClaimForUser(claim, user.Id));
        }

        /// <summary>Gets all <see cref="Claim"/>s for the given user.</summary>
        /// <param name="user">The user whose <see cref="Claim"/>s are to be retrieved.</param>
        /// <returns></returns>
        public Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            var identity = userClaimsTable.GetAllClaimsForUser(user.Id);
            return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
        }

        /// <summary>Removes the given claim from the specified user.</summary>
        /// <param name="user">The user to have the claim removed from.</param>
        /// <param name="claim">The <see cref="Claim"/> to be removed.</param>
        /// <returns></returns>
        public Task RemoveClaimAsync(TUser user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            return Task.FromResult(userClaimsTable.RemoveClaimForUser(user, claim));
        }
    }
}