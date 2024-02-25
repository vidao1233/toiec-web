using toeic_web.Models;

namespace toeic_web.Repository.IRepository
{
    public interface IVocabularyRepository
    {
        Task<IEnumerable<VocabularyModel>> GetAllVocabularies();
        Task<VocabularyModel> GetVocabularyById(Guid vocId);
        Task<IEnumerable<VocabularyModel>> GetAllVocabularyByTopic(Guid topicId);
        Task<bool> AddVocabulary(VocabularyModel model, string userId);
        Task<bool> UpdateVocabulary(VocabularyModel model, Guid vocId, string userId);
        Task<bool> DeleteVocabulary(Guid vocId);
    }
}
