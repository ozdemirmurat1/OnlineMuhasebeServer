using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.UCAFRepositories
{
    public sealed class UCAFCommandRepository : CompanyDbCommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}
