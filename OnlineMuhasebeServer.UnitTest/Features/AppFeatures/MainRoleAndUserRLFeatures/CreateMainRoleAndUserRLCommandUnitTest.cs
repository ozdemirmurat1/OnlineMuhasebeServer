using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures
{
    public sealed class CreateMainRoleAndUserRLCommandUnitTest
    {
        private readonly Mock<IMainRoleAndUserRelationshipService> _serviceMock;

        public CreateMainRoleAndUserRLCommandUnitTest()
        {
            _serviceMock = new();
        }

        [Fact]
        public async Task MainRoleAndUserRelationshipShouldBeNull()
        {
            MainRoleAndUserRelationship entity = await _serviceMock.Object.GetByUserIdCompanyIdAndMainRoleIdAsync(
                userId: "a71dbc8b-5437-491a-a493-0a72c96ed1ad",
                companyId: "a721296c-5460-45fa-bda7-e7fe39f49b1d",
                mainRoleId: "9af77ec0-a7ec-4561-aa34-9ebcda64531d",
                cancellationToken: default);

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task CreateMainRoleAndUserRLCommandResponseShouldNotBeNul()
        {
            CreateMainRoleAndUserRLCommand command = new(
                UserId: "a71dbc8b-5437-491a-a493-0a72c96ed1ad",
                MainRoleId: "9af77ec0-a7ec-4561-aa34-9ebcda64531d",
                CompanyId: "a721296c-5460-45fa-bda7-e7fe39f49b1d");

            CreateMainRoleAndUserRLCommandHandler handler=new(_serviceMock.Object);
            CreateMainRoleAndUserRLCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }

    }
}
