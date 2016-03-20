namespace AspNet.Identity.AdoNet.Oracle
{
    using System;
    using global::Oracle.ManagedDataAccess.Client;

    /// <summary>Implementation of <see cref="IUserClaimsTableCommands"/> for an Oracle database.</summary>
    sealed class UserClaimsTableSqlCommands : IUserClaimsTableCommands
    {
        /// <summary>Creates new instance of the <see cref="UserClaimsTableSqlCommands"/> class.</summary>
        /// <param name="tableNomenclature">
        ///     The <see cref="UserClaimsTableNomenclature"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>.
        /// </exception>
        public UserClaimsTableSqlCommands(UserClaimsTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            TableNomenclature = tableNomenclature;
        }
        
        /// <summary>Gets the currently configured <see cref="UserClaimsTableNomenclature"/>.</summary>
        public UserClaimsTableNomenclature TableNomenclature { get; private set; }

        public DatabaseCommand AddClaimForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"INSERT INTO \"{TableNomenclature.TableName}\" (" + Environment.NewLine +
                        $"  \"{TableNomenclature.ClaimTypeColumnName}\"," + Environment.NewLine +
                        $"  \"{TableNomenclature.ClaimValueColumnName}\"," + Environment.NewLine +
                        $"  \"{TableNomenclature.UserIdColumnName}\"" + Environment.NewLine +
                        $") VALUES (" + Environment.NewLine +
                        $"  :{UserClaimsTable.Parameters.AddClaimForUser.ClaimType}," + Environment.NewLine +
                        $"  :{UserClaimsTable.Parameters.AddClaimForUser.ClaimValue}," + Environment.NewLine +
                        $"  :{UserClaimsTable.Parameters.AddClaimForUser.UserId}" + Environment.NewLine +
                        ")",
                    Parameters = new[]
                    {
                        new OracleParameter(UserClaimsTable.Parameters.AddClaimForUser.ClaimType, OracleDbType.Clob),
                        new OracleParameter(UserClaimsTable.Parameters.AddClaimForUser.ClaimValue, OracleDbType.Clob),
                        new OracleParameter(UserClaimsTable.Parameters.AddClaimForUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand DeleteAllClaimsForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{TableNomenclature.TableName}\"" + Environment.NewLine +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UserClaimsTable.Parameters.DeleteAllClaimsForUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserClaimsTable.Parameters.DeleteAllClaimsForUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand GetAllClaimsForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.ClaimTypeColumnName}\"" + Environment.NewLine +
                        $"      ,\"{TableNomenclature.ClaimValueColumnName}\"" + Environment.NewLine +
                        $"  FROM \"{TableNomenclature.TableName}\"" + Environment.NewLine +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UserClaimsTable.Parameters.GetAllClaimsForUser.UserId}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserClaimsTable.Parameters.GetAllClaimsForUser.UserId, OracleDbType.Varchar2)
                    }
                };
            }
        }

        public DatabaseCommand RemoveClaimForUser
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{TableNomenclature.TableName}\"" + Environment.NewLine +
                        $" WHERE \"{TableNomenclature.UserIdColumnName}\" = :{UserClaimsTable.Parameters.RemoveClaimForUser.UserId}" + Environment.NewLine +
                        $"   AND \"{TableNomenclature.ClaimTypeColumnName}\" = :{UserClaimsTable.Parameters.RemoveClaimForUser.ClaimType}" + Environment.NewLine +
                        $"   AND \"{TableNomenclature.ClaimValueColumnName}\" = :{UserClaimsTable.Parameters.RemoveClaimForUser.ClaimValue}",
                    Parameters = new[]
                    {
                        new OracleParameter(UserClaimsTable.Parameters.RemoveClaimForUser.UserId, OracleDbType.Varchar2),
                        new OracleParameter(UserClaimsTable.Parameters.RemoveClaimForUser.ClaimType, OracleDbType.Clob),
                        new OracleParameter(UserClaimsTable.Parameters.RemoveClaimForUser.ClaimValue, OracleDbType.Clob)
                    }
                };
            }
        }

        /// <summary>Generates the DDL necessary to create the <see cref="UserClaimsTable"/>.</summary>
        /// <param name="tableNomenclature">The table nomenclature to use.</param>
        /// <returns>The SQL script that will create the <see cref="UserClaimsTable"/> in the database.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>
        /// </exception>
        public static string GenerateCreationSql(UserClaimsTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            var ddlScript = new System.Text.StringBuilder();
            ddlScript.AppendLine($"CREATE TABLE \"{tableNomenclature.TableName}\" (")
                     .AppendLine($"  \"{tableNomenclature.ClaimIdColumnName}\" NUMBER(10, 0) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.UserIdColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.ClaimTypeColumnName}\" CLOB,")
                     .AppendLine($"  \"{tableNomenclature.ClaimValueColumnName}\" CLOB,")
                     .AppendLine($"  CONSTRAINT \"PK_{tableNomenclature.TableName}\" PRIMARY KEY (\"{tableNomenclature.ClaimIdColumnName}\"),")
                     .AppendLine($"  CONSTRAINT \"FK_{tableNomenclature.TableName}_{tableNomenclature.UserIdColumnName}\"")
                     .AppendLine($"     FOREIGN KEY (\"{tableNomenclature.UserIdColumnName}\")")
                     .AppendLine($"  REFERENCES \"{tableNomenclature.TableName}\" (\"{tableNomenclature.UserIdColumnName}\") ON DELETE CASCADE")
                     .AppendLine(");");

            return ddlScript.ToString();
        }
    }
}