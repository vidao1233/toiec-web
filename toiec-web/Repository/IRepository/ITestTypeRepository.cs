using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface ITestTypeRepository
    {
        Task<IEnumerable<TestTypeModel>> GetAllTestTypes();
        Task<TestTypeModel> GetTestTypeById(Guid typeId);
        Task<bool> AddTestType(TestTypeModel model);
        Task<bool> UpdateTestType(TestTypeModel model, Guid typeId);
        Task<bool> DeleteTestType(Guid typeId);
    }
}
