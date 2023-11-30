using Microsoft.AspNetCore.Identity;
using toiec_web.Models;
using toiec_web.Services.IService;

namespace toiec_web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Users> _userManager;

        public AuthenticationService(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }
        public Task<bool> CreateStudent(string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetCurrentUserId(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            string userId = user.Id;

            if (user != null)
            {
                return userId;
            }
            return null;
        }

        public async Task<string> GetCurrentUserRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userRole = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                return userRole[0];
            }
            return null;
        }
    }
}
