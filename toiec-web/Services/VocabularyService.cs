using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Vocabulary;

namespace toiec_web.Services
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
        public async Task<bool> AddVocabulary(VocabularyAddModel model)
        {
            var data = _mapper.Map<VocabularyModel>(model);
            return await _vocabularyRepository.AddVocabulary(data);
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

        public async Task<bool> UpdateVocabulary(VocabularyUpdateModel model, Guid vocId, Guid professorId)
        {
            var data = _mapper.Map<VocabularyModel>(model);
            return await _vocabularyRepository.UpdateVocabulary(data, vocId, professorId);
        }
    }
}
