namespace AspNet.Identity.AdoNet
{
    /// <summary>Provides naming information for each of the database tables.</summary>
    public interface IContextNomenclature
    {
        /// <summary>Gets the <see cref="AdoNet.RolesTableNomenclature"/> for the current <see cref="IContextNomenclature"/>.</summary>
        RolesTableNomenclature RolesTableNomenclature { get; }

        /// <summary>Gets the <see cref="AdoNet.UserClaimsTableNomenclature"/> for the current <see cref="IContextNomenclature"/>.</summary>
        UserClaimsTableNomenclature UserClaimsTableNomenclature { get; }

        /// <summary>Gets the <see cref="AdoNet.UserLoginsTableNomenclature"/> for the current <see cref="IContextNomenclature"/>.</summary>
        UserLoginsTableNomenclature UserLoginsTableNomenclature { get; }

        /// <summary>Gets the <see cref="AdoNet.UserRolesTableNomenclature"/> for the current <see cref="IContextNomenclature"/>.</summary>
        UserRolesTableNomenclature UserRolesTableNomenclature { get; }

        /// <summary>Gets the <see cref="AdoNet.UsersTableNomenclature"/> for the current <see cref="IContextNomenclature"/>.</summary>
        UsersTableNomenclature UsersTableNomenclature { get; }
    }
}