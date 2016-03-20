namespace AspNet.Identity.AdoNet.Oracle
{
    using System;
    using global::Oracle.ManagedDataAccess.Client;

    /// <summary>Implementation of the <see cref="IRolesTableCommands"/> interface for Oracle.</summary>
    sealed class RolesTableSqlCommands : IRolesTableCommands
    {
        /// <summary>Creates new instance of the <see cref="RolesTableSqlCommands"/> class.</summary>
        /// <param name="tableNomenclature">
        ///     The <see cref="TableNomenclature"/> to use when interacting with the database.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>.
        /// </exception>
        public RolesTableSqlCommands(RolesTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            TableNomenclature = tableNomenclature;
        }
        
        /// <summary>Gets the currently configured <see cref="RolesTableNomenclature"/>.</summary>
        public RolesTableNomenclature TableNomenclature { get; private set; }

        public DatabaseCommand DeleteRoleById
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"DELETE FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.RoleIdColumnName}\" = :{RolesTable.Parameters.DeleteRoleById.RoleId}",
                    Parameters = new[]
                    {
                        new OracleParameter(RolesTable.Parameters.DeleteRoleById.RoleId, OracleDbType.Varchar2, 128)
                    }
                };
            }
        }

        public DatabaseCommand GetAllRoles
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.RoleIdColumnName}\"{Environment.NewLine}" +
                        $"      ,\"{TableNomenclature.RoleNameColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\""
                };
            }
        }

        public DatabaseCommand GetRoleIdByName
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.RoleIdColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.RoleNameColumnName}\" = :{RolesTable.Parameters.GetRoleIdByName.RoleName}",
                    Parameters = new[]
                    {
                        new OracleParameter(RolesTable.Parameters.GetRoleIdByName.RoleName, OracleDbType.Varchar2, 256)
                    }
                };
            }
        }

        public DatabaseCommand GetRoleNameById
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"SELECT \"{TableNomenclature.RoleNameColumnName}\"{Environment.NewLine}" +
                        $"  FROM \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.RoleIdColumnName}\" = :{RolesTable.Parameters.GetRoleNameById.RoleId}",
                    Parameters = new[]
                    {
                        new OracleParameter(RolesTable.Parameters.GetRoleNameById.RoleId, OracleDbType.Varchar2, 128)
                    }
                };
            }
        }

        public DatabaseCommand InsertRole
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"INSERT INTO \"{TableNomenclature.TableName}\" ({Environment.NewLine}" +
                        $"  \"{TableNomenclature.RoleIdColumnName}\",{Environment.NewLine}" +
                        $"  \"{TableNomenclature.RoleNameColumnName}\"{Environment.NewLine}" +
                        $") VALUES ({Environment.NewLine}" +
                        $"  :{RolesTable.Parameters.InsertRole.RoleId},{Environment.NewLine}" +
                        $"  :{RolesTable.Parameters.InsertRole.RoleName}{Environment.NewLine}" +
                        ")",
                    Parameters = new[]
                    {
                        new OracleParameter(RolesTable.Parameters.InsertRole.RoleId, OracleDbType.Varchar2, 128),
                        new OracleParameter(RolesTable.Parameters.InsertRole.RoleName, OracleDbType.Varchar2, 256)
                    }
                };
            }
        }

        public DatabaseCommand UpdateRole
        {
            get
            {
                return new DatabaseCommand
                {
                    CommandText =
                        $"UPDATE \"{TableNomenclature.TableName}\"{Environment.NewLine}" +
                        $"   SET \"{TableNomenclature.RoleNameColumnName}\" = :{RolesTable.Parameters.UpdateRole.RoleName}{Environment.NewLine}" +
                        $" WHERE \"{TableNomenclature.RoleIdColumnName}\" = :{RolesTable.Parameters.UpdateRole.RoleId}",
                    Parameters = new[]
                    {
                        new OracleParameter(RolesTable.Parameters.UpdateRole.RoleName, OracleDbType.Varchar2, 256),
                        new OracleParameter(RolesTable.Parameters.UpdateRole.RoleId, OracleDbType.Varchar2, 128)
                    }
                };
            }
        }

        /// <summary>Generates the DDL necessary to create the <see cref="RolesTable"/>.</summary>
        /// <param name="tableNomenclature">The table nomenclature to use.</param>
        /// <returns>The SQL script that will create the <see cref="RolesTable"/> in the database.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the <paramref name="tableNomenclature"/> parameter is <c>null</c>
        /// </exception>
        public static string GenerateCreationSql(RolesTableNomenclature tableNomenclature)
        {
            if (tableNomenclature == null)
                throw new ArgumentNullException(nameof(tableNomenclature));

            var ddlScript = new System.Text.StringBuilder();
            ddlScript.AppendLine($"CREATE TABLE \"{tableNomenclature.TableName}\"")
                     .AppendLine($"  \"{tableNomenclature.RoleIdColumnName}\" VARCHAR2(128 BYTE) NOT NULL,")
                     .AppendLine($"  \"{tableNomenclature.RoleNameColumnName}\" VARCHAR2(256 BYTE) NOT NULL,")
                     .AppendLine($"  CONSTRAINT \"PK_{tableNomenclature.TableName}\" PRIMARY KEY (\"{tableNomenclature.RoleIdColumnName}\")")
                     .AppendLine($");'");

            return ddlScript.ToString();
        }
    }
}