using AutoMapper;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public StudentRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base (dbContext) 
        {
            _uow = uow;
            _mapper = mapper;
        }
        public Task<bool> AddStudent(StudentModel model)
        {
            try
            {
                var student = _mapper.Map<Student>(model);
                student.idStudent = Guid.NewGuid();
                Entities.Add(student);
                _uow.SaveChanges(); 
                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
