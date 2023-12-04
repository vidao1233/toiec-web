using toiec_web.Models;
using toiec_web.ViewModels.TestPart;

namespace toiec_web.Services.IService
{
    public interface ITestPartService
    {
        Task<IEnumerable<TestPartViewModel>> GetAllTestParts();
    }
}
