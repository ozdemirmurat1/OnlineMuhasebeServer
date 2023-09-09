using Moq;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures
{
    public sealed class UpdateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _service;

        public UpdateUCAFCommandUnitTest()
        {
            _service = new();
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
    }
}
