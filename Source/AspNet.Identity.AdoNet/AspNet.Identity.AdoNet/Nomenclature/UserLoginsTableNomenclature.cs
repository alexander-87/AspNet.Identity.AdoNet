namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides naming information about the database table containing user's external logins.</summary>
    public sealed class UserLoginsTableNomenclature : TableNomenclature
    {
        /// <summary>Creates a new instance of the <see cref="UserLoginsTableNomenclature"/> class.</summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="userIdColumnName">The name of the column containing the unique ID of the user associated with the login.</param>
        /// <param name="providerNameColumnName">The name of the column containing the name of the login provider.</param>
        /// <param name="providerKeyColumnName">The name of the column containing the login provider's unique key for the user.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if any of the parameters are <c>null</c>, an empty string, or only consist of white space characters.
        /// </exception>
        public UserLoginsTableNomenclature(string tableName,
                                           string userIdColumnName,
                                           string providerNameColumnName,
                                           string providerKeyColumnName)
            : base(tableName)
        {
            ThrowIfParameterIsEmpty(userIdColumnName, nameof(userIdColumnName));
            ThrowIfParameterIsEmpty(providerNameColumnName, nameof(providerNameColumnName));
            ThrowIfParameterIsEmpty(providerKeyColumnName, nameof(providerKeyColumnName));

            UserIdColumnName = userIdColumnName;
            ProviderNameColumnName = providerNameColumnName;
            ProviderKeyColumnName = providerKeyColumnName;
        }

        /// <summary>Gets the name of the column containing the unique ID of the user associated with the login.</summary>
        public string UserIdColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the name of the login provider.</summary>
        public string ProviderNameColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the login provider's unique key for the user.</summary>
        public string ProviderKeyColumnName { get; private set; }
    }
}