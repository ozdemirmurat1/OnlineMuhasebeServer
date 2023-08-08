using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole
{
    public sealed class CreateMainRoleHandler : ICommandHandler<CreateMainRoleCommand, CreateMainRoleResponse>
    {
        private readonly IMainRoleService _mainRoleService;

        public CreateMainRoleHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<CreateMainRoleResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
        {
            MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title, request.CompanyId,cancellationToken);

            if (checkMainRoleTitle != null) throw new Exception("Bu rol daha önce kaydedilmiş!");

            MainRole mainRole = new(
                id: Guid.NewGuid().ToString(),
                title: request.Title,
                ısRoleCreatedByAdmin: request.IsRoleCreatedByAdmin,
                companyId: request.CompanyId);

            await _mainRoleService.CreateAsync(mainRole, cancellationToken);

            return new();
        }
    }
}
