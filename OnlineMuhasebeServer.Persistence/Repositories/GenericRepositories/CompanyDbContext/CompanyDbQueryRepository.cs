using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Persistence.Repositories.GenericRepositories.CompanyDbContext
{
    public class CompanyDbQueryRepository<T> : ICompanyDbQueryRepository<T> where T : Entity
    {
        private static readonly Func<Context.CompanyDbContext, string, bool, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((Context.CompanyDbContext context, string id, bool isTracking) => 
                         context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        private static readonly Func<Context.CompanyDbContext, bool, Task<T>> GetFirstCompiled = EF.CompileAsyncQuery((Context.CompanyDbContext context, bool isTracking) =>
                context.Set<T>().AsNoTracking().FirstOrDefault());

        //private static readonly Func<Context.CompanyDbContext, Expression<Func<T, bool>>, bool, Task<T>> GetFirstByExpressionCompiled = EF.CompileAsyncQuery((Context.CompanyDbContext context, Expression<Func<T, bool>> expression, bool istracking) => istracking == true
        //   ? context.Set<T>().FirstOrDefault(expression)
        //   : context.Set<T>().AsNoTracking().FirstOrDefault(expression));

        private Context.CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (Context.CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var result = Entity.AsQueryable();

            if (!isTracking)
                result = result.AsNoTracking();

            return result;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            return await GetByIdCompiled(_context, id, isTracking);
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            return await GetFirstCompiled(_context, isTracking);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression,CancellationToken cancellationToken=default, bool isTracking = true)
        {
            T entity = null;

            if (!isTracking)
                entity = await Entity.AsNoTracking().Where(expression).FirstOrDefaultAsync();
            else
                entity = await Entity.Where(expression).FirstOrDefaultAsync();

            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            var result = Entity.Where(expression);

            if (!isTracking)
                result = result.AsNoTracking();

            return result;
        }

        public async Task<PaginationResult<T>> GetAllPagination(int pageNumber = 1, int pageSize = 5,Expression<Func<T, bool>> orderExpression = null,bool isOrderDesc=false)
        {
            if (orderExpression != null)
            {
                if(isOrderDesc)
                    return await Entity.OrderByDescending(orderExpression).ToPagedListAsync(pageNumber, pageSize);
                else
                    return await Entity.OrderBy(orderExpression).ToPagedListAsync(pageNumber, pageSize);
            }

            return await Entity.ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<PaginationResult<T>> GetWherePagination(Expression<Func<T, bool>> expression, int pageNumber = 1, int pageSize = 5,Expression<Func<T,bool>> orderExpression=null,bool isOrderDesc=false)
        {
            if (orderExpression != null)
            {
                if (isOrderDesc)
                    return await Entity.Where(expression).OrderByDescending(orderExpression).ToPagedListAsync(pageNumber, pageSize);
                else
                    return await Entity.Where(expression).OrderBy(orderExpression).ToPagedListAsync(pageNumber, pageSize);
            }

            return await Entity.Where(expression).ToPagedListAsync(pageNumber,pageSize);
        }
    }
}
