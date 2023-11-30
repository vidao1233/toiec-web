namespace toiec_web.Services.IService
{
    public interface IProfessorService
    {
        Task<bool> AddProfessor(string userId);
    }
}
