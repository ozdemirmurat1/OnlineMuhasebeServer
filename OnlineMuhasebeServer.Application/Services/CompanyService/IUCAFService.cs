﻿using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Services.CompanyService
{
    public interface IUCAFService
    {
        Task CreateUcafAsync(CreateUCAFCommand request,CancellationToken cancellationToken);

        Task<UniformChartOfAccount> GetByCode(string code, CancellationToken cancellationToken);
    }
}
