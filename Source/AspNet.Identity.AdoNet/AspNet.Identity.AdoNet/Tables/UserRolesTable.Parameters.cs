namespace AspNet.Identity.AdoNet
{
    partial class UserRolesTable
    {
        /// <summary>Contains constants for each of the parameters used in queries, organized by method name.</summary>
        public static class Parameters
        {
            /// <summary>Contains constants for each of the parameter names used by <see cref="UserRolesTable.DeleteByUserId(string)"/>.</summary>
            public static class DeleteByUserId
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserRolesTable.AddUserToRole(Microsoft.AspNet.Identity.IUser{string}, string)"/>.</summary>
            public static class AddUserToRole
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";

                /// <summary>The name of the "RoleId" parameter used in the query.</summary>
                public const string RoleId = "ROLEID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserRolesTable.GetRolesForUserId(string)"/>.</summary>
            public static class GetRolesForUserId
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserRolesTable.RemoveUserFromFromRole(Microsoft.AspNet.Identity.IUser{string}, string)"/>.</summary>
            public static class RemoveUserFromFromRole
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";

                /// <summary>The name of the "RoleId" parameter used in the query.</summary>
                public const string RoleId = "ROLEID";
            }
        }
    }
}