namespace toiec_web.Services.IService
{
    public interface IStudentService
    {
        Task<bool> AddStudent(string userId);
    }
}
