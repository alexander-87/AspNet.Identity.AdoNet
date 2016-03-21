namespace AspNet.Identity.AdoNet.Oracle
{
    /// <summary>Provides naming settings for each of the database objects.</summary>
    public class OracleContextNomenclature : IdentityContextNomenclature
    {
        /// <summary>
        ///     Creates a new instance of <see cref="OracleContextNomenclature"/>,
        ///     using the default naming settings for each of the database objects.
        /// </summary>
        public OracleContextNomenclature()
        {
            RolesTableNomenclature =
                new RolesTableNomenclature("ROLES", "ID", "ROLE_NAME");

            UserClaimsTableNomenclature =
                new UserClaimsTableNomenclature("USER_CLAIMS", "ID", "USER_ID", "CLAIM_TYPE", "CLAIM_VALUE");

            UserLoginsTableNomenclature =
                new UserLoginsTableNomenclature("USER_LOGINS", "USER_ID", "PROVIDER_NAME", "PROVIDER_KEY");

            UserRolesTableNomenclature =
                new UserRolesTableNomenclature("USER_ROLE_MEMBERSHIP", "USER_ID", "ROLE_ID");

            UsersTableNomenclature =
                new UsersTableNomenclature("USERS", "ID", "EMAIL", "EMAIL_CONFIRMED", "PASSWORD_HASH", "SECURITY_STAMP",
                                           "PHONE_NUMBER", "PHONE_NUMBER_CONFIRMED", "TWO_FACTOR_AUTH_ENABLED",
                                           "LOCKOUT_END_DATE_UTC", "LOCKOUT_ENABLED", "ACCESS_FAILED_COUNT", "USERNAME");

        }
    }
}