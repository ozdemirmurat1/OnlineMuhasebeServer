using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.RemoveByIdBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures
{
    public sealed class RemoveByIdBookEntryCommandUnitTest
    {
        private readonly Mock<IBookEntryService> _service;
        private readonly Mock<ILogService> _logService;
        private readonly Mock<IApiService> _apiService;

        public RemoveByIdBookEntryCommandUnitTest()
        {
            _apiService = new();
            _logService = new();
            _service = new();
        }

        [Fact]
        public async Task RemoveByIdBookEntryCommandResponseShouldNotBeNull()
        {
            RemoveByIdBookEntryCommand command = new(
                Id: "ae62bb5a-7017-4f71-90f8-321ed3704e1d",
                CompanyId: "14dcdea6-3fe0-4dc8-9429-bcc5cb75268c");

            RemoveByIdBookEntryCommandHandler handler=new RemoveByIdBookEntryCommandHandler(_service.Object,_logService.Object,_apiService.Object);

            RemoveByIdBookEntryCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
