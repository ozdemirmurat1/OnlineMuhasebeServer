using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.LogRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.LogRepositories
{
    public class LogQueryRepository:CompanyDbQueryRepository<Log>,ILogQueryRepository
    {
    }
}
