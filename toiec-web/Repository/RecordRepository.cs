using AutoMapper;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class RecordRepository : Repository<TestRecord>, IRecordRepository
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RecordRepository(ToiecDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork) : base(dbContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
    }
}
