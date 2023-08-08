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
    public sealed class MainRoleCommandRepository : AppCommandRepository<MainRole>,
        IMainRoleCommandRepository
    {
        public MainRoleCommandRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
