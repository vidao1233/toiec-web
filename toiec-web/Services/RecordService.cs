using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Record;

namespace toiec_web.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IMapper _mapper;

        public RecordService(IRecordRepository recordRepository, IMapper mapper) 
        {
            _recordRepository = recordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecordViewModel>> GetRecordByUser(string userId)
        {
            var data = await _recordRepository.GetRecordByUser(userId);
            var listData = new List<RecordViewModel>();

            foreach (var record in data)
            {
                var obj = _mapper.Map<RecordViewModel>(record);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<IEnumerable<RecordViewModel>> GetRecordByUserTest(string userId, Guid testId)
        {
            var data = await _recordRepository.GetRecordByUserTest(userId, testId);
            var listData = new List<RecordViewModel>();

            foreach (var record in data)
            {
                var obj = _mapper.Map<RecordViewModel>(record);
                listData.Add(obj);
            }
            return listData;
        }
    }
}
