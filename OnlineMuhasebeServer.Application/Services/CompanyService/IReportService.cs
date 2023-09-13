using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyService
{
    public interface IReportService
    {
        Task Request(RequestReportCommand request,CancellationToken cancellationToken);

        Task<IList<Report>> GetAllReportsByCompanyId(string companyId);
    }
}
