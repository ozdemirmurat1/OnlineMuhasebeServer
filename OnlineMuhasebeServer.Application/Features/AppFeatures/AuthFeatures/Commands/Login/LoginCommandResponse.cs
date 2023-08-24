using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public sealed record LoginCommandResponse(
        string Token,
        string RefreshToken,
        string Email,
        string UserId,
        string NameLastName,
        IList<CompanyDto> Companies,
        CompanyDto CompanyDto);
}
