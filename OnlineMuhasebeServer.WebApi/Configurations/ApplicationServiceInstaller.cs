using MediatR;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {

            //builder.Services.AddMediatR(typeof(OnlineMuhasebeServer.Application.AssemblyReference).Assembly);

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(OnlineMuhasebeServer.Application.AssemblyReference).Assembly); });
        }
    }
}
