﻿using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole
{
    public sealed class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommand, UpdateMainRoleCommandResponse>
    {
        private readonly IMainRoleService _mainRoleService;

        public UpdateMainRoleCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<UpdateMainRoleCommandResponse> Handle(UpdateMainRoleCommand request, CancellationToken cancellationToken)
        {
            MainRole mainRole = await _mainRoleService.GetById(request.Id);

            if (mainRole == null) throw new Exception("Bu ana rol bulunamadı!");

            if (mainRole.Title == request.Title) throw new Exception("Güncellemeye çalıştığınız ana rol adı eski adı ile aynı!");

            if(mainRole.Title!=request.Title)
            {
                MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title, mainRole.CompanyId,cancellationToken);
                if (checkMainRoleTitle != null) throw new Exception("Bu rol adı daha önce kullanılmış!");
            }

            mainRole.Title= request.Title;
            await _mainRoleService.UpdateAsync(mainRole);
            return new();
        }
    }
}
