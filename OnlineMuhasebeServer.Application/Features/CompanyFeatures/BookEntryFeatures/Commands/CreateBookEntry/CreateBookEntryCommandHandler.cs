using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry
{
    public sealed class CreateBookEntryCommandHandler : ICommandHandler<CreateBookEntryCommand, CreateBookEntryCommandResponse>
    {
        private readonly IBookEntryService _bookEntryService;
        public Task<CreateBookEntryCommandResponse> Handle(CreateBookEntryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
