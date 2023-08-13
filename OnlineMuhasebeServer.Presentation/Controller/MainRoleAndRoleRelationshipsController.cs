using MediatR;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

public class MainRoleAndRoleRelationshipsController : ApiController
{
    public MainRoleAndRoleRelationshipsController(IMediator mediator) : base(mediator) {}
}
