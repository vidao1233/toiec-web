using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Lesson;
using toiec_web.ViewModels.Quiz;

namespace toiec_web.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository quizRepository, IMapper mapper) 
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddQuiz(QuizAddModel model)
        {
            var data = _mapper.Map<QuizModel>(model);
            return await _quizRepository.AddQuiz(data);
        }

        public async Task<bool> DeleteQuiz(Guid quizId)
        {
            return await _quizRepository.DeleteQuiz(quizId);
        }

        public async Task<IEnumerable<QuizViewModel>> GetAllQuizByLesson(Guid lesonId)
        {
            var data = await _quizRepository.GetAllQuizByLesson(lesonId);
            List<QuizViewModel> listData = new List<QuizViewModel>();
            if(data != null)
            {
                foreach (var dataItem in data)
                {
                    var obj = _mapper.Map<QuizViewModel>(dataItem);
                    listData.Add(obj);  
                }
                return listData;
            }
            return null;
        }

        public async Task<IEnumerable<QuizViewModel>> GetAllQuizzes()
        {
            var data = await _quizRepository.GetAllQuizzes();
            List<QuizViewModel> listData = new List<QuizViewModel>();
            if (data != null)
            {
                foreach (var dataItem in data)
                {
                    var obj = _mapper.Map<QuizViewModel>(dataItem);
                    listData.Add(obj);
                }
                return listData;
            }
            return null;
        }

        public async Task<QuizViewModel> GetQuizById(Guid quizId)
        {
            var dataItem = await _quizRepository.GetQuizById(quizId);
            if (dataItem != null)
            {
                var obj = _mapper.Map<QuizViewModel>(dataItem);
                return obj;
            }
            return null;
        }

        public async Task<bool> UpdateQuiz(QuizUpdateModel model, Guid quizId)
        {
            var data = _mapper.Map<QuizModel>(model);
            return await _quizRepository.UpdateQuiz(data, quizId);
        }
    }
}
