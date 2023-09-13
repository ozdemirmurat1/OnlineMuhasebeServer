using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Persistence.Services.CompanyServices
{
    public class ReportService : IReportService
    {
        public Task<IList<Report>> GetAllReportsByCompanyId(string companyId)
        {
            throw new NotImplementedException();
        }

        public Task Request(Report report, string companyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
