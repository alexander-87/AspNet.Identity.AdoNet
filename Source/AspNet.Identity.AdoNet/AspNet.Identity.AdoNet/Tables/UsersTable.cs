namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>Represents the table in the database containing information about each of the application's users.</summary>
    /// <typeparam name="TUser">The type of <see cref="IdentityUser"/>.</typeparam>
    public sealed class UsersTable<TUser> : UsersTable
        where TUser : IdentityUser, new()
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="UsersTable{TUser}"/>
        ///     class with the specified <see cref="IIdentityDbContext"/>.
        /// </summary>
        /// <param name="dbContext">
        ///     Instance of <see cref="IIdentityDbContext"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <see cref="IIdentityDbContext.UsersTableCommands"/>
        ///     property of the <paramref name="dbContext"/> parameter is <c>null</c>.
        /// </exception>
        internal UsersTable(IIdentityDbContext dbContext)
            : base(dbContext)
        {
            ThrowIfTableCommandsIsNull(dbContext, x => x.UsersTableCommands);
        }

        /// <summary>Adds a new user in the table.</summary>
        /// <param name="user">The user to add.</param>
        /// <returns></returns>
        public int AddNewUser(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.AddNewUser.UserName] = user.UserName,
                [Parameters.AddNewUser.UserId] = user.Id,
                [Parameters.AddNewUser.PasswordHash] = user.PasswordHash,
                [Parameters.AddNewUser.SecurityStamp] = user.SecurityStamp,
                [Parameters.AddNewUser.Email] = user.Email,
                [Parameters.AddNewUser.EmailConfirmed] = user.EmailConfirmed,
                [Parameters.AddNewUser.PhoneNumber] = user.PhoneNumber,
                [Parameters.AddNewUser.PhoneNumberConfirmed] = user.PhoneNumberConfirmed,
                [Parameters.AddNewUser.AccessFailedCount] = user.AccessFailedCount,
                [Parameters.AddNewUser.LockoutEnabled] = user.LockoutEnabled,
                [Parameters.AddNewUser.LockoutEndDateUtc] = user.LockoutEndDateUtc,
                [Parameters.AddNewUser.TwoFactorAuthEnabled] = user.TwoFactorEnabled
            };
            return ExecuteNonQuery(DbContext.UsersTableCommands.AddNewUser, parameterValues);
        }

        /// <summary>Deletes a user from the table.</summary>
        /// <param name="user">The user to delete.</param>
        /// <returns></returns>
        public int DeleteUser(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.AddNewUser.UserId] = user.Id
            };
            return ExecuteNonQuery(DbContext.UsersTableCommands.DeleteUser, parameterValues);
        }

        /// <summary>Returns all users defined in the table.</summary>
        /// <returns>A collection with all users that are defined in the table.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IEnumerable<TUser> GetAllUsers()
        {
            using (var dataTable = ExecuteReader(DbContext.UsersTableCommands.GetAllUsers))
                return ConvertDataTableToListOfUsers(dataTable, DbContext.ContextNomenclature.UsersTableNomenclature);
        }

        /// <summary>Gets the password hash for a specific user.</summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public string GetPasswordHashForUser(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetPasswordHashForUser.UserId] = userId
            };
            var passwordHash = ExecuteScalar<string>(DbContext.UsersTableCommands.GetPasswordHashForUser, parameterValues);

            // Treat empty strings as through there's no password.
            return String.IsNullOrWhiteSpace(passwordHash)
                ? null
                : passwordHash;
        }

        /// <summary>Gets the user's security stamp</summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetSecurityStampForUser(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetSecurityStampForUser.UserId] = userId
            };
            return ExecuteScalar<string>(DbContext.UsersTableCommands.GetSecurityStampForUser, parameterValues);
        }

        /// <summary>Gets a user given with the specified user id.</summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public TUser GetUserById(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetUserById.UserId] = userId
            };
            using (var dataTable = ExecuteReader(DbContext.UsersTableCommands.GetUserById, parameterValues))
                return ConvertDataTableToListOfUsers(dataTable, DbContext.ContextNomenclature.UsersTableNomenclature)
                    .FirstOrDefault();
        }

        /// <summary>Gets the unique ID assigned to a user with the given user name.</summary>
        /// <param name="userName">The user's name</param>
        /// <returns></returns>
        public string GetUserIdByUserName(string userName)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetUserIdByUserName.UserName] = userName
            };
            return ExecuteScalar<string>(DbContext.UsersTableCommands.GetUserIdByUserName, parameterValues);
        }

        /// <summary>Gets the user's name given a user id.</summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserNameByUserId(string userId)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetUserNameByUserId.UserId] = userId
            };
            return ExecuteScalar<string>(DbContext.UsersTableCommands.GetUserNameByUserId, parameterValues);
        }

        /// <summary>Gets all of the users with a specific email address.</summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public IEnumerable<TUser> GetUsersByEmail(string emailAddress)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetUsersByEmail.EmailAddress] = emailAddress
            };
            using (var dataTable = ExecuteReader(DbContext.UsersTableCommands.GetUsersByEmail, parameterValues))
                return ConvertDataTableToListOfUsers(dataTable, DbContext.ContextNomenclature.UsersTableNomenclature);
        }

        /// <summary>Gets a collection of users with a given user name.</summary>
        /// <param name="userName">User's name</param>
        /// <returns></returns>
        public IList<TUser> GetUsersByUserName(string userName)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.GetUsersByUserName.UserName] = userName
            };
            using (var reader = ExecuteReader(DbContext.UsersTableCommands.GetUsersByUserName, parameterValues))
                return ConvertDataTableToListOfUsers(reader, DbContext.ContextNomenclature.UsersTableNomenclature);
        }

        /// <summary>
        /// Sets the user's password hash
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public int SetPasswordHashForUser(string userId, string passwordHash)
        {
            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.SetPasswordHashForUser.UserId] = userId,
                [Parameters.SetPasswordHashForUser.PasswordHash] = passwordHash
            };
            return ExecuteNonQuery(DbContext.UsersTableCommands.SetPasswordHashForUser, parameterValues);
        }

        /// <summary>Updates a user in the Users table.</summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var parameterValues = new Dictionary<string, object>
            {
                [Parameters.UpdateUser.UserName] = user.UserName,
                [Parameters.UpdateUser.UserId] = user.Id,
                [Parameters.UpdateUser.PasswordHash] = user.PasswordHash,
                [Parameters.UpdateUser.SecurityStamp] = user.SecurityStamp,
                [Parameters.UpdateUser.Email] = user.Email,
                [Parameters.UpdateUser.EmailConfirmed] = user.EmailConfirmed,
                [Parameters.UpdateUser.PhoneNumber] = user.PhoneNumber,
                [Parameters.UpdateUser.PhoneNumberConfirmed] = user.PhoneNumberConfirmed,
                [Parameters.UpdateUser.AccessFailedCount] = user.AccessFailedCount,
                [Parameters.UpdateUser.LockoutEnabled] = user.LockoutEnabled,
                [Parameters.UpdateUser.LockoutEndDateUtc] = user.LockoutEndDateUtc,
                [Parameters.UpdateUser.TwoFactorAuthEnabled] = user.TwoFactorEnabled
            };
            return ExecuteNonQuery(DbContext.UsersTableCommands.UpdateUser, parameterValues);
        }

        /// <summary>
        ///     Maps the results of a <see cref="DataTable"/> to a new <see cref="IdentityUser"/>
        ///     using the mappings specified in the given <see cref="UsersTableNomenclature"/>.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="tableNomenclature"></param>
        /// <returns></returns>
        static List<TUser> ConvertDataTableToListOfUsers(DataTable dataTable, UsersTableNomenclature tableNomenclature)
        {
            Func<object, bool> toBoolean = (value) =>
            {
                return Convert.ToBoolean(value, System.Globalization.CultureInfo.InvariantCulture);
            };

            Func<object, int> toInt32 = (value) =>
            {
                return Convert.ToInt32(value, System.Globalization.CultureInfo.InvariantCulture);
            };

            var users = new List<TUser>();
            foreach (DataRow record in dataTable.Rows)
            {
                var user = new TUser
                {
                    Id = record.Field<string>(tableNomenclature.UserIdColumnName),
                    UserName = record.Field<string>(tableNomenclature.UserNameColumnName),
                    Email = record.Field<string>(tableNomenclature.EmailAddressColumnName),
                    EmailConfirmed = toBoolean(record.Field<object>(tableNomenclature.EmailConfirmedColumnName)),
                    PasswordHash = record.Field<string>(tableNomenclature.PasswordHashColumnName),
                    SecurityStamp = record.Field<string>(tableNomenclature.SecurityStampColumnName),
                    PhoneNumber = record.Field<string>(tableNomenclature.PhoneNumberColumnName),
                    PhoneNumberConfirmed = toBoolean(record.Field<object>(tableNomenclature.PhoneNumberConfirmedColumnName)),
                    TwoFactorEnabled = toBoolean(record.Field<object>(tableNomenclature.TwoFactorAuthorizationEnabledColumnName)),
                    LockoutEnabled = toBoolean(record.Field<object>(tableNomenclature.LockoutEnabledColumnName)),
                    LockoutEndDateUtc = record.Field<DateTime?>(tableNomenclature.LockoutEndDateUtcColumnName),
                    AccessFailedCount = toInt32(record.Field<object>(tableNomenclature.AccessFailedCountColumnName))
                };
                users.Add(user);
            }
            return users;
        }
    }
}