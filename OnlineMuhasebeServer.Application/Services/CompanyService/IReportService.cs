using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyService
{
    public interface IReportService
    {
        Task Request(Report report,string companyId,CancellationToken cancellationToken);

        Task<IList<Report>> GetAllReportsByCompanyId(string companyId);
    }
}
