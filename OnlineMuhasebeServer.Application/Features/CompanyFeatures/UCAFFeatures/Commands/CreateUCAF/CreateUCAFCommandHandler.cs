using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;
        private readonly ILogService _logService;

        public CreateUCAFCommandHandler(IUCAFService ucafService, ILogService logService)
        {
            _ucafService = ucafService;
            _logService = logService;
        }

        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup ya da Muavin olmalıdır!");

            UniformChartOfAccount ucaf=await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);

            if (ucaf != null) throw new Exception("Bu hesap planı kodu daha önce oluşturulmuş");

            await _ucafService.CreateUcafAsync(request,cancellationToken);

            Log log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(UniformChartOfAccount),
                Progress = "Create",
                UserId = "",
                Data = JsonConvert.SerializeObject(ucaf)
            };

            await _logService.AddAsync(log, request.CompanyId);

            return new();
        }
    }
}
