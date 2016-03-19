namespace AspNet.Identity.AdoNet
{
    using System;
    using Microsoft.AspNet.Identity;

    /// <summary>Represents an application user; implements the ASP.NET Identity <see cref="IUser"/> interface.</summary>
    public class IdentityUser : IUser, IDisposable
    {
        /// <summary>Creates a new instance of the <see cref="IdentityUser"/> class.</summary>
        public IdentityUser() { }

        /// <summary>Creates a new instance of the <see cref="IdentityUser"/> class with a specific user name.</summary>
        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        /// <summary>Gets or set the unique ID assigned to the user.</summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Gets or sets the unique user name assigned to the user.</summary>
        public string UserName { get; set; }

        /// <summary>Gets or sets the email address associated with the user.</summary>
        public virtual string Email { get; set; }

        /// <summary>Gets or sets the whether the <see cref="Email"/> has been confirmed.</summary>
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>Gets or sets the hash generated form the user's password.</summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        ///     Gets or sets a random value that should change whenever a users
        ///     credentials have changed (password changed, login removed).
        /// </summary>
        public virtual string SecurityStamp { get; set; }

        /// <summary>Gets or sets the phone number associated with the user.</summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>Gets or sets whether the <see cref="PhoneNumber"/> has been confirmed.</summary>
        public virtual bool PhoneNumberConfirmed { get; set; }

        /// <summary>Gets or sets whether two factor authentication is enabled for the user.</summary>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DateTime"/> in UTC when the user's account will
        ///     no longer be locked out; any time in the past is considered not locked out.
        /// </summary>
        public virtual DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>Gets or sets the whether the user's account has the lockout feature enabled.</summary>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>Gets or sets the number of failed login attempts for the user; used for the purposes of lockout.</summary>
        public virtual int AccessFailedCount { get; set; }

        #region IDisposable Support

        /// <summary>This field is used to detect redundant calls to the <see cref="Dispose()"/> method.</summary>
        bool disposedValue;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing">
        ///     Indicates whether <see cref="Dispose()"/> has already been called (i.e. whether resources have already been released).
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
                disposedValue = true;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // This code added to correctly implement the disposable pattern.
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}