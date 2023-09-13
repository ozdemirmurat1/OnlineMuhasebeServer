using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.ReportRepositories
{
    public sealed class ReportQueryRepository:CompanyDbQueryRepository<Report>,IReportQueryRepository
    {
    }
}
