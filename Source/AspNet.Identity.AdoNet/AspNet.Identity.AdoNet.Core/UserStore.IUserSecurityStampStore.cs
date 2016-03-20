namespace AspNet.Identity.AdoNet
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserSecurityStampStore<TUser>
    {
        /// <summary>Get the security stamp for the given user.</summary>
        /// <param name="user">The user whose security stamp is to be retrieved.</param>
        /// <returns></returns>
        public Task<string> GetSecurityStampAsync(TUser user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        /// <summary>Set the security stamp for the given user.</summary>
        /// <param name="user">The user whose security stamp is to be set.</param>
        /// <param name="stamp">The security stamp value.</param>
        /// <returns></returns>
        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            
            return Task.FromResult(0);
        }
    }
}