# AspNet.Identity.AdoNet
Custom ASP.NET Identity Storage Providers using ADO.NET

[![Build status](https://ci.appveyor.com/api/projects/status/tfed5w56psed3dmp/branch/master?svg=true)](https://ci.appveyor.com/project/BitWiseGuy/aspnet-identity-adonet/branch/master)

## Implemented Database Providers

| Database      | Status  | Supported Versions | ADO.NET Driver | NuGet Package |
| ------------- |---------|--------------------|----------------|---------------|
| MySql         | Planned | (TBD)              |                |
| Oracle        | Beta    | *Only 11g tested*  | [Oracle.ManagedDataAccess] | [AspNet.Identity.AdoNet.Oracle]
| PostgreSQL    | Planned | (TBD)              |                |
| SQL Server    | Planned | (TBD)              |                |

If you would like a database provider implemented that isn't already completed, please [submit an issue], or even better, [submit a pull request] with your changes.

## How to use

> **Note:** Currently, only a provider for Oracle has been implemented so these instructions explain the changes necessary for using that package. Although, the steps should be identical for other providers with only the NuGet package and `using` namespaces differing.

1. Install the `Install-Package AspNet.Identity.AdoNet.Oracle` package from NuGet.

    > **Note:** Make sure to include the `PreRelease` option, as this package hasn't been tested for a full 1.0 release yet.

  You can also uninstall the `Microsoft.AspNet.Identity.EntityFramework` package. And if you're not using Entity Framework at all, you can remove that package as well.

2. In your `App_Start/IdentityConfig.cs` file, update the using statements like so:

    ```c#
    using AspNet.Identity.AdoNet; // <== Add this
    // using Microsoft.AspNet.Identity.EntityFramework; // <== Comment out/remove this
    ```
3. In your `Models/IdentityModels.cs` file, update the usings statements like so:
    
    ```c#
    using AspNet.Identity.AdoNet; // <== Add this
    using AspNet.Identity.AdoNet.Oracle; // <== Add this
    // using Microsoft.AspNet.Identity.EntityFramework; // <== Comment out/remove this
    ```
    
    Configure your `ApplicationDbContext` class to look like this:
    
    ```c#
    public class ApplicationDbContext : OracleIdentityDbContext
    {
        static readonly string connectionString =
                System.Configuration.ConfigurationManager
                      .ConnectionStrings["DefaultConnection"].ConnectionString;

        public ApplicationDbContext() : base(connectionString) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    ```

## Customizing Database Object Names (i.e. Custom Nomenclature)

Don't like the default names used for the database objects, or have an existing database you need to use? No problem!

You can can customize the names of the database objects by providing a custom nomenclature for each table when creating the database context. Here's an example of providing custom table and column names for each table with the Oracle provider:

```c#
public class ApplicationDbContext : OracleIdentityDbContext
{
    static readonly string connectionString =
            System.Configuration.ConfigurationManager
                  .ConnectionStrings["DefaultConnection"].ConnectionString;

    // The OracleContextNomenclature will use the default nomenclature
    // if we don't specify a custom nomenclature for any of the tables.
    static readonly OracleContextNomenclature nomenclature = new OracleContextNomenclature
    {
        RolesTableNomenclature =
            new RolesTableNomenclature(tableName: "APP_ROLES",
                                       roleIdColumnName: "ID",
                                       roleNameColumnName: "NAME"),
        UserClaimsTableNomenclature =
            new UserClaimsTableNomenclature(tableName: "APP_USERCLAIMS",
                                            claimIdColumnName: "ID",
                                            userIdColumnName: "USERID",
                                            claimTypeColumnName: "CLAIMTYPE",
                                            claimValueColumnName: "CLAIMVALUE"),
        UserLoginsTableNomenclature =
            new UserLoginsTableNomenclature(tableName: "APP_USERLOGINS",
                                            userIdColumnName: "USERID",
                                            providerNameColumnName: "LOGINPROVIDER",
                                            providerKeyColumnName: "PROVIDERKEY"),
        UserRolesTableNomenclature =
            new UserRolesTableNomenclature(tableName: "APP_USERROLES",
                                           userIdColumnName: "USERID",
                                           roleIdColumnName: "ROLEID"),
        UsersTableNomenclature =
            new UsersTableNomenclature(tableName: "APP_USERS",
                                       userIdColumnName: "ID",
                                       userNameColumnName: "USERNAME",
                                       emailAddressColumnName: "EMAIL",
                                       emailConfirmedColumnName: "EMAILCONFIRMED",
                                       passwordHashColumnName: "PASSWORDHASH",
                                       securityStampColumnName: "SECURITYSTAMP",
                                       phoneNumberColumnName: "PHONENUMBER",
                                       phoneNumberConfirmedColumnName: "PHONENUMBERCONFIRMED",
                                       twoFactorAuthorizationEnabledColumnName: "TWOFACTORENABLED",
                                       lockoutEndDateUtcColumnName: "LOCKOUTENDDATEUTC",
                                       lockoutEnabledColumnName: "LOCKOUTENABLED",
                                       accessFailedCountColumnName: "ACCESSFAILEDCOUNT")
    };

    public ApplicationDbContext() : base(connectionString, nomenclature) { }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
}
```


<!-- Links -->
[Oracle.ManagedDataAccess]: https://www.nuget.org/packages/Oracle.ManagedDataAccess/ "Official Oracle ODP.NET, Managed Driver"
[AspNet.Identity.AdoNet.Oracle]:  https://www.nuget.org/packages/AspNet.Identity.AdoNet.Oracle/ "AspNet.Identity.AdoNet.Oracle NuGet Package"
[submit an issue]: https://github.com/alexander-87/AspNet.Identity.AdoNet/issues "GitHub Issues for this Repository"
[submit a pull request]: https://github.com/alexander-87/AspNet.Identity.AdoNet/pulls "GitHub Pull Requests for this Repository"
