using AutoMapper;
using toeic_web.Models;
using toeic_web.Repository.IRepository;
using toeic_web.Services.IService;
using toeic_web.ViewModels.Vocabulary;

namespace toeic_web.Services
{
    public class VocabularyService : IVocabularyService
    {
        private readonly IVocabularyRepository _vocabularyRepository;
        private readonly IMapper _mapper;

        public VocabularyService(IVocabularyRepository vocabularyRepository, IMapper mapper) 
        {
            _vocabularyRepository = vocabularyRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddVocabulary(VocabularyAddModel model, string userId)
        {
            var data = _mapper.Map<VocabularyModel>(model);
            return await _vocabularyRepository.AddVocabulary(data, userId);
        }

        public async Task<bool> DeleteVocabulary(Guid vocId)
        {
            return await _vocabularyRepository.DeleteVocabulary(vocId);
        }

        public async Task<IEnumerable<VocabularyViewModel>> GetAllVocabularies()
        {
            var data = await _vocabularyRepository.GetAllVocabularies();
            List<VocabularyViewModel> listData = new List<VocabularyViewModel>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<VocabularyViewModel>(item);
                    listData.Add(obj);
                }
                return listData;
            }
            return null;
        }

        public async Task<IEnumerable<VocabularyViewModel>> GetAllVocabularyByTopic(Guid topicId)
        {
            var data = await _vocabularyRepository.GetAllVocabularyByTopic(topicId);
            List<VocabularyViewModel> listData = new List<VocabularyViewModel>();
            if(data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<VocabularyViewModel>(item);
                    listData.Add(obj);
                }
                return listData;
            }
            return null;
        }

        public async Task<VocabularyViewModel> GetVocabularyById(Guid vocId)
        {
            var data = await _vocabularyRepository.GetVocabularyById(vocId);
            if (data != null)
            {
                var obj = _mapper.Map<VocabularyViewModel>(data);
                return obj;
            }
            return null;
        }

        public async Task<bool> UpdateVocabulary(VocabularyUpdateModel model, Guid vocId, string userId)
        {
            var data = _mapper.Map<VocabularyModel>(model);
            return await _vocabularyRepository.UpdateVocabulary(data, vocId, userId);
        }
    }
}
