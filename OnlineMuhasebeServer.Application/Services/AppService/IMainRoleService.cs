using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Services.AppService
{
    public interface IMainRoleService
    {
        Task<MainRole> GetByTitleAndCompanyId(string title,string companyId, CancellationToken cancellationToken);

        Task CreateAsync(MainRole role, CancellationToken cancellationToken);
    }
}
