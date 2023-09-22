using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.Abstractions;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories
{
    public interface IQueryGenericRepository<T>
        where T:Entity
    {

        Task<PaginationResult<T>> GetAllPagination(int pageNumber = 1, int pageSize = 5, Expression<Func<T, bool>> orderExpression = null, bool isOrderDesc = false);

        Task<PaginationResult<T>> GetWherePagination(Expression<Func<T, bool>> expression, int pageNumber = 1, int pageSize = 5, Expression<Func<T, bool>> orderExpression = null, bool isOrderDesc = false);

        IQueryable<T> GetAll(bool isTracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);

        Task<T> GetById(string id, bool isTracking = true);

        Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression,CancellationToken cancellationToken, bool isTracking = true);

        Task<T> GetFirst(bool isTracking = true);
    }
}
