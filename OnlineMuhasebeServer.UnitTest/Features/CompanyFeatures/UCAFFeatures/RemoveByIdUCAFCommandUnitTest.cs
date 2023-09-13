using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFFeatures
{
    public sealed class RemoveByIdUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _ucafService;

        public RemoveByIdUCAFCommandUnitTest()
        {
            _ucafService = new();
        }

        [Fact]
        public async Task CheckRemoveByIdUcafIsGroupAndAvailableShouldBeTrue()
        {
            _ucafService.Setup(s =>
            s.CheckRemoveByIdUcafIsGroupAndAvailable(
                It.IsAny<string>(),
                It.IsAny<string>()))
                .ReturnsAsync(true);
        }

        [Fact]
        public async Task RemoveByIdUCAFCommandResponseShouldNotBeNull()
        {
            var command = new RemoveByIdUCAFCommand(
                Id: "b696d567-e944-4b22-8a9e-31d5fcc28551",
                CompanyId: "a78db2ff-44b7-4483-b80f-89e06ae2d675");

            await CheckRemoveByIdUcafIsGroupAndAvailableShouldBeTrue();

            var handler = new RemoveByIdUCAFCommandHandler(_ucafService.Object);

            RemoveByIdUCAFCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
