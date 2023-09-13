using MediatR;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public class ReportsController:ApiController
    {
        public ReportsController(IMediator mediator) : base(mediator) { }
    }
}
