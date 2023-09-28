﻿using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyService
{
    public interface IBookEntryService
    {
        Task<string> GetNewBookEntryNumber(string companyId);

        Task AddAsync(string companyId,BookEntry bookEntry,CancellationToken cancellationToken);

        Task<PaginationResult<BookEntry>> GetAllAsync(string companyId,int pageNumber,int pageSize,int year);

        int GetCount(string companyId);
    }
}
