using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class RecordRepository : Repository<TestRecord>, IRecordRepository
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public RecordRepository(ToiecDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork,
            IStudentRepository studentRepository) 
            : base(dbContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
        }

        public Task<bool> AddRecord(RecordModel model)
        {
            try
            {
                var record = _mapper.Map<TestRecord>(model);
                Entities.Add(record);
                _unitOfWork.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<RecordModel>> GetRecordByUserTest(string userId, Guid testId)
        {
            //get student id
            var student = await _studentRepository.GetStudentByUserId(userId);

            var listData = new List<RecordModel>();
            var data = await Entities.ToListAsync();

            foreach(var record in data)
            {
                if(record.idTest == testId && record.idStudent == student.idStudent)
                {
                    var obj = _mapper.Map<RecordModel>(record);
                    listData.Add(obj);
                }
            }
            return listData;
        }
    }
}
