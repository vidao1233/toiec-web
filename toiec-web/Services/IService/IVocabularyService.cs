using toiec_web.ViewModels.Vocabulary;

namespace toiec_web.Services.IService
{
    public interface IVocabularyService
    {
        Task<IEnumerable<VocabularyViewModel>> GetAllVocabularies();
        Task<VocabularyViewModel> GetVocabularyById(Guid vocId);
        Task<bool> AddVocabulary(VocabularyAddModel model);
        Task<bool> UpdateVocabulary(VocabularyUpdateModel model, Guid vocId, Guid professorId);
        Task<bool> DeleteVocabulary(Guid vocId);
    }
}
