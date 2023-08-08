using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Repositories.AppDbContext.MainRoleRepositories
{
    public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>,
        IMainRoleQueryRepository
    {
        public MainRoleQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
