namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides naming information about the database table containing user claims.</summary>
    public sealed class UserClaimsTableNomenclature : TableNomenclature
    {
        /// <summary>Creates a new instance of the <see cref="UserClaimsTableNomenclature"/> class.</summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="claimIdColumnName">The name of the column containing the claim's unique ID.</param>
        /// <param name="userIdColumnName">The name of the column containing the unique ID of the user who owns the claim.</param>
        /// <param name="claimTypeColumnName">The name of the column containing the claim type.</param>
        /// <param name="claimValueColumnName">The name of the column containing the claim value.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if any of the parameters are <c>null</c>, an empty string, or only consist of white space characters.
        /// </exception>
        public UserClaimsTableNomenclature(string tableName,
                                           string claimIdColumnName,
                                           string userIdColumnName,
                                           string claimTypeColumnName,
                                           string claimValueColumnName)
            : base(tableName)
        {
            ThrowIfParameterIsEmpty(claimIdColumnName, nameof(claimIdColumnName));
            ThrowIfParameterIsEmpty(userIdColumnName, nameof(userIdColumnName));
            ThrowIfParameterIsEmpty(claimTypeColumnName, nameof(claimTypeColumnName));
            ThrowIfParameterIsEmpty(claimValueColumnName, nameof(claimValueColumnName));

            ClaimIdColumnName = claimIdColumnName;
            UserIdColumnName = userIdColumnName;
            ClaimTypeColumnName = claimTypeColumnName;
            ClaimValueColumnName = claimValueColumnName;
        }

        /// <summary>Gets the name of the column containing the claim's unique ID.</summary>
        public string ClaimIdColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the unique ID of the user who owns the claim.</summary>
        public string UserIdColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the claim type.</summary>
        public string ClaimTypeColumnName { get; private set; }

        /// <summary>Gets the name of the column containing the claim value.</summary>
        public string ClaimValueColumnName { get; private set; }
    }
}