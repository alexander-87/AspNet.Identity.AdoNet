namespace AspNet.Identity.AdoNet
{
    /// <remarks>This is a non-generic version of the <see cref="UsersTable{TUser}"/> class to allow simplified access to the constants herein.</remarks>
    public abstract class UsersTable : Table
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="UsersTable"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if the <paramref name="dbContext"/> parameter is <c>null</c>.
        /// </exception>
        protected UsersTable(IIdentityDbContext dbContext) : base(dbContext) { }

        /// <summary>Contains constants for each of the parameters used in queries, organized by method name.</summary>
        public static class Parameters
        {
            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.AddNewUser(TUser)"/>.</summary>
            public static class AddNewUser
            {
                /// <summary>The name of the "UserName" parameter used in the query.</summary>
                public const string UserName = "USERNAME";

                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";

                /// <summary>The name of the "PasswordHash" parameter used in the query.</summary>
                public const string PasswordHash = "PASSWORDHASH";

                /// <summary>The name of the "SecurityStamp" parameter used in the query.</summary>
                public const string SecurityStamp = "SECSTAMP";

                /// <summary>The name of the "Email" parameter used in the query.</summary>
                public const string Email = "EMAIL";

                /// <summary>The name of the "EmailConfirmed" parameter used in the query.</summary>
                public const string EmailConfirmed = "EMAILCONFIRMED";

                /// <summary>The name of the "PhoneNumber" parameter used in the query.</summary>
                public const string PhoneNumber = "PHONENUMBER";

                /// <summary>The name of the "PhoneNumberConfirmed" parameter used in the query.</summary>
                public const string PhoneNumberConfirmed = "PHONENUMBERCONFIRMED";

                /// <summary>The name of the "AccessFailedCount" parameter used in the query.</summary>
                public const string AccessFailedCount = "ACCESSFAILEDCOUNT";

                /// <summary>The name of the "LockoutEnabled" parameter used in the query.</summary>
                public const string LockoutEnabled = "LOCKOUTENABLED";

                /// <summary>The name of the "LockoutEndDateUtc" parameter used in the query.</summary>
                public const string LockoutEndDateUtc = "LOCKOUTENDDATEUTC";

                /// <summary>The name of the "TwoFactorAuthEnabled" parameter used in the query.</summary>
                public const string TwoFactorAuthEnabled = "TWOFACTORENABLED";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.DeleteUser(TUser)"/>.</summary>
            public static class DeleteUser
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetPasswordHashForUser(string)"/>.</summary>
            public static class GetPasswordHashForUser
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetSecurityStampForUser(string)"/>.</summary>
            public static class GetSecurityStampForUser
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetUserById(string)"/>.</summary>
            public static class GetUserById
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetUserIdByUserName(string)"/>.</summary>
            public static class GetUserIdByUserName
            {
                /// <summary>The name of the "UserName" parameter used in the query.</summary>
                public const string UserName = "USERNAME";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetUserNameByUserId(string)"/>.</summary>
            public static class GetUserNameByUserId
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetUsersByEmail(string)"/>.</summary>
            public static class GetUsersByEmail
            {
                /// <summary>The name of the "EmailAddress" parameter used in the query.</summary>
                public const string EmailAddress = "EMAIL";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.GetUsersByUserName(string)"/>.</summary>
            public static class GetUsersByUserName
            {
                /// <summary>The name of the "UserName" parameter used in the query.</summary>
                public const string UserName = "USERNAME";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.SetPasswordHashForUser(string, string)"/>.</summary>
            public static class SetPasswordHashForUser
            {
                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";

                /// <summary>The name of the "PasswordHash" parameter used in the query.</summary>
                public const string PasswordHash = "PASSWORDHASH";
            }

            /// <summary>Contains constants for each of the parameter names used by <see cref="UsersTable{TUser}.UpdateUser(TUser)"/>.</summary>
            public static class UpdateUser
            {
                /// <summary>The name of the "UserName" parameter used in the query.</summary>
                public const string UserName = "USERNAME";

                /// <summary>The name of the "UserId" parameter used in the query.</summary>
                public const string UserId = "USERID";

                /// <summary>The name of the "PasswordHash" parameter used in the query.</summary>
                public const string PasswordHash = "PASSWORDHASH";

                /// <summary>The name of the "SecurityStamp" parameter used in the query.</summary>
                public const string SecurityStamp = "SECSTAMP";

                /// <summary>The name of the "Email" parameter used in the query.</summary>
                public const string Email = "EMAIL";

                /// <summary>The name of the "EmailConfirmed" parameter used in the query.</summary>
                public const string EmailConfirmed = "EMAILCONFIRMED";

                /// <summary>The name of the "PhoneNumber" parameter used in the query.</summary>
                public const string PhoneNumber = "PHONENUMBER";

                /// <summary>The name of the "PhoneNumberConfirmed" parameter used in the query.</summary>
                public const string PhoneNumberConfirmed = "PHONENUMBERCONFIRMED";

                /// <summary>The name of the "AccessFailedCount" parameter used in the query.</summary>
                public const string AccessFailedCount = "ACCESSFAILEDCOUNT";

                /// <summary>The name of the "LockoutEnabled" parameter used in the query.</summary>
                public const string LockoutEnabled = "LOCKOUTENABLED";

                /// <summary>The name of the "LockoutEndDateUtc" parameter used in the query.</summary>
                public const string LockoutEndDateUtc = "LOCKOUTENDDATEUTC";

                /// <summary>The name of the "TwoFactorAuthEnabled" parameter used in the query.</summary>
                public const string TwoFactorAuthEnabled = "TWOFACTORENABLED";
            }
        }
    }
}