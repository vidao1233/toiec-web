using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<QuizModel>> GetAllQuizzes();
        Task<QuizModel> GetQuizById(Guid quizId);
        Task<bool> AddQuiz(QuizModel model);
        Task<bool> UpdateQuiz(QuizModel model, Guid quizId);
        Task<bool> DeleteQuiz(Guid quizId);
    }
}
