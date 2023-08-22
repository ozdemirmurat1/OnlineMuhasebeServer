using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures
{
    public sealed class CreateUserAndCompanyRLCommandUnitTest
    {
        private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

        public CreateUserAndCompanyRLCommandUnitTest()
        {
            _serviceMock = new();
        }

        [Fact]
        public async Task UserAndCompanyRelationshipShouldBeNull()
        {
            UserAndCompanyRelationship userAndCompanyRelationship = await _serviceMock.Object.GetByUserIdAndCompanyId(
                userId: "a58cb85f-586f-4c20-8fd1-22eac9a72175",
                companyId: "d33e4faa-0aa6-4445-8710-d48e5ad057d4",
                cancellationToken: default);

            userAndCompanyRelationship.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUserAndCompanyRLCommandResponseShouldNotBeNull()
        {
            CreateUserAndCompanyRLCommand command = new(
                AppUserId: "a58cb85f-586f-4c20-8fd1-22eac9a72175",
                CompanyId: "d33e4faa-0aa6-4445-8710-d48e5ad057d4");

            CreateUserAndCompanyRLCommandHandler handler=new(_serviceMock.Object);

            CreateUserAndCompanyRLCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
