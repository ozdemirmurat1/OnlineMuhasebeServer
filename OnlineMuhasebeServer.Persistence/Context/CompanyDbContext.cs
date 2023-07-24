using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Context
{
    public sealed class CompanyDbContext:DbContext
    {
        private string ConnectionString = "";
        

        public CompanyDbContext(Company company=null)
        {
            if (company != null)
            {
                if (company.UserId == "")
                    ConnectionString = $"Server={company.ServerName};Database={company.DatabaseName}; Trusted_Connection=True;";
                else
                    ConnectionString = $"Server={company.ServerName};Database={company.DatabaseName};User Id={company.UserId} ;Password={company.Password};";
            }

           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        // aşağıdaki metot ile dbSet'leri tek tek eklemene gerek kalmaz.
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext();
            }
        }

    }
}
