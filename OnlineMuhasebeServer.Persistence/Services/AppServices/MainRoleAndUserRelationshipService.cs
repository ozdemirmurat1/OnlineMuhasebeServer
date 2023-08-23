﻿using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public class MainRoleAndUserRelationshipService : IMainRoleAndUserRelationshipService
    {
        private readonly IMainRoleAndUserRelationshipCommandRepository _commandRepository;
        private readonly IMainRoleAndUserRelationshipQueryRepository _queryRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public MainRoleAndUserRelationshipService(IMainRoleAndUserRelationshipCommandRepository commandRepository, IMainRoleAndUserRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship,CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(mainRoleAndUserRelationship, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<MainRoleAndUserRelationship> GetByUserIdCompanyIdAndMainRoleIdAsync(string userId, string companyId, string mainRoleId,CancellationToken cancellationToken)
        {
            return await _queryRepository.GetFirstByExpression(p => p.UserId == userId && p.CompanyId == companyId && p.MainRoleId == mainRoleId, cancellationToken);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _commandRepository.RemoveById(id);
        }
    }
}
