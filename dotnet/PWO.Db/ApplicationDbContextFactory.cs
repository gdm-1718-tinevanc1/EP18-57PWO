using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using PWO.Models;
using PWO.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Data.SqlClient;

namespace PWO.Db
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // var connectionString = "Server=tcp:ahs-pwo.database.windows.net,1433;Initial Catalog=pwoapp;Persist Security Info=False;User ID=ahspwo;Password=Artevelde_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // var providerName = "System.Data.SqlClient";
            // var db = Database.OpenConnectionString(connectionString, providerName);
            // builder.UseNpgsql(connectionString, providerName);

            builder.UseSqlServer("Server=tcp:ahs-pwo.database.windows.net,1433;Initial Catalog=pwoapp;Persist Security Info=False;User ID=ahspwo;Password=Artevelde_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
// ;providerName=System.Data.SqlClient

            /* builder.DataSource = "ahs-pwo.database.windows.net"; 
            builder.UserID = "ahspwo";            
            builder.Password = "Artevelde_";     
            builder.InitialCatalog = "pwoapp"; */

            
            // var connectionString = "Server=tcp:ahs-pwo.database.windows.net,1433;Initial Catalog=pwoapp;Persist Security Info=False;User ID=ahspwo;Password=Artevelde_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // var providerName = "System.Data.SqlClient";

            //var db = Database.OpenConnectionString(connectionString, providerName); 
            // builder.UseNpgsql(connectionString, providerName);

            builder.EnableSensitiveDataLogging();
            return new ApplicationDbContext(builder.Options);
        }
    }
}
/*

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodingBlastDbContext>
{
    public CodingBlastDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<CodingBlastDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);
        return new CodingBlastDbContext(builder.Options);
    }
}
*/