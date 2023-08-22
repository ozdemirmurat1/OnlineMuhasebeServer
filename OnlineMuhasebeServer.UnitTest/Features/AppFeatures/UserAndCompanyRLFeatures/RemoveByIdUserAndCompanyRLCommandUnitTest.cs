using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures
{
    public sealed class RemoveByIdUserAndCompanyRLCommandUnitTest
    {
        private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

        public RemoveByIdUserAndCompanyRLCommandUnitTest()
        {
            _serviceMock = new();
        }

        [Fact]
        public async Task RemoveByIdUserAndCompanyRLCommandResponseShouldNotBeNull()
        {
            RemoveByIdUserAndCompanyRLCommand command = new(
                Id: "");

            RemoveByIdUserAndCompanyRLCommandHandler handler=new(_serviceMock.Object);
            RemoveByIdUserAndCompanyRLCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }

    }
}
