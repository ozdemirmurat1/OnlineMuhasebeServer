using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.BookEntryRepositories;
using OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistence.Repositories.CompanyDbContext.BookEntryRepositories
{
    public class BookEntryQueryRepository : CompanyDbQueryRepository<BookEntry>, IBookEntryQueryRepository
    {
    }
}
