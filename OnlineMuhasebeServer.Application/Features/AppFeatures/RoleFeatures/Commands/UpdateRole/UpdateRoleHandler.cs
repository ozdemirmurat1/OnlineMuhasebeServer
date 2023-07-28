using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public UpdateRoleHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleManager.FindByIdAsync(request.Id);

            if (role == null) throw new Exception("Rol bulunamadı!");

            if (role.Code!=request.Code)
            {
                AppRole checkCode=await _roleManager.Roles.FirstOrDefaultAsync(p=>p.Code==request.Code);

                if (checkCode != null) throw new Exception("Bu kod daha önce kaydedilmiş!");
            }

            role.Code = request.Code;
            role.Name = request.Name;

            await _roleManager.UpdateAsync(role);
            return new();
        }

    }
}
