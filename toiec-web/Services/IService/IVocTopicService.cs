using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Services.IService
{
    public interface IVocTopicService
    {
        Task<IEnumerable<VocTopicViewModel>> GetAllVocTopics();
        Task<VocTopicViewModel> GetVocTopicById(Guid topicId);
        Task<bool> AddVocTopic(VocTopicAddModel model, string userId);
        Task<bool> UpdateVocTopic(VocTopicUpdateModel model, Guid topicId, string userId);
        Task<bool> DeleteVocTopic(Guid topicId);
    }
}
