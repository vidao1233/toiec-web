using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IVocTopicRepository
    {
        Task<IEnumerable<VocTopicModel>> GetAllVocTopics();
        Task<VocTopicModel> GetVocTopicById(Guid topicId);
        Task<bool> AddVocTopic(VocTopicModel model, string userId);
        Task<bool> UpdateVocTopic(VocTopicModel model, Guid topicId, string userId);
        Task<bool> DeleteVocTopic(Guid topicId);
    }
}
