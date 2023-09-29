using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Queries.GetAllBookEntry
{
    public sealed class GetAllBookEntryQueryHandler : IQueryHandler<GetAllBookEntryQuery, PaginationResult<GetAllBookEntryQueryResponse>>
    {
        private readonly IBookEntryService _bookEntryService;

        public GetAllBookEntryQueryHandler(IBookEntryService bookEntryService)
        {
            _bookEntryService = bookEntryService;
        }

        public async Task<PaginationResult<GetAllBookEntryQueryResponse>> Handle(GetAllBookEntryQuery request, CancellationToken cancellationToken)
        {

            PaginationResult<BookEntry> result = await _bookEntryService.GetAllAsync(request.CompanyId, request.PageNumber, request.PageSize, request.Year);

            int count = _bookEntryService.GetCount(request.CompanyId);

            PaginationResult<GetAllBookEntryQueryResponse> newResult = new(
                pageNumber:request.PageNumber,
                pageSize:request.PageSize,
                totalCount:count,
                datas:result.Datas.Select(s=>new GetAllBookEntryQueryResponse(
                    Id:s.Id,
                    BookEntryNumber:s.BookEntryNumber,
                    Date:s.Date,
                    Description:s.Description,
                    Type:s.Type,
                    Credit:0,
                    Debit:0)).ToList());

            return newResult;
        }
    }
}
