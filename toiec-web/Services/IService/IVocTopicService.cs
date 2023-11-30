using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Services.IService
{
    public interface IVocTopicService
    {
        Task<IEnumerable<VocTopicViewModel>> GetAllVocTopics();
        Task<VocTopicViewModel> GetVocTopicById(Guid topicId);
        Task<bool> AddVocTopic(VocTopicAddModel model);
        Task<bool> UpdateVocTopic(VocTopicUpdateModel model, Guid topicId, Guid professorId);
        Task<bool> DeleteVocTopic(Guid topicId);
    }
}
