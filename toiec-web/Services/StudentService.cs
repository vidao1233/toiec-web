using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;

namespace toiec_web.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository ,IMapper mapper) 
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddStudent(string userId)
        {
            var student = new StudentModel
            {
                idStudent = Guid.Empty,
                idUser = userId,
                freeTest = true,
            };
            return await _studentRepository.AddStudent(student);
        }

        public Task<StudentModel> GetStudentById(Guid stuId)
        {
            return _studentRepository.GetStudentById(stuId);
        }

        public Task<StudentModel> GetStudentByUserId(string userId)
        {
            return _studentRepository.GetStudentByUserId(userId);
        }
    }
}
