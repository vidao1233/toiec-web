using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<bool> AddStudent(StudentModel model);
    }
}
