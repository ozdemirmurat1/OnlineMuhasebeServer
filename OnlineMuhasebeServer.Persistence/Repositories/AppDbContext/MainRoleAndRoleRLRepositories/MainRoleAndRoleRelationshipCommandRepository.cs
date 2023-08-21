using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.AppDbContext;

namespace OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleAndRoleRLRepositories
{
    public sealed class MainRoleAndRoleRelationshipCommandRepository : AppCommandRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelationshipCommandRepository
    {
        public MainRoleAndRoleRelationshipCommandRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
