namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    partial class RoleStore<TRole> : IRoleStore<TRole, string>
    {
        /// <summary>Create a new role.</summary>
        Task IRoleStore<TRole, string>.CreateAsync(TRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(rolesTable.InsertRole(role));
        }

        /// <summary>Deletes a role.</summary>
        Task IRoleStore<TRole, string>.DeleteAsync(TRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(rolesTable.DeleteRoleById(role.Id));
        }

        /// <summary>Find's a role by it's unique ID.</summary>
        Task<TRole> IRoleStore<TRole, string>.FindByIdAsync(string roleId)
        {
            return Task.FromResult(rolesTable.GetRoleById(roleId) as TRole);
        }

        /// <summary>Find's a role by it's name.</summary>
        Task<TRole> IRoleStore<TRole, string>.FindByNameAsync(string roleName)
        {
            return Task.FromResult(rolesTable.GetRoleByName(roleName) as TRole);
        }

        /// <summary>Updates a role in the database.</summary>
        Task IRoleStore<TRole, string>.UpdateAsync(TRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult<object>(rolesTable.UpdateRole(role));
        }
    }
}