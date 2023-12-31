﻿using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<bool> AddStudent(StudentModel model);
        Task<bool> UpdateStudent(StudentModel model);
        Task<bool> CheckFreeTest(string userId);
        Task<StudentModel> GetStudentByUserId(string userId);
        Task<StudentModel> GetStudentById(Guid stuId);
    }
}
