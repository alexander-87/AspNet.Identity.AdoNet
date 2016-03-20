namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides <see cref="DatabaseCommand"/> objects for the methods within the <see cref="UserClaimsTable"/>.</summary>
    public interface IUserClaimsTableCommands : ITableCommands
    {
        /// <summary>
        ///     Gets the <see cref="UserClaimsTableNomenclature"/> containing information
        ///     about the database table containing each of the application's roles.
        /// </summary>
        UserClaimsTableNomenclature TableNomenclature { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserClaimsTable.GetAllClaimsForUser(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand GetAllClaimsForUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserClaimsTable.DeleteAllClaimsForUser(string)"/> method is invoked.
        /// </summary>
        DatabaseCommand DeleteAllClaimsForUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserClaimsTable.AddClaimForUser(System.Security.Claims.Claim, string)"/> method is invoked.
        /// </summary>
        DatabaseCommand AddClaimForUser { get; }

        /// <summary>
        ///     Gets the <see cref="DatabaseCommand"/> to be executed when the
        ///     <see cref="UserClaimsTable.RemoveClaimForUser(Microsoft.AspNet.Identity.IUser{string}, System.Security.Claims.Claim)"/> method is invoked.
        /// </summary>
        DatabaseCommand RemoveClaimForUser { get; }
    }
}