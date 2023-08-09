using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Services.AppService
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);

        Task AddRangeAsync(IEnumerable<AppRole> roles);

        Task UpdateAsync(AppRole appRole);

        Task DeleteAsync(AppRole appRole);

        Task<IList<AppRole>> GetStaticRolesAsync();

        Task<AppRole> GetById(string id);

        Task<AppRole> GetByCode(string code);
    }
}
