using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using OnlineMuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public class UserAndCompanyRelationshipsController : ApiController
    {
        public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator) { }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserAndCompanyRLCommand request,CancellationToken cancellationToken)
        {
            CreateUserAndCompanyRLCommandResponse response = await _mediator.Send(request,cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveById(RemoveByIdUserAndCompanyRLCommand request)
        {
            RemoveByIdUserAndCompanyRLCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }
        
    }
}
