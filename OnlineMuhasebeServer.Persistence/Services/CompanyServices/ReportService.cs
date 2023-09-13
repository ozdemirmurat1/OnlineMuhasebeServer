using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistence.Context;

namespace OnlineMuhasebeServer.Persistence.Services.CompanyServices
{
    public class ReportService : IReportService
    {
        private CompanyDbContext _context;
        private readonly IContextService _contextService;
        private readonly IReportCommandRepository _commandRepository;
        private readonly IReportQueryRepository _queryRepository;
        private readonly ICompanyDbUnitOfWork _unitOfWork;

        public ReportService(IContextService contextService, IReportCommandRepository commandRepository, IReportQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork)
        {
            _contextService = contextService;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Report>> GetAllReportsByCompanyId(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll(false).OrderByDescending(p => p.CreatedDate).ToListAsync();
        }

        public async Task Request(Report report, string companyId, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            await _commandRepository.AddAsync(report, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
