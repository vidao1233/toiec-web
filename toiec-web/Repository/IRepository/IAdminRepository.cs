using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IAdminRepository
    {
<<<<<<< HEAD
        Task<bool> AddAdmin(AdminModel model);
=======
        Task<AdminModel> GetAdminByUserId(string userId);
>>>>>>> main
    }
}
