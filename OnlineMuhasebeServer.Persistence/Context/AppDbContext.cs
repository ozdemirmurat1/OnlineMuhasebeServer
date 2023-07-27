using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var entry in entries)
            {
                if (entry.State==EntityState.Added)
                {
                    
                    entry.Property(p=>p.CreatedDate)
                        .CurrentValue=DateTime.Now;
                }

                if (entry.State==EntityState.Modified)
                {
                    entry.Property(p=>p.UpdatedDate)
                        .CurrentValue=DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);    
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MuhasebeMasterDb; Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connectionString);

                return new AppDbContext(optionsBuilder.Options);
            }
        }

    }
}
