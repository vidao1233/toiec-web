﻿using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseModel>> GetAllCourses();
        Task<CourseModel> GetCourseById(Guid courseId);
        Task<bool> AddCourse(CourseModel model);
        Task<bool> UpdateCourse(CourseModel model, Guid courseId);
        Task<bool> DeleteCourse(Guid courseId);

    }
}
