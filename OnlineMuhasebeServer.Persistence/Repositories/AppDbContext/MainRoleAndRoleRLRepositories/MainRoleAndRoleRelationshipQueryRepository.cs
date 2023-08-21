using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleAndRoleRLRepositories
{
    public sealed class MainRoleAndRoleRelationshipQueryRepository : AppQueryRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelationshipQueryRepository
    {
        public MainRoleAndRoleRelationshipQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
