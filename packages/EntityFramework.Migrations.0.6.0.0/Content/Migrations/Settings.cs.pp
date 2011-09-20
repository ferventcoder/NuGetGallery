using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Providers;
using System.Data.SqlClient;

namespace $rootnamespace$.Migrations
{
    public class Settings : DbMigrationContext< /* TODO: put your code first context type name here */ >
    {
        public Settings()
        {
            AutomaticMigrationsEnabled = false;
            SetCodeGenerator<CSharpMigrationCodeGenerator>();
            AddSqlGenerator<SqlConnection, SqlServerMigrationSqlGenerator>();

            // Uncomment the following line if you are using SQL Server Compact 
            // SQL Server Compact is available as the SqlServerCompact NuGet package
            // AddSqlGenerator<System.Data.SqlServerCe.SqlCeConnection, SqlCeMigrationSqlGenerator>();
        }
    }
}
