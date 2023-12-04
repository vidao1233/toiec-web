using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface ITestPartRepository
    {
        Task<IEnumerable<TestPartModel>> GetAllTestParts();
    }
}
