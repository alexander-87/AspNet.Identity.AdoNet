namespace AspNet.Identity.AdoNet.Oracle
{
    using System;
    using global::Oracle.ManagedDataAccess.Client;

    /// <summary>Implementation of the <see cref="IRolesTableCommands"/> interface for Oracle.</summary>
    sealed class UserLoginsTableSqlCommands : IUserLoginsTableCommands
    {
        /// <summary>Creates new instance of the <see cref="UserLoginsTableSqlCommands"/> class.</summary>
        /// <param name="tableNomenclature">
        ///     The <see cref="UserLoginsTableNomenclature"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>.
        /// </exception>
        public UserLoginsTableSqlCommands(UserLoginsTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            TableNomenclature = tableNomenclature;
        }
        
        /// <summary>Gets the currently configured <see cref="UserClaimsTableNomenclature"/>.</summary>
        public UserLoginsTableNomenclature TableNomenclature { get; private set; }

        public DatabaseCommand AddNewUserLogin
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"INSERT INTO \"{TableNomenclature.TableName}\"{Environment.NewLine}(" +
                        $"  \"{TableNomenclature.ProviderNameColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.ProviderKeyColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.UserIdColumnName}\"{Environment.NewLine}" +
                        $") VALUES ({Environment.NewLine}" +
                        $"  :{UserLoginsTable.Parameters.AddNewUserLogin.ProviderName},{Environment.NewLine}" +
                        $"  :{UserLoginsTable.Parameters.AddNewUserLogin.ProviderKey},{Environment.NewLine}" +
                        $"  :{UserLoginsTable.Parameters.AddNewUserLogin.UserId}{Environment.NewLine}" +
                        ")",
                    Parameters = new[]
                    {
                        new OracleParameter(UserLoginsTable.Parameters.AddNewUserLogin.ProviderName, OracleDbType.Varchar2),
                        new OracleParameter(UserLoginsTable.Parameters.AddNewUserLogin.ProviderKey, OracleDbType.Varchar2),
                        new OracleParameter(UserLoginsTable.Parameters.AddNewUserLogin.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand DeleteAllLoginsForUserById
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UserLoginsTable.Parameters.DeleteAllLoginsForUserById.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserLoginsTable.Parameters.DeleteAllLoginsForUserById.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand DeleteUserLogin
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UserLoginsTable.Parameters.DeleteUserLogin.UserId}{Environment.NewLine}" +
                        $"   AND \"{TableNomenclature.ProviderNameColumnName}\" = :{UserLoginsTable.Parameters.DeleteUserLogin.ProviderName}{Environment.NewLine}" +
                        $"   AND \"{TableNomenclature.ProviderKeyColumnName}\" = :{UserLoginsTable.Parameters.DeleteUserLogin.ProviderKey}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserLoginsTable.Parameters.DeleteUserLogin.UserId, OracleDbType.Varchar2),
                        new OracleParameter(UserLoginsTable.Parameters.DeleteUserLogin.ProviderName, OracleDbType.Varchar2),
                        new OracleParameter(UserLoginsTable.Parameters.DeleteUserLogin.ProviderKey, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetAllUserLoginsForUserId
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT *{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UserLoginsTable.Parameters.GetAllUserLoginsForUserId.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserLoginsTable.Parameters.GetAllUserLoginsForUserId.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetUserIdByLogin
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.UserIdColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.ProviderNameColumnName}\" = :{UserLoginsTable.Parameters.GetUserIdByLogin.ProviderName}{Environment.NewLine}" +
                        $"   AND \"{TableNomenclature.ProviderKeyColumnName}\" = :{UserLoginsTable.Parameters.GetUserIdByLogin.ProviderKey}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserLoginsTable.Parameters.GetUserIdByLogin.ProviderName, OracleDbType.Varchar2),
                        new OracleParameter(UserLoginsTable.Parameters.GetUserIdByLogin.ProviderKey, OracleDbType.Varchar2)
                    }
                };
            }
        }

        /// <summary>Generates the DDL necessary to create the <see cref="RolesTable"/>.</summary>
        /// <param name="userLoginsNomenclature">The instance of <see cref="UserLoginsTableNomenclature"/> to use.</param>
        /// <param name="usersNomenclature">The instance of <see cref="UsersTableNomenclature"/> to use.</param>
        /// <returns>The SQL script that will create the <see cref="RolesTable"/> in the database.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="userLoginsNomenclature"/> or
        ///     <paramref name="usersNomenclature"/> parameter is <c>null</c>
        /// </exception>
        public static string GenerateCreationSql(UserLoginsTableNomenclature userLoginsNomenclature, UsersTableNomenclature usersNomenclature)
        {
            if (userLoginsNomenclature == null)
                throw new ArgumentNullException(nameof(userLoginsNomenclature));

            if (usersNomenclature == null)
                throw new ArgumentNullException(nameof(usersNomenclature));

            var ddlScript = new System.Text.StringBuilder();
            ddlScript.AppendLine($"CREATE TABLE \"{userLoginsNomenclature.TableName}\" (")
                     .AppendLine($"  \"{userLoginsNomenclature.UserIdColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  \"{userLoginsNomenclature.ProviderNameColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  \"{userLoginsNomenclature.ProviderKeyColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  PRIMARY KEY (\"{userLoginsNomenclature.UserIdColumnName}\",")
                     .AppendLine($"               \"{userLoginsNomenclature.ProviderNameColumnName}\",")
                     .AppendLine($"               \"{userLoginsNomenclature.ProviderKeyColumnName}\") USING INDEX (")
                     .AppendLine($"    CREATE INDEX \"PK_{userLoginsNomenclature.TableName}\" ON \"{userLoginsNomenclature.TableName}\" (")
                     .AppendLine($"      \"{userLoginsNomenclature.UserIdColumnName}\",")
                     .AppendLine($"      \"{userLoginsNomenclature.ProviderNameColumnName}\",")
                     .AppendLine($"      \"{userLoginsNomenclature.ProviderKeyColumnName}\"")
                     .AppendLine($"    )")
                     .AppendLine($"  ),")
                     .AppendLine($"  CONSTRAINT \"FK_{userLoginsNomenclature.TableName}_{userLoginsNomenclature.UserIdColumnName}\"")
                     .AppendLine($"    FOREIGN KEY (\"{userLoginsNomenclature.UserIdColumnName}\")")
                     .AppendLine($"    REFERENCES \"{usersNomenclature.TableName}\" (\"{usersNomenclature.UserIdColumnName}\") ON DELETE CASCADE")
                     .AppendLine($");");

            return ddlScript.ToString();
        }
    }
}