﻿
using toiec_web.ViewModels.TestQuestionUnit;

namespace toiec_web.Services.IService
{
    public interface ITestQuestionUnitService
    {
        Task<IEnumerable<TestQuestionUnitViewModel>> GetAllTestQuestionUnits();
        Task<TestQuestionUnitViewModel> GetTestQuestionUnitById(Guid unitId);
        Task<IEnumerable<TestQuestionUnitViewModel>> GetAllTestQuestionUnitByTest(Guid testId);
        Task<IEnumerable<TestQuestionUnitViewModel>> GetAllTestQuestionUnitByPart(Guid partId);
        Task<bool> AddTestQuestionUnit(TestQuestionUnitAddModel model);
        Task<bool> UpdateTestQuestionUnit(TestQuestionUnitUpdateModel model, Guid unitId);
        Task<bool> DeleteTestQuestionUnit(Guid unitId);
    }
}
