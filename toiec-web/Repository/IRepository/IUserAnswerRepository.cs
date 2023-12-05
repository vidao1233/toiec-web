using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IUserAnswerRepository
    {
        Task<IEnumerable<UserAnswerModel>> GetAllUserAnswerByStudent(string userId);
        Task<ScoreUserAnserModel> CalculateScore(string userid, Guid testid);
        Task<string> GetPartName(Guid userAnswerId);
        Task<Tuple<int, int>> CountCorrectAnswerByPart(Guid userAnswerId);
        Task<Tuple<int, int>> CountCorrectAnswer(string userId, Guid testId);
        Task<bool> AddUserAnswer(UserAnswerModel model, string userId);
    }
}
