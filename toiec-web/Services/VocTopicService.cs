using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Services
{
    public class VocTopicService : IVocTopicService
    {
        private readonly IVocTopicRepository _vocTopicRepository;
        private readonly IMapper _mapper;

        public VocTopicService(IVocTopicRepository vocTopicRepository, IMapper mapper) 
        {
            _vocTopicRepository = vocTopicRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddVocTopic(VocTopicAddModel model, string userId)
        {
            var data = _mapper.Map<VocTopicModel>(model);
            return await _vocTopicRepository.AddVocTopic(data, userId);
        }

        public async Task<bool> DeleteVocTopic(Guid topicId)
        {
            return await _vocTopicRepository.DeleteVocTopic(topicId);
        }

        public async Task<IEnumerable<VocTopicViewModel>> GetAllVocTopics()
        {
            var data = await _vocTopicRepository.GetAllVocTopics();
            List<VocTopicViewModel> listData = new List<VocTopicViewModel>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<VocTopicViewModel>(item);
                    listData.Add(obj);
                }
                return listData;
            }
            return null;
        }

        public async Task<VocTopicViewModel> GetVocTopicById(Guid topicId)
        {
            var data = await _vocTopicRepository.GetVocTopicById(topicId);
            if(data != null)
            {
                var obj = _mapper.Map<VocTopicViewModel>(data);
                return obj;
            }
            return null;
        }

        public async Task<bool> UpdateVocTopic(VocTopicUpdateModel model, Guid topicId, string userId)
        {
            var data = _mapper.Map<VocTopicModel>(model);
            return await _vocTopicRepository.UpdateVocTopic(data, topicId, userId);

        }
    }
}
