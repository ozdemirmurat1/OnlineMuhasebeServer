using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.Commands
{
    public sealed class CreateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _ucafService;

        public CreateUCAFCommandUnitTest()
        {
            _ucafService = new();
        }

        [Fact]
        public async Task UCAFShouldBeNull()
        {
            UniformChartOfAccount ucaf = await _ucafService.Object.GetByCode("100.01.001");
            ucaf.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUCAFCommandResponseShouldNotBeNull()
        {
            var command = new CreateUCAFCommand(
                Code: "100.01.001",
                Name: "TL Kasa",
                Type: "M",
                CompanyId: "a78db2ff-44b7-4483-b80f-89e06ae2d675");

            var handler = new CreateUCAFCommandHandler(_ucafService.Object);

            CreateUCAFCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
