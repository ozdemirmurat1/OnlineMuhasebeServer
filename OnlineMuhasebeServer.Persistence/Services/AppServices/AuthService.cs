using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistence.Services.AppServices
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserAndCompanyRelationshipService _companyRelationService;

        public AuthService(UserManager<AppUser> userManager, IUserAndCompanyRelationshipService companyRelationService)
        {
            _userManager = userManager;
            _companyRelationService = companyRelationService;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName)
        {
            return await _userManager.Users.Where(p=>p.Email==emailOrUserName || p.UserName==emailOrUserName).FirstOrDefaultAsync();
        }

        public async Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string userId)
        {
            return await _companyRelationService.GetListByUserId(userId);
        }
    }
}
