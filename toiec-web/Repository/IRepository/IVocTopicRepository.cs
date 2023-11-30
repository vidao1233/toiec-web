using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IVocTopicRepository
    {
        Task<IEnumerable<VocTopicModel>> GetAllVocTopics();
        Task<VocTopicModel> GetVocTopicById(Guid topicId);
        Task<bool> AddVocTopic(VocTopicModel model);
        Task<bool> UpdateVocTopic(VocTopicModel model, Guid topicId, Guid professorId);
        Task<bool> DeleteVocTopic(Guid topicId);
    }
}
