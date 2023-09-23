using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFFeatures
{
    public sealed class UpdateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _service;
        private readonly Mock<IApiService> _apiService;
        private readonly Mock<ILogService> _logService;

        public UpdateUCAFCommandUnitTest()
        {
            _service = new();
            _apiService = new();
            _logService = new();
        }

        [Fact]
        public async Task UniformChartOfAccountShouldNotBeNull()
        {
            _service.Setup(s =>
            s.GetByIdAsync(
                It.IsAny<string>(),
                It.IsAny<string>()))
                .ReturnsAsync(new UniformChartOfAccount());
        }

        [Fact]
        public async Task CheckNewUCAFCodeShouldBeNull()
        {
            string companyId = "c38f79cb-87b2-4551-a61a-f8229c714699";
            string code = "100.01.001";
            UniformChartOfAccount ucaf = await _service.Object.GetByCodeAsync(companyId, code, default);
            ucaf.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateUCAFCommandResponseShouldNotBeNull()
        {
            UpdateUCAFCommand command = new(
                Id: "23e0d608-5a6d-4fee-bf7a-bd390c83fc27",
                Code: "100.01.001",
                Name: "MERKEZ KASA",
                Type: "M",
                CompanyId: "c38f79cb-87b2-4551-a61a-f8229c714699");

            await UniformChartOfAccountShouldNotBeNull();

            UpdateUCAFCommandHandler handler = new UpdateUCAFCommandHandler(_service.Object, _logService.Object, _apiService.Object);
            UpdateUCAFCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }


    }
}
