using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyService
{
    public interface ILogService
    {
        Task AddAsync(Log log, string companyId);
    }
}
