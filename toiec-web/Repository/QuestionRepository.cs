using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.ViewModels.DoTest;

namespace toiec_web.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ToiecDbContext _dbContext;
        private readonly IProfessorRepository _professorRepository;
        private readonly ITestQuestionUnitRepository _testQuestionUnitRepository;

        public QuestionRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper
            , IProfessorRepository professorRepository, ITestQuestionUnitRepository testQuestionUnitRepository) 
            : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
            _professorRepository = professorRepository;
            _testQuestionUnitRepository = testQuestionUnitRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> AddQuestion(QuestionModel model, string userId)
        {
            try
            {
                //get professor by userId
                var professor = await _professorRepository.GetProfessorByUserId(userId);
                
                var question = _mapper.Map<Question>(model);
                question.idQuestion = Guid.NewGuid();
                question.idProfessor = professor.idProfessor;
                
                Entities.Add(question);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteQuestion(Guid questionId)
        {
            var question = GetById(questionId);
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question));
            }
            Entities.Remove(question);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestionByProfessor(string userId)
        {
            //get professor by userId
            var professor = await _professorRepository.GetProfessorByUserId(userId);

            var listData = new List<QuestionModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                if (item.idProfessor == professor.idProfessor)
                {
                    var obj = _mapper.Map<QuestionModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestionByQuiz(Guid quizId)
        {
            var listData = new List<QuestionModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                if (item.idQuiz == quizId) 
                {
                    var obj = _mapper.Map<QuestionModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestionByUnit(Guid unitId)
        {
            var listData = new List<QuestionModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                if (item.idUnit == unitId)
                {
                    var obj = _mapper.Map<QuestionModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestions()
        {
            var listData = new List<QuestionModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<QuestionModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<IEnumerable<DoTestViewModel>> GetDoTest(Guid testId)
        {
            var test = await _dbContext.Tests
                .Include(t => t.TestQuestionUnits)
                    .ThenInclude(tqu => tqu.Questions)
                .FirstOrDefaultAsync(t => t.idTest == testId);

            if (test == null)
            {
                // Không tìm thấy bài kiểm tra
                return null;
            }

            var partIds = test.TestQuestionUnits.Select(tqu => tqu.idTestPart).Distinct();

            var parts = await _dbContext.TestParts
                .Include(tp => tp.TestQuestionUnits)
                .Where(tp => partIds.Contains(tp.partId))
                .OrderBy(tp => tp.partName)
                .ToListAsync();

            var viewModels = new List<DoTestViewModel>();

            foreach (var part in parts)
            {
                var viewModel = new DoTestViewModel
                {
                    parts = new List<DoTestPartModel>()
                };
                
                foreach (var unit in part.TestQuestionUnits)
                {
                    var unitModel = new DoTestUnitModel
                    {
                        idQuestionUnit = unit.idQuestionUnit,
                        questions = new List<DoTestQuestionModel>()
                    };

                    foreach (var question in unit.Questions)
                    {
                        var questionModel = new DoTestQuestionModel
                        {
                            idQuestion = question.idQuestion,
                            content = question.content,
                            answer = question.answer,
                            explaination = question.explaination
                        };

                        unitModel.questions.Add(questionModel);
                    }

                    viewModel.parts.Add(new DoTestPartModel 
                    { 
                        units = new List<DoTestUnitModel> { unitModel }, 
                        partName = part.partName 
                    });
                }

                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public async Task<QuestionModel> GetQuestionById(Guid questionId)
        {
            IAsyncEnumerable<Question> questions = Entities.AsAsyncEnumerable();
            await foreach (var course in questions)
            {
                if (course.idQuestion == questionId)
                {
                    QuestionModel data = _mapper.Map<QuestionModel>(course);
                    return data;
                }
            }
            return null;
        }

        public async Task<Guid> GetQuestionByUserAnswer(Guid questionId)
        {
            var question = await Entities.FirstOrDefaultAsync(q => q.idQuestion == questionId);
            if(question != null)
            {
                var data = _mapper.Map<QuestionModel>(question);
                return data.idQuestion;
            }
            return Guid.Empty;
        }

        public async Task<bool> UpdateQuestion(QuestionModel model, Guid questionId, string userId)
        {
            try
            {
                //get professor by userId
                var professor = await _professorRepository.GetProfessorByUserId(userId);

                var question = _mapper.Map<Question>(model);
                question.idQuestion = questionId;
                question.idProfessor = professor.idProfessor;
                Entities.Update(question);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
