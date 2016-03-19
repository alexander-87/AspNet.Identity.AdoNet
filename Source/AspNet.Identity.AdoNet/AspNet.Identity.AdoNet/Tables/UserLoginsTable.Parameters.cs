namespace AspNet.Identity.AdoNet
{
    partial class UserLoginsTable
    {
        /// <summary>Contains constants for each of the parameters used in queries, organized by method name.</summary>
        public static class Parameters
        {
            /// <summary>Contains constants for each of the parameter names used by <see cref="UserLoginsTable.AddNewUserLogin(Microsoft.AspNet.Identity.IUser{string}, Microsoft.AspNet.Identity.UserLoginInfo)"/>.</summary>
            public static class AddNewUserLogin
            {
                /// <summary>The name of the "ProviderKey" parameter used in the query.</summary>
                public const string ProviderKey = "PROVIDERKEY";

                /// <summary>The name of the "ProviderName" parameter used in the query.</summary>
                public const string ProviderName = "PROVIDERNAME";

                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserLoginsTable.DeleteAllLoginsForUserById(string)"/>.</summary>
            public static class DeleteAllLoginsForUserById
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserLoginsTable.DeleteUserLogin(Microsoft.AspNet.Identity.IUser{string}, Microsoft.AspNet.Identity.UserLoginInfo)"/>.</summary>
            public static class DeleteUserLogin
            {
                /// <summary>The name of the "ProviderKey" parameter used in the query.</summary>
                public const string ProviderKey = "PROVIDERKEY";

                /// <summary>The name of the "ProviderName" parameter used in the query.</summary>
                public const string ProviderName = "PROVIDERNAME";

                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserLoginsTable.GetAllUserLoginsForUserId(string)"/>.</summary>
            public static class GetAllUserLoginsForUserId
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserLoginsTable.GetUserIdByLogin(Microsoft.AspNet.Identity.UserLoginInfo)"/>.</summary>
            public static class GetUserIdByLogin
            {
                /// <summary>The name of the "ProviderKey" parameter used in the query.</summary>
                public const string ProviderKey = "PROVIDERKEY";

                /// <summary>The name of the "ProviderName" parameter used in the query.</summary>
                public const string ProviderName = "PROVIDERNAME";
            }
        }
    }
}