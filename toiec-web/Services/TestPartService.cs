using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.TestPart;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Services
{
    public class TestPartService : ITestPartService
    {
        private readonly ITestPartRepository _testPartRepository;
        private readonly IMapper _mapper;

        public TestPartService(ITestPartRepository testPartRepository, IMapper mapper) 
        {
            _testPartRepository = testPartRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TestPartViewModel>> GetAllTestParts()
        {
            var data = await _testPartRepository.GetAllTestParts();
            List<TestPartViewModel> listData = new();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<TestPartViewModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }
    }
}
