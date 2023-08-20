using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public class MainRoleAndRoleRelationshipService : IMainRoleAndRoleRelationshipService
    {
        private readonly IMainRoleAndRoleRelationshipCommandRepository _commandRepository;
        private readonly IMainRoleAndRoleRelationshipQueryRepository _queryRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public MainRoleAndRoleRelationshipService(IMainRoleAndRoleRelationshipCommandRepository commandRepository, IMainRoleAndRoleRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship,CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(mainRoleAndRoleRelationship,cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<MainRoleAndRoleRelationship> GetAll()
        {
            return _queryRepository.GetAll();
        }

        public Task<MainRoleAndRoleRelationship> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship)
        {
            throw new NotImplementedException();
        }
    }
}
