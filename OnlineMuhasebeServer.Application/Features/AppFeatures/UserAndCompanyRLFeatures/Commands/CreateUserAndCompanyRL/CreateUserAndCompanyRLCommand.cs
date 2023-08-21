using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL
{
    public sealed record CreateUserAndCompanyRLCommand(
        string AppUserId,
        string CompanyId
        ):ICommand<CreateUserAndCompanyRLCommandResponse>;
}
