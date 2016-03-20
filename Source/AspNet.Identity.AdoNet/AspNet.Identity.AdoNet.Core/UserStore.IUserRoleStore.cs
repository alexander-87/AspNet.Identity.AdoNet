namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class UserStore<TUser> : IUserRoleStore<TUser>
    {
        /// <summary>Adds the given user to the specified role.</summary>
        /// <param name="user">The user to add to the role.</param>
        /// <param name="roleName">The role to add the user to.</param>
        /// <returns></returns>
        public Task AddToRoleAsync(TUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (String.IsNullOrEmpty(roleName))
                throw new ArgumentException("Role name cannot be null or empty.", nameof(roleName));

            var roleId = rolesTable.GetRoleIdByName(roleName);
            if (!String.IsNullOrEmpty(roleId))
                userRolesTable.AddUserToRole(user, roleId);

            return Task.FromResult<object>(null);
        }

        /// <summary>Returns all of the roles the given user belongs to.</summary>
        /// <param name="user">The user to get the roles of.</param>
        /// <returns></returns>
        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var roles = userRolesTable.GetRolesForUserId(user.Id);
            if (roles != null)
                return Task.FromResult<IList<string>>(roles.ToList());

            return Task.FromResult<IList<string>>(null);
        }

        /// <summary>Checks whether the given user is in the specified role.</summary>
        /// <param name="user">The user to check role membership for.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <returns>True if the given user is in the specified role; otherwise, false.</returns>
        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (String.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var roles = userRolesTable.GetRolesForUserId(user.Id);
            if (roles != null && roles.Contains(roleName))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        /// <summary>Removes the given user from the specified role.</summary>
        /// <param name="user">The user to remove.</param>
        /// <param name="roleName">The role to remove the user from.</param>
        /// <returns></returns>
        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (String.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var roleId = rolesTable.GetRoleIdByName(roleName);
            return Task.FromResult(userRolesTable.RemoveUserFromFromRole(user, roleId));
        }
    }
}