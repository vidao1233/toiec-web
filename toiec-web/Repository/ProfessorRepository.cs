using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProfessorRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> AddProfessor(ProfessorModel model)
        {
            try
            {
                var professor = _mapper.Map<Professor>(model);
                professor.idProfessor = Guid.NewGuid();
                Entities.Add(professor);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessorModel> GetProfessorByUserId(string userId)
        {
            var professor = await Entities.FirstOrDefaultAsync(pro => pro.idUser == userId);
            return _mapper.Map<ProfessorModel>(professor);            
        }
    }
}
