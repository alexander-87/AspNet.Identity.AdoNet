namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;

    /// <summary>Represents the table in the database containing information about the application's user's claims.</summary>
    public sealed partial class UserClaimsTable : Table
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="UserClaimsTable"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        internal UserClaimsTable(IIdentityDbContext dbContext) : base(dbContext)
        {
            ThrowIfTableCommandsIsNull(dbContext, x => x.UserClaimsTableCommands);
        }

        /// <summary>Returns a <see cref="ClaimsIdentity"/> instance given a userId.</summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public ClaimsIdentity GetAllClaimsForUser(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetAllClaimsForUser.UserId] = userId
            };
            using (var dataTable = ExecuteReader(DbContext.UserClaimsTableCommands.GetAllClaimsForUser, parameterValues))
            {
                var claims = new List<Claim>();
                var table = DbContext.UserClaimsTableCommands.TableNomenclature;
                foreach (DataRow record in dataTable.Rows)
                {
                    var claimType = record.Field<string>(table.ClaimTypeColumnName);
                    var claimValue = record.Field<string>(table.ClaimValueColumnName);
                    claims.Add(new Claim(claimType, claimValue));
                }
                return new ClaimsIdentity(claims);
            }
        }

        /// <summary>Deletes all claims from a specific user.</summary>
        /// <param name="userId">The unique ID of the user whose claims are to be deleted.</param>
        /// <returns></returns>
        public int DeleteAllClaimsForUser(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.DeleteAllClaimsForUser.UserId] = userId
            };
            return ExecuteNonQuery(DbContext.UserClaimsTableCommands.DeleteAllClaimsForUser, parameterValues);
        }

        /// <summary>
        /// Inserts a new claim in UserClaims table
        /// </summary>
        /// <param name="claim">User's claim to be added</param>
        /// <param name="userId">User's id</param>
        /// <returns></returns>
        public int AddClaimForUser(Claim claim, string userId)
        {
            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.AddClaimForUser.ClaimType] = claim.Type,
                [Parameters.AddClaimForUser.ClaimValue] = claim.Value,
                [Parameters.AddClaimForUser.UserId] = userId
            };
            return ExecuteNonQuery(DbContext.UserClaimsTableCommands.AddClaimForUser, parameterValues);
        }

        /// <summary>
        /// Deletes a claim from a user 
        /// </summary>
        /// <param name="user">The user to have a claim deleted</param>
        /// <param name="claim">A claim to be deleted from user</param>
        /// <returns></returns>
        public int RemoveClaimForUser(IUser<string> user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.RemoveClaimForUser.ClaimType] = claim.Type,
                [Parameters.RemoveClaimForUser.ClaimValue] = claim.Value,
                [Parameters.RemoveClaimForUser.UserId] = user.Id
            };
            return ExecuteNonQuery(DbContext.UserClaimsTableCommands.RemoveClaimForUser, parameterValues);
        }
    }
}