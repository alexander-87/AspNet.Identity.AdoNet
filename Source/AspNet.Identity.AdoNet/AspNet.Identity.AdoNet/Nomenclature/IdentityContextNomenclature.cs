namespace AspNet.Identity.AdoNet
{
    /// <summary>
    ///     Concrete implementation of <see cref="IContextNomenclature"/>,
    ///     providing naming information for each of the database objects.
    /// </summary>
    public abstract class IdentityContextNomenclature : IContextNomenclature
    {
        /// <summary>Gets or sets the <see cref="AdoNet.RolesTableNomenclature"/> for the current <see cref="IdentityContextNomenclature"/>.</summary>
        public RolesTableNomenclature RolesTableNomenclature { get; set; }

        /// <summary>Gets or sets the <see cref="AdoNet.UserClaimsTableNomenclature"/> for the current <see cref="IdentityContextNomenclature"/>.</summary>
        public UserClaimsTableNomenclature UserClaimsTableNomenclature { get; set; }

        /// <summary>Gets or sets the <see cref="AdoNet.UserLoginsTableNomenclature"/> for the current <see cref="IdentityContextNomenclature"/>.</summary>
        public UserLoginsTableNomenclature UserLoginsTableNomenclature { get; set; }

        /// <summary>Gets or sets the <see cref="AdoNet.UserRolesTableNomenclature"/> for the current <see cref="IdentityContextNomenclature"/>.</summary>
        public UserRolesTableNomenclature UserRolesTableNomenclature { get; set; }

        /// <summary>Gets or sets the <see cref="AdoNet.UsersTableNomenclature"/> for the current <see cref="IdentityContextNomenclature"/>.</summary>
        public UsersTableNomenclature UsersTableNomenclature { get; set; }
    }
}