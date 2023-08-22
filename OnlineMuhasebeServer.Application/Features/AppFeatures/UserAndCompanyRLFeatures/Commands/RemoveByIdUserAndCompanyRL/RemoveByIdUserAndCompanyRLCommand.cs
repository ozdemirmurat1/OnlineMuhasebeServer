using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL
{
    public sealed record RemoveByIdUserAndCompanyRLCommand(
        string Id):ICommand<RemoveByIdUserAndCompanyRLCommandResponse>;
}
