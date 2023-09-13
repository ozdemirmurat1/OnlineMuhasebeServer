using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Persistence.Context;

namespace OnlineMuhasebeServer.Persistence.Services.CompanyServices
{
    public class ReportService : IReportService
    {
        private CompanyDbContext _context;
        private readonly IContextService _contextService;
        private readonly IReportCommandRepository _commandRepository;
        private readonly IReportQueryRepository _queryRepository;

        public ReportService(IContextService contextService, IReportCommandRepository commandRepository, IReportQueryRepository queryRepository)
        {
            _contextService = contextService;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

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
