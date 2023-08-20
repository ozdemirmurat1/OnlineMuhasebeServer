using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures
{
    public sealed class DeleteRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public DeleteRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldNotBeNull()
        {
            _roleServiceMock.Setup(
                x => x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new Domain.AppEntities.Identity.AppRole());
        }

        [Fact]
        public async Task DeleteRoleCommandResponseShouldNotBeNull()
        {
            var command = new DeleteRoleCommand(
                Id: "a1edf0fc-35c3-4f2b-b1ec-04b59bf8a870");

            _roleServiceMock.Setup(
                x => x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new Domain.AppEntities.Identity.AppRole());

            var handler = new DeleteRoleCommandHandler(_roleServiceMock.Object);
            DeleteRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();

        }
    }
}
