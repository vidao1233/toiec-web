using toiec_web.Models;
using toiec_web.ViewModels.Record;

namespace toiec_web.Services.IService
{
    public interface IRecordService
    {
        Task<IEnumerable<RecordViewModel>> GetRecordByUserTest(string userId, Guid testId);
    }
}
