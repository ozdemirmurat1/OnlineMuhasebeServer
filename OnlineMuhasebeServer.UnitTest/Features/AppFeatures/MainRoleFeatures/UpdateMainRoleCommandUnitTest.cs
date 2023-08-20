using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleFeatures
{
    public sealed class UpdateMainRoleCommandUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleService;

        public UpdateMainRoleCommandUnitTest()
        {
            _mainRoleService = new();
        }

        [Fact]
        public async Task MainRoleShouldNotBeNull()
        {
            _mainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new MainRole());
        }

        [Fact]
        public async Task UpdateMainRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateMainRoleCommand(
                Id: "a78db2ff-44b7-4483-b80f-89e06ae2d675",
                Title: "Admin");

            var handler = new UpdateMainRoleCommandHandler(_mainRoleService.Object);

            _mainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new MainRole());

            UpdateMainRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
