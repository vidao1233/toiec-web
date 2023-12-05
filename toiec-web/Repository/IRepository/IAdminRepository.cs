using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IAdminRepository
    {
        Task<AdminModel> GetAdminByUserId(string userId);
    }
}
