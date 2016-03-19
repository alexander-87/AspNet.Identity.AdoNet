namespace AspNet.Identity.AdoNet
{
    using System.Linq;
    using Microsoft.AspNet.Identity;

    partial class RoleStore<TRole> : IQueryableRoleStore<TRole>
    {
        /// <summary>Get all Roles defined.</summary>
        /// <remarks>
        ///     This code is a loose implementation.
        ///     An occurrence of a performance problem is when you get a large amount of data.
        /// </remarks>
        IQueryable<TRole> IQueryableRoleStore<TRole, string>.Roles
        {
            get
            {
                // If you have some performance issues, then you can implement the IQueryable.
                return rolesTable.GetAllRoles()?.AsQueryable();
            }
        }
    }
}