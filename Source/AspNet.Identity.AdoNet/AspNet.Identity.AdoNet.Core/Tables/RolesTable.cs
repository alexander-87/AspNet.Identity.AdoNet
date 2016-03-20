namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    
    /// <summary>Represents the table in the database containing information about each of the application's roles.</summary>
    public sealed class RolesTable<TRole> : RolesTable
        where TRole : IdentityRole, new()
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="RolesTable"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the <see cref="IIdentityDbContext.RolesTableCommands"/>
        ///     property of the <paramref name="dbContext"/> parameter is <c>null</c>.
        /// </exception>
        internal RolesTable(IIdentityDbContext dbContext)
            : base(dbContext)
        {
            ThrowIfTableCommandsIsNull(dbContext, x => x.RolesTableCommands);
        }

        /// <summary>Deletes the role with the specified unique ID from the table.</summary>
        /// <param name="roleId">The unique ID of the role to delete.</param>
        public int DeleteRoleById(string roleId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.DeleteRoleById.RoleId] = roleId
            };
            return ExecuteNonQuery(DbContext.RolesTableCommands.DeleteRoleById, parameterValues);
        }

        /// <summary>Inserts a new <typeparamref name="TRole"/> in the Roles table.</summary>
        /// <param name="role">The <typeparamref name="TRole"/> to insert.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if a <c>null</c> value is specified for the <paramref name="role"/> parameter.
        /// </exception>
        public int InsertRole(TRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.InsertRole.RoleId] = role.Id,
                [Parameters.InsertRole.RoleName] = role.Name
            };
            return ExecuteNonQuery(DbContext.RolesTableCommands.InsertRole, parameterValues);
        }

        /// <summary>Returns the name of the role with the given <see cref="IdentityRole.Id"/>.</summary>
        /// <param name="roleId">The unique ID of the role.</param>
        /// <returns>If a role is found with the specified ID, the name of the role; otherwise <c>null</c>.</returns>
        public string GetRoleNameById(string roleId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetRoleNameById.RoleId] = roleId
            };
            return ExecuteScalar<string>(DbContext.RolesTableCommands.GetRoleNameById, parameterValues);
        }

        /// <summary>Returns the unique ID of the role with the specified name.</summary>
        /// <param name="roleName">The name of the role to get the ID of.</param>
        /// <returns>The unique ID of the role with the specified name.</returns>
        public string GetRoleIdByName(string roleName)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetRoleIdByName.RoleName] = roleName
            };
            var roleId = ExecuteScalar<Guid>(DbContext.RolesTableCommands.GetRoleIdByName, parameterValues);
            return roleId == default(Guid)
                          ? null
                          : roleId.ToString("D");
        }

        /// <summary>Gets the <typeparamref name="TRole"/> with the specified role ID.</summary>
        /// <param name="roleId">The unique ID of the <typeparamref name="TRole"/> to get.</param>
        /// <returns>
        ///     The corresponding <typeparamref name="TRole"/> if one is found with the specified role ID; otherwise <c>null</c>.
        /// </returns>
        public TRole GetRoleById(string roleId)
        {
            var roleName = GetRoleNameById(roleId);
            if (roleName == null)
                return null;

            return new TRole { Id = roleId, Name = roleName };
        }

        /// <summary>Gets the <typeparamref name="TRole"/> with the specified role name.</summary>
        /// <param name="roleName">The name of the <typeparamref name="TRole"/> to get.</param>
        /// <returns>
        ///     The corresponding <typeparamref name="TRole"/> if one is found with the specified name; otherwise <c>null</c>.
        /// </returns>
        public TRole GetRoleByName(string roleName)
        {
            var roleId = GetRoleIdByName(roleName);
            if (roleId == null)
                return null;

            return new TRole { Id = roleId, Name = roleName };
        }

        /// <summary>Updates the attributes of an <typeparamref name="TRole"/> that already exists in the database.</summary>
        /// <param name="role">The <typeparamref name="TRole"/> to update the attributes of.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if a <c>null</c> value is specified for the <paramref name="role"/> parameter.
        /// </exception>
        public int UpdateRole(TRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.UpdateRole.RoleId] = role.Id,
                [Parameters.UpdateRole.RoleName] = role.Name
            };
            return ExecuteNonQuery(DbContext.RolesTableCommands.UpdateRole, parameterValues);
        }

        /// <summary>Get the all <typeparamref name="TRole"/>s defined in the database.</summary>
        /// <returns>All of the <typeparamref name="TRole"/>s defined in the database.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public ICollection<TRole> GetAllRoles()
        {
            var roles = new List<TRole>();
            using (var dataTable = ExecuteReader(DbContext.RolesTableCommands.GetAllRoles))
            {
                var table = DbContext.ContextNomenclature.RolesTableNomenclature;
                foreach (DataRow record in dataTable.Rows)
                {
                    var roleId = record.Field<string>(table.RoleIdColumnName);
                    var roleName = record.Field<string>(table.RoleNameColumnName);
                    roles.Add(new TRole { Id = roleId, Name = roleName });
                }
            }
            return roles;
        }
    }
}