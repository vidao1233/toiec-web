using toeic_web.Models;
using toeic_web.ViewModels.Vocabulary;

namespace toeic_web.Services.IService
{
    public interface IVocabularyService
    {
        Task<IEnumerable<VocabularyViewModel>> GetAllVocabularies();
        Task<VocabularyViewModel> GetVocabularyById(Guid vocId);
        Task<IEnumerable<VocabularyViewModel>> GetAllVocabularyByTopic(Guid topicId);
        Task<bool> AddVocabulary(VocabularyAddModel model, string userId);
        Task<bool> UpdateVocabulary(VocabularyUpdateModel model, Guid vocId, string userId);
        Task<bool> DeleteVocabulary(Guid vocId);
    }
}
