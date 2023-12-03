using toiec_web.Models;
using toiec_web.ViewModels.Test;

namespace toiec_web.Services.IService
{
    public interface ITestService
    {
        Task<IEnumerable<TestViewModel>> GetAllTests();
        Task<TestViewModel> GetTestById(Guid testId);
        Task<IEnumerable<TestViewModel>> GetAllTestByProfessor(string userId);
        Task<IEnumerable<TestViewModel>> GetAllTestByType(string typeName);
        Task<bool> AddTest(TestAddModel model, string userId);
        Task<bool> UpdateTest(TestUpdateModel model, Guid testId, string userId);
        Task<bool> DeleteTest(Guid testId);
    }
}
