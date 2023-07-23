using AutoMapper;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company=_mapper.Map<Company>(request);
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }
    }
}
