using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IVocabularyRepository
    {
        Task<IEnumerable<VocabularyModel>> GetAllVocabularies();
        Task<VocabularyModel> GetVocabularyById(Guid vocId);
        Task<bool> AddVocabulary(VocabularyModel model);
        Task<bool> UpdateVocabulary(VocabularyModel model, Guid vocId, Guid professorId);
        Task<bool> DeleteVocabulary(Guid vocId);
    }
}
