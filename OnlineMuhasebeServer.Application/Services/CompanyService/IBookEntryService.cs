using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyService
{
    public interface IBookEntryService
    {
        Task<string> GetNewBookEntryNumber(string companyId);

        Task AddAsync(string companyId,BookEntry bookEntry,CancellationToken cancellationToken);
    }
}
