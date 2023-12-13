﻿using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IUserAnswerRepository
    {
        Task<IEnumerable<UserAnswerModel>> GetAllUserAnswerByStudent(string userId);
        Task<ScoreUserAnserModel> CalculateScore(List<UserAnswerModel> models);
        Task<string> GetPartName(UserAnswerModel model);
        Task<bool> AddUserAnswer(UserAnswerModel model, string userId);
        Task<bool> AddListUserAnswers(IEnumerable<UserAnswerModel> models, string userId, Guid testId);
    }
}
