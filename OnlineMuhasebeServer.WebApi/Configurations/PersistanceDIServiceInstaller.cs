using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Persistence.Services.AppServicess;
using OnlineMuhasebeServer.Persistence.Services.CompanyServices;
using OnlineMuhasebeServer.Persistence;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.CompanyRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.CompanyRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Persistence.UnitOfWorks;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleRepositories;
using OnlineMuhasebeServer.Persistence.Services.AppServices;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleAndRoleRLRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.UserAndCompanyRLRepositories;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork

            services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            services.AddScoped<IContextService, ContextService>();

            #endregion

            #region Services
            #region CompanyDbContext
            services.AddScoped<IUCAFService, UCAFService>();
            #endregion

            #region AppDbContext
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleAndRoleRelationshipService, MainRoleAndRoleRelationshipService>();
            services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();
            #endregion

            
            

            #endregion

            #region Repositories
            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion

            #region AppDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            services.AddScoped<IMainRoleCommandRepository,MainRoleCommandRepository>();
            services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
            services.AddScoped<IMainRoleAndRoleRelationshipCommandRepository,MainRoleAndRoleRelationshipCommandRepository>();
            services.AddScoped<IMainRoleAndRoleRelationshipQueryRepository,MainRoleAndRoleRelationshipQueryRepository>();
            services.AddScoped<IUserAndCompanyRelationshipCommandRepository,UserAndCompanyRelationshipCommandRepository>();
            services.AddScoped<IUserAndCompanyRelationshipQueryRepository,UserAndCompanyRelationshipQueryRepository>();
            #endregion


            #endregion

        }
    }

}
