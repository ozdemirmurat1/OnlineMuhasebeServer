using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
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
        private readonly IRabbitMQService _rabbitMqService;

        public ReportService(IContextService contextService, IReportCommandRepository commandRepository, IReportQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IRabbitMQService rabbitMqService)
        {
            _contextService = contextService;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _rabbitMqService = rabbitMqService;
        }

        public async Task<PaginationResult<Report>> GetAllReportsByCompanyId(string companyId, int pageNumber = 1, int pageSize = 5)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            var result= await _queryRepository.GetAllPagination(pageNumber,pageSize);
            result.Datas.OrderByDescending(p => p.CreatedDate);
            return result;
        }

        public async Task Request(RequestReportCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            Report report = new()
            {
               Id=Guid.NewGuid().ToString(),
               Name=request.Name,
               Status=false
            };

            await _commandRepository.AddAsync(report, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            ReportDto reportDto = new()
            {
                Id=report.Id,
                Name=request.Name,
                CompanyId=request.CompanyId,
            };

            _rabbitMqService.SendQueue(reportDto);
        }

        public void SendQueue(Report report,string companyId)
        {
            ReportDto reportDto = new()
            {
                Id = report.Id,
                Name = report.Name,
                CompanyId = companyId
            };

            _rabbitMqService.SendQueue(reportDto);
        }
    }
}
