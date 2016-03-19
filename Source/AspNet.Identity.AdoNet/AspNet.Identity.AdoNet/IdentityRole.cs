namespace AspNet.Identity.AdoNet
{
    using System;
    using Microsoft.AspNet.Identity;

    /// <summary>Represents a security role; implements the ASP.NET Identity <see cref="IRole"/> interface.</summary>
    public class IdentityRole : IRole
    {
        /// <summary>Creates a new instance of the <see cref="IdentityRole"/> class.</summary>
        public IdentityRole() { }

        /// <summary>Creates a new instance of the <see cref="IdentityRole"/> class with a specific name.</summary>
        /// <param name="name">The name of the role.</param>
        public IdentityRole(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="IdentityRole"/>
        ///     class with the specified name and ID for the role.
        /// </summary>
        /// <param name="id">The unique ID of the role.</param>
        /// <param name="name">The name of the role.</param>
        public IdentityRole(string id, string name)
            : this(name)
        {
            Id = id;
        }

        /// <summary>Gets or sets the unique ID assigned to the role.</summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Gets or sets the name of the role.</summary>
        public string Name { get; set; }
    }
}