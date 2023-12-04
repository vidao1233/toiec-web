﻿using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface ITestQuestionUnitRepository
    {
        Task<IEnumerable<TestQuestionUnitModel>> GetAllTestQuestionUnits();
        Task<TestQuestionUnitModel> GetTestQuestionUnitById(Guid unitId);
        Task<IEnumerable<TestQuestionUnitModel>> GetAllTestQuestionUnitByTest(Guid testId);
        Task<IEnumerable<TestQuestionUnitModel>> GetAllTestQuestionUnitByPart(Guid partId);
        Task<bool> AddTestQuestionUnit(TestQuestionUnitModel model);
        Task<bool> UpdateTestQuestionUnit(TestQuestionUnitModel model, Guid unitId);
        Task<bool> DeleteTestQuestionUnit(Guid unitId);
    }
}