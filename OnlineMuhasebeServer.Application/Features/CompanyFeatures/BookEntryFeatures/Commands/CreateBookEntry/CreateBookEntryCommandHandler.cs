using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry
{
    public sealed class CreateBookEntryCommandHandler : ICommandHandler<CreateBookEntryCommand, CreateBookEntryCommandResponse>
    {
        private readonly IBookEntryService _bookEntryService;
        private readonly ILogService _logService;

        public CreateBookEntryCommandHandler(IBookEntryService bookEntryService, ILogService logService)
        {
            _bookEntryService = bookEntryService;
            _logService = logService;
        }

        public Task<CreateBookEntryCommandResponse> Handle(CreateBookEntryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
