namespace AspNet.Identity.AdoNet
{
    partial class UserClaimsTable
    {
        /// <summary>Contains constants for each of the parameters used in queries, organized by method name.</summary>
        public static class Parameters
        {
            /// <summary>Contains constants for each of the parameter names used by <see cref="UserClaimsTable.DeleteAllClaimsForUser(string)"/>.</summary>
            public static class DeleteAllClaimsForUser
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserClaimsTable.GetAllClaimsForUser(string)"/>.</summary>
            public static class GetAllClaimsForUser
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserClaimsTable.AddClaimForUser(System.Security.Claims.Claim, string)"/>.</summary>
            public static class AddClaimForUser
            {
                /// <summary>The name of the "ClaimType" parameter used in the query.</summary>
                public const string ClaimType = "CLAIMTYPE";

                /// <summary>The name of the "ClaimValue" parameter used in the query.</summary>
                public const string ClaimValue = "CLAIMVALUE";

                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UserClaimsTable.RemoveClaimForUser(Microsoft.AspNet.Identity.IUser{string}, System.Security.Claims.Claim)"/>.</summary>
            public static class RemoveClaimForUser
            {
                /// <summary>The name of the "ClaimType" parameter used in the query.</summary>
                public const string ClaimType = "CLAIMTYPE";

                /// <summary>The name of the "ClaimValue" parameter used in the query.</summary>
                public const string ClaimValue = "CLAIMVALUE";

                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }
        }
    }
}