using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateStaticRoles
{
    public sealed record CreateStaticRolesCommandResponse(
        string Message="Roller başarıyla oluşturuldu");

}
