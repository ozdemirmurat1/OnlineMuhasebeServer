using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public sealed class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
             CreateCompanyCommandResponse response=  await _mediator.Send(request,cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabases()
        {
            MigrateCompanyDatabasesCommand request = new();
            MigrateCompanyDatabasesCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCompany()
        {
            GetAllCompanyQuery request = new();
            GetAllCompanyQueryResponse response=await _mediator.Send(request);
            return Ok(response);
        }


        //[HttpGet]
        //public async Task<IActionResult> CheckCancellationToken(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        await Task.Delay(10000,cancellationToken);
        //        Console.WriteLine("Cancellation Token çalışmadı. İşlemi tamamladım!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Cancellation Token çalıştı ve işlemi iptal ettim!");
        //    }

        //    return NoContent();
        //}
    }
}
