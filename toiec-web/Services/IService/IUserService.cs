﻿using toiec_web.ViewModels.User;

namespace toiec_web.Services.IService
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task<UserViewModel> GetUserById(string userId);
        Task<bool> AddUser(UserViewModel model);
        Task<bool> UpdateUser(UserViewModel model, string userId);
        Task<bool> DeleteUser(string userId);
    }
}
