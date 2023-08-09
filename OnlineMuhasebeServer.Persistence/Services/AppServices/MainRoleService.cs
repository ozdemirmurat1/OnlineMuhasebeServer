using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public sealed class MainRoleService : IMainRoleService
    {
        private readonly IMainRoleCommandRepository _mainRoleCommandRepository;
        private readonly IMainRoleQueryRepository _mainRoleQueryRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public MainRoleService(IMainRoleCommandRepository mainRoleCommandRepository, IMainRoleQueryRepository mainRoleQueryRepository, IAppUnitOfWork unitOfWork)
        {
            _mainRoleCommandRepository = mainRoleCommandRepository;
            _mainRoleQueryRepository = mainRoleQueryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(MainRole role,CancellationToken cancellationToken)
        {
            await _mainRoleCommandRepository.AddAsync(role,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateRangeAsync(List<MainRole> newMainRoles,CancellationToken cancellationToken)
        {
            await _mainRoleCommandRepository.AddRangeAsync(newMainRoles,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<MainRole> GetAll()
        {
            return _mainRoleQueryRepository.GetAll();
        }

        public async Task<MainRole> GetByTitleAndCompanyId(string title, string companyId,CancellationToken cancellationToken)
        {
            //if(companyId==null) return await _mainRoleQueryRepository.GetFirstByExpression(p=>p.Title==title,cancellationToken,false);
            // Kaydı takip etmicem sadece sorgulama yapmak istiyorum bu yüzden isTracking=false

            return await _mainRoleQueryRepository.GetFirstByExpression(p=>p.Title==title && p.CompanyId==companyId,cancellationToken,false);
        }
    }
}
