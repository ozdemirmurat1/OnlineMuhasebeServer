using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
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
