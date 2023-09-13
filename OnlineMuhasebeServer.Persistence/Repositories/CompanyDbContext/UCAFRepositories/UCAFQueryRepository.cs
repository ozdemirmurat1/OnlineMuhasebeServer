using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.UCAFRepositories
{
    public sealed class UCAFQueryRepository : CompanyDbQueryRepository<UniformChartOfAccount>, IUCAFQueryRepository
    {

    }
}
