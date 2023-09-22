﻿using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF
{
    public sealed class RemoveByIdUCAFCommandHandler : ICommandHandler<RemoveByIdUCAFCommand, RemoveByIdUCAFCommandResponse>
    {
        private readonly IUCAFService _service;
        private readonly ILogService _logService;

        public RemoveByIdUCAFCommandHandler(IUCAFService service, ILogService logService)
        {
            _service = service;
            _logService = logService;
        }

        public async Task<RemoveByIdUCAFCommandResponse> Handle(RemoveByIdUCAFCommand request, CancellationToken cancellationToken)
        {
            var checkRemoveUcafById = await _service.CheckRemoveByIdUcafIsGroupAndAvailable(request.Id, request.CompanyId);

            if (!checkRemoveUcafById) throw new Exception("Hesap planına bağlı alt hesaplar olduğundan silinemiyor!");

            UniformChartOfAccount ucaf= await _service.RemoveByIdUcafAsync(request.Id, request.CompanyId);

            Log log = new()
            {
                Id=Guid.NewGuid().ToString(),
                TableName=nameof(UniformChartOfAccount),
                Progress="Delete",
                Data=JsonConvert.SerializeObject(ucaf),
                UserId=""
            };

            await _logService.AddAsync(log,request.CompanyId);

            return new();
        }
    }
}
