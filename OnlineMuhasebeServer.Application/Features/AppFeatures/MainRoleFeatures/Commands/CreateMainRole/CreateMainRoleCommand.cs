using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole
{
    public sealed record CreateMainRoleCommand(
        string Title,
        string CompanyId=null) : ICommand<CreateMainRoleCommandResponse>;
}
