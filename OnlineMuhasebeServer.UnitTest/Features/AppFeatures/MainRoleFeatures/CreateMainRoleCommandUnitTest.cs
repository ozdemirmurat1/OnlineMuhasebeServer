using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleFeatures
{
    public sealed class CreateMainRoleCommandUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleService;

        public CreateMainRoleCommandUnitTest()
        {
            _mainRoleService = new();
        }

        [Fact]
        public async Task MainRoleShouldBeNull()
        {
            MainRole mainRole = await _mainRoleService.Object.GetByTitleAndCompanyId(
                title: "Admin",
                companyId: "9f0c384d-a589-47ba-b4df-4760725e2c84",
                default);

            mainRole.ShouldBeNull();
        }

        [Fact]
        public async Task CreateMainRoleCommandResponseShouldNotBeNull()
        {
            var command = new CreateMainRoleCommand(
                Title: "Admin",
                IsRoleCreatedByAdmin: false,
                CompanyId: "a78db2ff-44b7-4483-b80f-89e06ae2d675");

            var handler = new CreateMainRoleCommandHandler(_mainRoleService.Object);

            CreateMainRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
