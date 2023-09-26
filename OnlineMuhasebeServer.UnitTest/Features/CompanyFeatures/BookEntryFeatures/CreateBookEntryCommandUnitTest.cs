using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures
{
    public sealed class CreateBookEntryCommandUnitTest
    {
        private readonly Mock<IBookEntryService> _service;
        private readonly Mock<ILogService> _logService;
        private readonly Mock<IApiService> _apiService;

        public CreateBookEntryCommandUnitTest()
        {
            _service = new();
            _logService = new();
            _apiService = new();
        }

        [Fact]
        public async Task CreateBookEntryCommandResponseShouldNotBeNull()
        {
            CreateBookEntryCommand command = new(
                CompanyId: "38d24584-7223-4f40-8c51-d8241710780b",
                Type: "Muavin",
                Description: "Yevmiye Fişi",
                Date: "12.02.2023");

            CreateBookEntryCommandHandler handler=new(_service.Object,_logService.Object,_apiService.Object);
            CreateBookEntryCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
