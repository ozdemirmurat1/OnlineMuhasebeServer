using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public class UserAndCompanyRelationshipService : IUserAndCompanyRelationshipService
    {
        private readonly IUserAndCompanyRelationshipCommandRepository _commandRepository;
        private readonly IUserAndCompanyRelationshipQueryRepository _queryRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public UserAndCompanyRelationshipService(IUserAndCompanyRelationshipCommandRepository commandRepository, IUserAndCompanyRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship)
        {
            throw new NotImplementedException();
        }

        public Task<UserAndCompanyRelationship> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserAndCompanyRelationship> GetByUserIdAndCompanyId(string userId, string companyId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
