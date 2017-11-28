using System;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using OpenIddict;
// using Npgsql.EntityFrameworkCore.PostgreSQL;
using PWO.Models;
using PWO.Models.Security;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PWO.Db
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<Todo> Todos { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
