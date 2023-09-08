﻿using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF
{
    public sealed class RemoveByIdUCAFCommandHandler : ICommandHandler<RemoveByIdUCAFCommand, RemoveByIdUCAFCommandResponse>
    {
        private readonly IUCAFService _service;

        public RemoveByIdUCAFCommandHandler(IUCAFService service)
        {
            _service = service;
        }

        public async Task<RemoveByIdUCAFCommandResponse> Handle(RemoveByIdUCAFCommand request, CancellationToken cancellationToken)
        {
            await _service.RemoveByIdUcafAsync(request.Id, request.CompanyId);

            return new();
        }
    }
}
