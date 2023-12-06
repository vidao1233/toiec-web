using toiec_web.Models;
using toiec_web.ViewModels.UserAnswer;

namespace toiec_web.Services.IService
{
    public interface IUserAnswerService
    {
        Task<bool> AddUserAnswer(UserAnswerAddModel model, string userId);
        Task<bool> AddListUserAnswers(IEnumerable<UserAnswerModel> models, string userId, Guid testId);
        Task<ScoreUserAnserModel> CalculateScore(string userid, Guid testid);
    }
}
