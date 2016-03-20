namespace AspNet.Identity.AdoNet.Oracle
{
    using System;
    using global::Oracle.ManagedDataAccess.Client;

    /// <summary>Implementation of <see cref="IUserRolesTableCommands"/> for an Oracle database.</summary>
    sealed class UserRolesTableSqlCommands : IUserRolesTableCommands
    {
        /// <summary>Creates new instance of the <see cref="UserRolesTableSqlCommands"/> class.</summary>
        /// <param name="userRolesTableNomenclature">
        ///     The <see cref="AdoNet.UserRolesTableNomenclature"/> to use when interacting with the database.
        /// </param>
        /// <param name="rolesTableNomenclature">
        ///     The <see cref="AdoNet.RolesTableNomenclature"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="userRolesTableNomenclature"/> or
        ///     <paramref name="rolesTableNomenclature"/> parameter is <c>null</c>.
        /// </exception>
        public UserRolesTableSqlCommands(UserRolesTableNomenclature userRolesTableNomenclature, RolesTableNomenclature rolesTableNomenclature)
        {
            if (userRolesTableNomenclature == null)
                throw new ArgumentNullException(nameof(userRolesTableNomenclature));

            if (rolesTableNomenclature == null)
                throw new ArgumentNullException(nameof(rolesTableNomenclature));

            UserRolesTableNomenclature = userRolesTableNomenclature;
            RolesTableNomenclature = rolesTableNomenclature;
        }
        
        /// <summary>Gets the currently configured <see cref="AdoNet.UserRolesTableNomenclature"/>.</summary>
        public UserRolesTableNomenclature UserRolesTableNomenclature { get; private set; }

        /// <summary>Gets the currently configured <see cref="AdoNet.RolesTableNomenclature"/>.</summary>
        public RolesTableNomenclature RolesTableNomenclature { get; private set; }

        public DatabaseCommand DeleteByUserId
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{UserRolesTableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{UserRolesTableNomenclature.UserIdColumnName}\" = :{UserRolesTable.Parameters.DeleteByUserId.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserRolesTable.Parameters.DeleteByUserId.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetRolesForUserId
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{RolesTableNomenclature.RoleNameColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{UserRolesTableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" INNER JOIN \"{RolesTableNomenclature.TableName}\"{Environment.NewLine}" +
                        $"         ON \"{UserRolesTableNomenclature.TableName}\".\"{UserRolesTableNomenclature.RoleIdColumnName}\"{Environment.NewLine}" +
                        $"          = \"{RolesTableNomenclature.TableName}\".\"{RolesTableNomenclature.RoleIdColumnName}\"{Environment.NewLine}" +
                        $" WHERE \"{UserRolesTableNomenclature.UserIdColumnName}\" = :{UserRolesTable.Parameters.GetRolesForUserId.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserRolesTable.Parameters.GetRolesForUserId.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand AddUserToRole
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"INSERT INTO \"{UserRolesTableNomenclature.TableName}\" ({Environment.NewLine}" +
                        $" \"{UserRolesTableNomenclature.UserIdColumnName}\",{Environment.NewLine}" +
                        $" \"{UserRolesTableNomenclature.RoleIdColumnName}\"{Environment.NewLine}" +
                        $") VALUES ({Environment.NewLine}" +
                        $" :{UserRolesTable.Parameters.AddUserToRole.UserId},{Environment.NewLine}" +
                        $" :{UserRolesTable.Parameters.AddUserToRole.RoleId}{Environment.NewLine}" +
                        ")",
                    Parameters = new[]
                    {
                        new OracleParameter(UserRolesTable.Parameters.AddUserToRole.UserId, OracleDbType.Varchar2),
                        new OracleParameter(UserRolesTable.Parameters.AddUserToRole.RoleId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand RemoveUserFromFromRole
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{UserRolesTableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{UserRolesTableNomenclature.UserIdColumnName}\" = :{UserRolesTable.Parameters.RemoveUserFromFromRole.UserId}{Environment.NewLine}" +
                        $"   AND \"{UserRolesTableNomenclature.RoleIdColumnName}\" = :{UserRolesTable.Parameters.RemoveUserFromFromRole.RoleId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserRolesTable.Parameters.RemoveUserFromFromRole.UserId, OracleDbType.Varchar2),
                        new OracleParameter(UserRolesTable.Parameters.RemoveUserFromFromRole.RoleId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        /// <summary>Generates the DDL necessary to create the <see cref="UserRolesTable"/>.</summary>
        /// <param name="userRolesNomenclature">The instance of <see cref="AdoNet.UserRolesTableNomenclature"/> to use.</param>
        /// <param name="rolesNomenclature">The instance of <see cref="AdoNet.RolesTableNomenclature"/> to use.</param>
        /// <param name="usersNomenclature">The instance of <see cref="UsersTableNomenclature"/> to use.</param>
        /// <returns>The SQL script that will create the <see cref="UserRolesTable"/> in the database.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="userRolesNomenclature"/>,
        ///     <paramref name="rolesNomenclature"/>, or
        ///     <paramref name="usersNomenclature"/> parameter is <c>null</c>
        /// </exception>
        public static string GenerateCreationSql(UserRolesTableNomenclature userRolesNomenclature, RolesTableNomenclature rolesNomenclature, UsersTableNomenclature usersNomenclature)
        {
            if (userRolesNomenclature == null)
                throw new ArgumentNullException(nameof(userRolesNomenclature));

            if (rolesNomenclature == null)
                throw new ArgumentNullException(nameof(rolesNomenclature));

            if (usersNomenclature == null)
                throw new ArgumentNullException(nameof(usersNomenclature));
            
            var ddlScript = new System.Text.StringBuilder();
            ddlScript.AppendLine($"CREATE TABLE \"{userRolesNomenclature.TableName}\" (")
                     .AppendLine($"  \"{userRolesNomenclature.RoleIdColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  \"{userRolesNomenclature.UserIdColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  CONSTRAINT \"PK_{userRolesNomenclature.TableName}\"")
                     .AppendLine($"    PRIMARY KEY (\"{userRolesNomenclature.UserIdColumnName}\", \"{userRolesNomenclature.RoleIdColumnName}\") USING INDEX (")
                     .AppendLine($"      CREATE UNIQUE INDEX \"PK_{userRolesNomenclature.TableName}_ID\" ON \"{userRolesNomenclature.TableName}\" (")
                     .AppendLine($"             \"{userRolesNomenclature.UserIdColumnName}\",")
                     .AppendLine($"             \"{userRolesNomenclature.RoleIdColumnName}\"")
                     .AppendLine($"      )")
                     .AppendLine($"  ),")
                     .AppendLine($"  CONSTRAINT \"FK_{userRolesNomenclature.TableName}_{userRolesNomenclature.RoleIdColumnName}\"")
                     .AppendLine($"    FOREIGN KEY (\"{userRolesNomenclature.RoleIdColumnName}\")")
                     .AppendLine($"    REFERENCES \"{rolesNomenclature.TableName}\" (\"{rolesNomenclature.RoleIdColumnName}\") ON DELETE CASCADE,")
                     .AppendLine($"  CONSTRAINT \"FK_{userRolesNomenclature.TableName}_{userRolesNomenclature.UserIdColumnName}\"")
                     .AppendLine($"    FOREIGN KEY (\"{userRolesNomenclature.UserIdColumnName}\")")
                     .AppendLine($"    REFERENCES \"{usersNomenclature.TableName}\" (\"{usersNomenclature.UserIdColumnName}\") ON DELETE CASCADE")
                     .AppendLine($")");

            return ddlScript.ToString();
        }
    }
}