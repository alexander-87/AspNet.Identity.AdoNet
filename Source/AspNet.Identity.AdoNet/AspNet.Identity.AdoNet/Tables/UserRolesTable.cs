namespace AspNet.Identity.AdoNet
{
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.AspNet.Identity;

    /// <summary>
    ///     Represents the table in the database containing information
    ///     about each of the application's users and their associated roles.
    /// </summary>
    public sealed partial class UserRolesTable : Table
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="UserRolesTable"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        internal UserRolesTable(IIdentityDbContext dbContext)
            : base(dbContext)
        {
            ThrowIfTableCommandsIsNull(dbContext, x => x.UserRolesTableCommands);
        }

        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public ICollection<string> GetRolesForUserId(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetRolesForUserId.UserId] = userId
            };
            using (var dataTable = ExecuteReader(DbContext.UserRolesTableCommands.GetRolesForUserId, parameterValues))
            {
                var roles = new List<string>();
                var table = DbContext.ContextNomenclature.RolesTableNomenclature;
                foreach (DataRow record in dataTable.Rows)
                {
                    var roleName = record.Field<string>(table.RoleNameColumnName);
                    roles.Add(roleName);
                }
                return roles;
            }
        }

        /// <summary>Deletes all role memberships for a specific user.</summary>
        /// <param name="userId">The unique ID of the user whose role membership is to be deleted.</param>
        /// <returns></returns>
        public int DeleteByUserId(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.DeleteByUserId.UserId] = userId
            };
            return ExecuteNonQuery(DbContext.UserRolesTableCommands.DeleteByUserId, parameterValues);
        }

        /// <summary>Adds the given user to the specified role.</summary>
        /// <param name="user">The user to add to the role.</param>
        /// <param name="roleId">The unique ID of the role to add the user to.</param>
        /// <returns></returns>
        public int AddUserToRole(IUser<string> user, string roleId)
        {
            if (user == null)
                throw new System.ArgumentNullException(nameof(user));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.AddUserToRole.UserId] = user.Id,
                [Parameters.AddUserToRole.RoleId] = roleId
            };
            return ExecuteNonQuery(DbContext.UserRolesTableCommands.AddUserToRole, parameterValues);
        }

        /// <summary>Removes a specific user from the specified role.</summary>
        /// <param name="user">The <see cref="IUser{TKey}"/> to remove from the role.</param>
        /// <param name="roleId">The unique ID of the role to remove from the user.</param>
        /// <returns></returns>
        public int RemoveUserFromFromRole(IUser<string> user, string roleId)
        {
            if (user == null)
                throw new System.ArgumentNullException(nameof(user));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.RemoveUserFromFromRole.UserId] = user.Id,
                [Parameters.RemoveUserFromFromRole.RoleId] = roleId
            };
            return ExecuteNonQuery(DbContext.UserRolesTableCommands.RemoveUserFromFromRole, parameterValues);
        }
    }
}