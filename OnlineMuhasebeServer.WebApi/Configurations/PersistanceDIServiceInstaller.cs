using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.CompanyRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.LogRepositories;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistence;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.CompanyRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleAndRoleRLRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleAndUserRLRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.UserAndCompanyRLRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.LogRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistence.Services.AppServices;
using OnlineMuhasebeServer.Persistence.Services.AppServicess;
using OnlineMuhasebeServer.Persistence.Services.CompanyServices;
using OnlineMuhasebeServer.Persistence.UnitOfWorks;

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
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ILogService, LogService>();
            #endregion

            #region AppDbContext
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleAndRoleRelationshipService, MainRoleAndRoleRelationshipService>();
            services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();
            services.AddScoped<IMainRoleAndUserRelationshipService,MainRoleAndUserRelationshipService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion

            
            

            #endregion

            #region Repositories
            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();

            services.AddScoped<IReportCommandRepository,ReportCommandRepository>();
            services.AddScoped<IReportQueryRepository, ReportQueryRepository>();

            services.AddScoped<ILogCommandRepository,LogCommandRepository>();
            services.AddScoped<ILogQueryRepository, LogQueryRepository>();
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
            services.AddScoped<IMainRoleAndUserRelationshipCommandRepository,MainRoleAndUserRelationshipCommandRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipQueryRepository,MainRoleAndUserRelationshipQueryRepository>();
            #endregion


            #endregion

        }
    }

}
