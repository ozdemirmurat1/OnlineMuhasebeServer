using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures
{
    public sealed class CreateMainRoleAndRoleRLCommandUnitTest
    {
        private readonly Mock<IMainRoleAndRoleRelationshipService> _service;

        public CreateMainRoleAndRoleRLCommandUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task MainRoleAndRoleRelationshipShouldBeNull()
        {
            MainRoleAndRoleRelationship entity = await _service.Object.GetByRoleIdAndMainRoleId(
                roleId: "1311b95c-db7c-4b49-bdac-3125d88d4c22",
                mainRoleId: "457f7a3e-56fd-4b18-9055-21eea6b8e26d",
                cancellationToken: default);

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task CreateMainRoleAndRoleRLCommandResponseShouldNotBeNull()
        {
            var command = new CreateMainRoleAndRoleRLCommand(
                RoleId: "1311b95c-db7c-4b49-bdac-3125d88d4c22",
                MainRoleId: "457f7a3e-56fd-4b18-9055-21eea6b8e26d");

            var handler = new CreateMainRoleAndRoleRLCommandHandler(_service.Object);

            CreateMainRoleAndRoleRLCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
