﻿using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Services.AppService
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);

        Task MigrateCompanyDatabases();

        Task<Company?> GetCompanyByName(string name);
    }
}
