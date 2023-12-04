using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Course;
using toiec_web.ViewModels.Question;

namespace toiec_web.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        

        public QuestionService(IMapper mapper, IQuestionRepository questionRepository) 
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            
        }
        public async Task<bool> AddQuestion(QuestionAddModel model, string userId)
        {
            var data = _mapper.Map<QuestionModel>(model);
            return await _questionRepository.AddQuestion(data, userId);
        }

        public async Task<bool> DeleteQuestion(Guid questionId)
        {
            return await _questionRepository.DeleteQuestion(questionId);
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAllQuestionByProfessor(string userId)
        {
            var data = await _questionRepository.GetAllQuestionByProfessor(userId);
            List<QuestionViewModel> listData = new List<QuestionViewModel>();
            if (data != null)
            {
                foreach (var dataItem in data)
                {
                    var obj = _mapper.Map<QuestionViewModel>(dataItem);
                    listData.Add(obj);                 
                }                
            }
            return listData;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAllQuestionByQuiz(Guid quizId)
        {
            var data = await _questionRepository.GetAllQuestionByQuiz(quizId);
            List<QuestionViewModel> listData = new List<QuestionViewModel>();
            if (data != null)
            {
                foreach (var dataItem in data)
                {
                    var obj = _mapper.Map<QuestionViewModel>(dataItem);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAllQuestionByUnit(Guid unitId)
        {
            var data = await _questionRepository.GetAllQuestionByUnit(unitId);
            List<QuestionViewModel> listData = new List<QuestionViewModel>();
            if (data != null)
            {
                foreach (var dataItem in data)
                {
                    var obj = _mapper.Map<QuestionViewModel>(dataItem);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAllQuestions()
        {
            var data = await _questionRepository.GetAllQuestions();
            List<QuestionViewModel> listData = new List<QuestionViewModel>();
            if (data != null)
            {
                foreach (var dataItem in data)
                {
                    var obj = _mapper.Map<QuestionViewModel>(dataItem);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<QuestionViewModel> GetQuestionById(Guid questionId)
        {
            var data = await _questionRepository.GetQuestionById(questionId);

            if (data != null)
            {
                var courseViewModel = _mapper.Map<QuestionViewModel>(data);
                return courseViewModel;
            }

            return null;
        }

        public async Task<bool> UpdateQuestion(QuestionUpdateModel model, Guid questionId, string userId)
        {
            var data = _mapper.Map<QuestionModel>(model);
            return await _questionRepository.UpdateQuestion(data, questionId ,userId);
        }
    }
}
