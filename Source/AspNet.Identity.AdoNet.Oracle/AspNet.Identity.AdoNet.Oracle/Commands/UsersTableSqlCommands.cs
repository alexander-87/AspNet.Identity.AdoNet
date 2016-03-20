namespace AspNet.Identity.AdoNet.Oracle
{
    using System;
    using global::Oracle.ManagedDataAccess.Client;

    /// <summary>Implementation of the <see cref="IUsersTableCommands"/> interface for Oracle.</summary>
    sealed class UsersTableSqlCommands : IUsersTableCommands
    {
        /// <summary>Creates new instance of the <see cref="RolesTableSqlCommands"/> class.</summary>
        /// <param name="tableNomenclature">
        ///     The <see cref="UsersTableNomenclature"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>.
        /// </exception>
        public UsersTableSqlCommands(UsersTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            TableNomenclature = tableNomenclature;
        }
        
        public UsersTableNomenclature TableNomenclature { get; private set; }

        public DatabaseCommand AddNewUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"INSERT INTO \"{TableNomenclature.TableName}\" ({Environment.NewLine}" +
                        $"  \"{TableNomenclature.UserIdColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.UserNameColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.EmailAddressColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.EmailConfirmedColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.PasswordHashColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.SecurityStampColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.PhoneNumberColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.PhoneNumberConfirmedColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.AccessFailedCountColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.LockoutEnabledColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.LockoutEndDateUtcColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.TwoFactorAuthorizationEnabledColumnName}\"{Environment.NewLine}" +
                        $") VALUES ({Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.UserId},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.UserName},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.Email},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.EmailConfirmed},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.PasswordHash},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.SecurityStamp},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.PhoneNumber},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.PhoneNumberConfirmed},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.AccessFailedCount},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.LockoutEnabled},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.LockoutEndDateUtc},{Environment.NewLine}" +
                        $"  :{UsersTable.Parameters.AddNewUser.TwoFactorAuthEnabled}{Environment.NewLine}" +
                        ")",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.AddNewUser.UserId, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.UserName, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.Email, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.EmailConfirmed, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.PasswordHash, OracleDbType.Clob),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.SecurityStamp, OracleDbType.Clob),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.PhoneNumber, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.PhoneNumberConfirmed, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.AccessFailedCount, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.LockoutEnabled, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.LockoutEndDateUtc, OracleDbType.Date),
                        new OracleParameter(UsersTable.Parameters.AddNewUser.TwoFactorAuthEnabled, OracleDbType.Decimal)
                    }
                };
            }
        }

        public DatabaseCommand DeleteUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.DeleteUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.DeleteUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetAllUsers
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText = $"SELECT * FROM \"{TableNomenclature.TableName}\""
                };
            }
        }

        public DatabaseCommand GetPasswordHashForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.PasswordHashColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.GetPasswordHashForUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetPasswordHashForUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetSecurityStampForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.SecurityStampColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.GetSecurityStampForUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetSecurityStampForUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetUserById
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT *{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.GetUserById.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetUserById.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetUserIdByUserName
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.UserIdColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserNameColumnName}\" = :{UsersTable.Parameters.GetUserIdByUserName.UserName}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetUserIdByUserName.UserName, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetUserNameByUserId
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.UserNameColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.GetUserNameByUserId.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetUserNameByUserId.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetUsersByEmail
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT *{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.EmailAddressColumnName}\" = :{UsersTable.Parameters.GetUsersByEmail.EmailAddress}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetUsersByEmail.EmailAddress, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetUsersByUserName
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT *{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserNameColumnName}\" = :{UsersTable.Parameters.GetUsersByUserName.UserName}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.GetUsersByUserName.UserName, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand SetPasswordHashForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"UPDATE \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $"   SET \"{TableNomenclature.PasswordHashColumnName}\" = :{UsersTable.Parameters.SetPasswordHashForUser.PasswordHash}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.SetPasswordHashForUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.SetPasswordHashForUser.PasswordHash, OracleDbType.Clob),
                        new OracleParameter(UsersTable.Parameters.SetPasswordHashForUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand UpdateUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"UPDATE \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $"   SET \"{TableNomenclature.UserNameColumnName}\" = :{UsersTable.Parameters.UpdateUser.UserName},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.EmailAddressColumnName}\" = :{UsersTable.Parameters.UpdateUser.Email},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.EmailConfirmedColumnName}\" = :{UsersTable.Parameters.UpdateUser.EmailConfirmed},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.PasswordHashColumnName}\" = :{UsersTable.Parameters.UpdateUser.PasswordHash},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.SecurityStampColumnName}\" = :{UsersTable.Parameters.UpdateUser.SecurityStamp},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.PhoneNumberColumnName}\" = :{UsersTable.Parameters.UpdateUser.PhoneNumber},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.PhoneNumberConfirmedColumnName}\" = :{UsersTable.Parameters.UpdateUser.PhoneNumberConfirmed},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.AccessFailedCountColumnName}\" = :{UsersTable.Parameters.UpdateUser.AccessFailedCount},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.LockoutEnabledColumnName}\" = :{UsersTable.Parameters.UpdateUser.LockoutEnabled},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.LockoutEndDateUtcColumnName}\" = :{UsersTable.Parameters.UpdateUser.LockoutEndDateUtc},{Environment.NewLine}" +
                        $"       \"{TableNomenclature.TwoFactorAuthorizationEnabledColumnName}\" = :{UsersTable.Parameters.UpdateUser.TwoFactorAuthEnabled}{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UsersTable.Parameters.UpdateUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UsersTable.Parameters.UpdateUser.UserName, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.Email, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.EmailConfirmed, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.PasswordHash, OracleDbType.Clob),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.SecurityStamp, OracleDbType.Clob),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.PhoneNumber, OracleDbType.Varchar2),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.PhoneNumberConfirmed, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.AccessFailedCount, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.LockoutEnabled, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.LockoutEndDateUtc, OracleDbType.Date),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.TwoFactorAuthEnabled, OracleDbType.Decimal),
                        new OracleParameter(UsersTable.Parameters.UpdateUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        /// <summary>Generates the DDL necessary to create the <see cref="UserRolesTable"/>.</summary>
        /// <param name="tableNomenclature">The table nomenclature to use.</param>
        /// <returns>The SQL script that will create the <see cref="UserRolesTable"/> in the database.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>
        /// </exception>
        public static string GenerateCreationSql(UsersTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            var ddlScript = new System.Text.StringBuilder();
            ddlScript.AppendLine($"CREATE TABLE \"{tableNomenclature.TableName}\" (")
                     .AppendLine($"  \"{tableNomenclature.UserIdColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.UserNameColumnName}\" VARCHAR2(256 BYTE) NOT NULL")
                     .AppendLine($"  \"{tableNomenclature.EmailAddressColumnName}\" VARCHAR2(256 BYTE) DEFAULT NULL,")
                     .AppendLine($"  \"{tableNomenclature.EmailConfirmedColumnName}\" NUMBER(3, 0) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.PasswordHashColumnName}\" CLOB,")
                     .AppendLine($"  \"{tableNomenclature.SecurityStampColumnName}\" CLOB,")
                     .AppendLine($"  \"{tableNomenclature.PhoneNumberColumnName}\" VARCHAR2(48 BYTE),")
                     .AppendLine($"  \"{tableNomenclature.PhoneNumberConfirmedColumnName}\" NUMBER(3, 0) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.TwoFactorAuthorizationEnabledColumnName}\" NUMBER(3, 0) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.LockoutEndDateUtcColumnName}\" DATE DEFAULT NULL,")
                     .AppendLine($"  \"{tableNomenclature.LockoutEnabledColumnName}\" NUMBER(3, 0) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.AccessFailedCountColumnName}\" NUMBER(10, 0) NOT NULL,")
                     .AppendLine($"  CONSTRAINT \"PK_{tableNomenclature.TableName}\" PRIMARY KEY (\"{tableNomenclature.UserIdColumnName}\")")
                     .AppendLine($");");

            return ddlScript.ToString();
        }
    }
} 