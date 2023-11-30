using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;

namespace toiec_web.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository) 
        {
            _professorRepository = professorRepository;
        }

        public async Task<bool> AddProfessor(string userId)
        {
            var professor = new ProfessorModel
            {
                idProfessor = Guid.Empty,
                idUser = userId,
            };
            return await _professorRepository.AddProfessor(professor);
        }
    }
}
