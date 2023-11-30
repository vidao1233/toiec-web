using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(string userId);
        Task<bool> AddUser(UserModel model);
        Task<bool> UpdateUser(UserModel model, string userId);
        Task<bool> DeleteUser(string userId);
    }
}
