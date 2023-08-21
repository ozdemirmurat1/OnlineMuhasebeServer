using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL
{
    public sealed record CreateMainRoleAndRoleRLCommand(
        string RoleId,
        string MainRoleId
        ):ICommand<CreateMainRoleAndRoleRLCommandResponse>;

}
