using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public sealed class UpdateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public UpdateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldNotBe()
        {
            _ = _roleServiceMock.Setup(
                x=>x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new AppRole());
        }

        [Fact]
        public async Task AppRoleCodeShouldBeUnique()
        {
            AppRole checkRoleCode = await _roleServiceMock.Object.GetByCode("UCAF.Create");
            checkRoleCode.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateRoleCommand(
                Id: "642ef8d0-0096-439f-9478-59c833f6a336",
                Code: "UCAF.Create",
                Name: "Hesap Planı Kayıt Ekleme");

            var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);

            UpdateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
