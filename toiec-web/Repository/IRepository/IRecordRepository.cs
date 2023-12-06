using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IRecordRepository
    {
        Task<bool> AddRecord(RecordModel model);
    }
}
