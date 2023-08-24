using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthService authService)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);

            if (user == null) throw new Exception("Kullanıcı Bulunamadı");

            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);

            if (!checkUser) throw new Exception("Şifreniz yanluş!");

            IList<Company> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);

            if (companies.Count() == 0) throw new Exception("Herhangi bir şirkete kayıtlı değilsiniz!");

            LoginCommandResponse response = new(
                user.Email,
                user.NameLastName,
                user.Id,
                await _jwtProvider.CreateTokenAsync(user, roles));

            return response;
        }
    }
}
