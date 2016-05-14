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
                new RolesTableNomenclature(tableName: "ROLES",
                                           roleIdColumnName: "ID",
                                           roleNameColumnName: "ROLE_NAME");
            UserClaimsTableNomenclature =
                new UserClaimsTableNomenclature(tableName: "USER_CLAIMS",
                                                claimIdColumnName: "ID",
                                                userIdColumnName: "USER_ID",
                                                claimTypeColumnName: "CLAIM_TYPE",
                                                claimValueColumnName: "CLAIM_VALUE");
            UserLoginsTableNomenclature =
                new UserLoginsTableNomenclature(tableName: "USER_LOGINS",
                                                userIdColumnName: "USER_ID",
                                                providerNameColumnName: "PROVIDER_NAME",
                                                providerKeyColumnName: "PROVIDER_KEY");
            UserRolesTableNomenclature =
                new UserRolesTableNomenclature(tableName: "USER_ROLES",
                                               userIdColumnName: "USER_ID",
                                               roleIdColumnName: "ROLE_ID");
            UsersTableNomenclature =
                new UsersTableNomenclature(tableName: "USERS",
                                           userIdColumnName: "ID",
                                           userNameColumnName: "USERNAME",
                                           emailAddressColumnName: "EMAIL",
                                           emailConfirmedColumnName: "EMAIL_CONFIRMED",
                                           passwordHashColumnName: "PASSWORD_HASH",
                                           securityStampColumnName: "SECURITY_STAMP",
                                           phoneNumberColumnName: "PHONE_NUMBER",
                                           phoneNumberConfirmedColumnName: "PHONE_NUMBER_CONFIRMED",
                                           twoFactorAuthorizationEnabledColumnName: "TWO_FACTOR_AUTH_ENABLED",
                                           lockoutEndDateUtcColumnName: "LOCKOUT_END_DATE_UTC",
                                           lockoutEnabledColumnName: "LOCKOUT_ENABLED",
                                           accessFailedCountColumnName: "ACCESS_FAILED_COUNT");
        }
    }
}