using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public class MainRoleAndUserRelationshipService : IMainRoleAndUserRelationshipService
    {
        public Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship)
        {
            throw new NotImplementedException();
        }

        public Task<MainRoleAndUserRelationship> GetByUserIdCompanyIdAndMainRoleIdAsync(string userId, string companyId, string mainRoleId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
