using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;

namespace toiec_web.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository) 
        {
            _adminRepository = adminRepository;
        }
        public async Task<bool> AddAdmin(string userId)
        {
            var admin = new AdminModel
            {
                idAdmin = Guid.NewGuid(),
                idUser = userId,
            };
            return await _adminRepository.AddAdmin(admin);
        }
    }
}
