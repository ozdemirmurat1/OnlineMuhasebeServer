using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.UserAndCompanyRLRepositories
{
    public sealed class UserAndCompanyRelationshipCommandRepository : AppCommandRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipCommandRepository
    {
        public UserAndCompanyRelationshipCommandRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
