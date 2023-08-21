using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
    public interface IUserAndCompanyRelationshipService
    {
        Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken);

        Task RemoveByIdAsync(string id);

        Task<UserAndCompanyRelationship> GetByIdAsync(string id);

        Task<UserAndCompanyRelationship> GetByUserIdAndCompanyId(string userId,string companyId, CancellationToken cancellationToken);
    }
}
