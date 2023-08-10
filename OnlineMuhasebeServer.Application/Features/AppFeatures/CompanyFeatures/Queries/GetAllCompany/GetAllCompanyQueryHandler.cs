using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany
{
    public sealed class GetAllCompanyQueryHandler : IQueryHandler<GetAllCompanyQuery, GetAllCompanyQueryResponse>
    {
        private readonly ICompanyService _companyService;

        public GetAllCompanyQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var result = _companyService.GetAll();
            return new GetAllCompanyQueryResponse(await result.ToListAsync());
        }
    }
}
