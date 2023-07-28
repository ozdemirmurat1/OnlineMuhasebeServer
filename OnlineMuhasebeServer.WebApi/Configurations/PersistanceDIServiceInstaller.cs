﻿using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Persistence.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistence.Services.AppServices;
using OnlineMuhasebeServer.Persistence.Services.CompanyServices;
using OnlineMuhasebeServer.Persistence;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();

            #endregion

            #region Services

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();

            services.AddScoped<IRoleService, RoleService>();

            #endregion

            #region Repositories

            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();

            #endregion

        }
    }
}
