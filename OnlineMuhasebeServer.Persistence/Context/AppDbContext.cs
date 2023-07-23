using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    entry.Property(p=>p.Id)
                        .CurrentValue=Guid.NewGuid().ToString();
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

    }
}
