using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.UpdateBookEntry;
using Shouldly;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures
{
    public sealed class UpdateBookEntryCommandUnitTest
    {
        private readonly Mock<IBookEntryService> _service;
        private readonly Mock<ILogService> _logService;
        private readonly Mock<IApiService> _apiService;

        public UpdateBookEntryCommandUnitTest()
        {
            _service = new();
            _logService = new();
            _apiService = new();
        }

        [Fact]
        public async Task UpdateBookEntryCommandResponseShouldNotBeNull()
        {
            string id = "9969f1f3-36c9-4077-852c-3aa4bc8da3fa";
            string companyId = "38d24584-7223-4f40-8c51-d8241710780b";

            _service.Setup(s =>
                            s.GetByIdAsync(id, companyId)).ReturnsAsync(new BookEntry());

            UpdateBookEntryCommand command = new(
                Id: id,
                CompanyId:companyId ,
                Type: "Muavin",
                Description: "Yevmiye Fişi",
                Date: "12.02.2023");

            UpdateBookEntryCommandHandler handler = new(_service.Object,_logService.Object, _apiService.Object);
            UpdateBookEntryCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
