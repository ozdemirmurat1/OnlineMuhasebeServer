using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL
{
    public sealed record CreateUserAndCompanyRLCommandResponse(
        string Message="Kullanıcı şirkete başarıyla kayıt edildi!");

}
