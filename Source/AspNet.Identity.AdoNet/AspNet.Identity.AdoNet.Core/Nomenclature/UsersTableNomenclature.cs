namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides naming information about the database table containing the application's users.</summary>
    public sealed class UsersTableNomenclature : TableNomenclature
    {
        /// <summary>Creates a new instance of the <see cref="UsersTableNomenclature"/> class.</summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="userIdColumnName">The name of the column containing the unique ID assigned to the user.</param>
        /// <param name="userNameColumnName">The name of the column containing the user's account name.</param>
        /// <param name="emailAddressColumnName">The name of the column containing the user's email address.</param>
        /// <param name="emailConfirmedColumnName">
        ///     The name of the column containing a value indicating whether the user's email address has been confirmed.
        /// </param>
        /// <param name="passwordHashColumnName">The name of the column containing the user's password hash.</param>
        /// <param name="securityStampColumnName">The name of the column containing the user's security stamp.</param>
        /// <param name="phoneNumberColumnName">The name of the column containing the user's phone number.</param>
        /// <param name="phoneNumberConfirmedColumnName">
        ///     The name of the column containing a value indicating whether the user's phone number has been confirmed.
        /// </param>
        /// <param name="twoFactorAuthorizationEnabledColumnName">
        ///     The name of the column containing a value indicating whether the user's account has two factor authorization enabled.
        /// </param>
        /// <param name="lockoutEndDateUtcColumnName">
        ///     The name of the column containing the date of when the user's account will no longer be locked out.
        /// </param>
        /// <param name="lockoutEnabledColumnName">
        ///     The name of the column containing a value indicating whether the user's account can be locked out.
        /// </param>
        /// <param name="accessFailedCountColumnName">
        ///     The name of the column containing the number of unsuccessful authentication attempts for the user's account.
        /// </param>
        public UsersTableNomenclature(string tableName,
                                      string userIdColumnName,
                                      string userNameColumnName,
                                      string emailAddressColumnName,
                                      string emailConfirmedColumnName,
                                      string passwordHashColumnName,
                                      string securityStampColumnName,
                                      string phoneNumberColumnName,
                                      string phoneNumberConfirmedColumnName,
                                      string twoFactorAuthorizationEnabledColumnName,
                                      string lockoutEndDateUtcColumnName,
                                      string lockoutEnabledColumnName,
                                      string accessFailedCountColumnName)
            : base(tableName)
        {
            ThrowIfParameterIsEmpty(userIdColumnName, userIdColumnName);
            ThrowIfParameterIsEmpty(userNameColumnName, userNameColumnName);
            ThrowIfParameterIsEmpty(emailAddressColumnName, emailAddressColumnName);
            ThrowIfParameterIsEmpty(emailConfirmedColumnName, emailConfirmedColumnName);
            ThrowIfParameterIsEmpty(passwordHashColumnName, passwordHashColumnName);
            ThrowIfParameterIsEmpty(securityStampColumnName, securityStampColumnName);
            ThrowIfParameterIsEmpty(phoneNumberColumnName, phoneNumberColumnName);
            ThrowIfParameterIsEmpty(phoneNumberConfirmedColumnName, phoneNumberConfirmedColumnName);
            ThrowIfParameterIsEmpty(twoFactorAuthorizationEnabledColumnName, twoFactorAuthorizationEnabledColumnName);
            ThrowIfParameterIsEmpty(lockoutEndDateUtcColumnName, lockoutEndDateUtcColumnName);
            ThrowIfParameterIsEmpty(lockoutEnabledColumnName, lockoutEnabledColumnName);
            ThrowIfParameterIsEmpty(accessFailedCountColumnName, accessFailedCountColumnName);

            UserIdColumnName = userIdColumnName;
            UserNameColumnName = userNameColumnName;
            EmailAddressColumnName = emailAddressColumnName;
            EmailConfirmedColumnName = emailConfirmedColumnName;
            PasswordHashColumnName = passwordHashColumnName;
            SecurityStampColumnName = securityStampColumnName;
            PhoneNumberColumnName = phoneNumberColumnName;
            PhoneNumberConfirmedColumnName = phoneNumberConfirmedColumnName;
            TwoFactorAuthorizationEnabledColumnName = twoFactorAuthorizationEnabledColumnName;
            LockoutEndDateUtcColumnName = lockoutEndDateUtcColumnName;
            LockoutEnabledColumnName = lockoutEnabledColumnName;
            AccessFailedCountColumnName = accessFailedCountColumnName;
        }

        /// <summary>Gets the name of the column containing the unique ID assigned to the user.</summary>
        public string UserIdColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the user's account name.</summary>
        public string UserNameColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the user's email address.</summary>
        public string EmailAddressColumnName { get; private set; }

        /// <summary>Gets the name of the column containing a value indicating whether the user's email address has been confirmed.</summary>
        public string EmailConfirmedColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the user's password hash.</summary>
        public string PasswordHashColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the user's security stamp.</summary>
        public string SecurityStampColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the user's phone number.</summary>
        public string PhoneNumberColumnName { get; private set; }

        /// <summary>Gets the name of the column containing a value indicating whether the user's phone number has been confirmed.</summary>
        public string PhoneNumberConfirmedColumnName { get; private set; }

        /// <summary>Gets the name of the column containing a value indicating whether the user's account has two factor authorization enabled.</summary>
        public string TwoFactorAuthorizationEnabledColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the date of when the user's account will no longer be locked out.</summary>
        public string LockoutEndDateUtcColumnName { get; private set; }

        /// <summary>Gets the name of the column containing a value indicating whether the user's account can be locked out.</summary>
        public string LockoutEnabledColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the number of unsuccessful authentication attempts for the user's account.</summary>
        public string AccessFailedCountColumnName { get; private set; }
    }
}