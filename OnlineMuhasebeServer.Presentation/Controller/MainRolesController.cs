using MediatR;
using OnlineMuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public sealed class MainRolesController : ApiController
    {
        public MainRolesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
