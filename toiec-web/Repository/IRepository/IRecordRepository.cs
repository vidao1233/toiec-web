using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IRecordRepository
    {
        Task<IEnumerable<RecordModel>> GetRecordByUserTest(string userId, Guid testId);
        Task<IEnumerable<RecordModel>> GetRecordByUser(string userId);
        Task<bool> AddRecord(RecordModel model);
        Task<bool> UpdateRecord(RecordModel model, Guid idRecord);
    }
}
