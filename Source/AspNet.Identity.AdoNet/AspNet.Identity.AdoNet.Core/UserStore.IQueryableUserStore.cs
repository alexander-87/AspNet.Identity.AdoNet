namespace AspNet.Identity.AdoNet
{
    using System.Linq;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IQueryableUserStore<TUser>
    {
        /// <summary>Get all Users defined.</summary>
        /// <remarks>
        ///     This code is a loose implementation.
        ///     An occurrence of a performance problem is when you get a large amount of data.
        /// </remarks>
        public IQueryable<TUser> Users
        {
            get
            {
                // If you have some performance issues, then you can implement the IQueryable.
                return usersTable.GetAllUsers()?.AsQueryable();
            }
        }
    }
}