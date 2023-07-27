using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistence.Context;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = (configuration.GetConnectionString(SectionName));

            services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(connectionString));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(OnlineMuhasebeServer.Persistence.AssemblyReference).Assembly);
        }
    }
}
