using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IProfessorRepository
    {
        Task<bool> AddProfessor(ProfessorModel model);
    }
}
