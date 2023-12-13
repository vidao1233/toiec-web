using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class UserAnswerRepository : Repository<UserAnswer>, IUserAnswerRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestQuestionUnitRepository _testQuestionUnitRepository;
        private readonly ITestPartRepository _testPartRepository;
        private readonly ToiecDbContext _dbContext;
        private readonly IRecordRepository _recordRepository;

        public UserAnswerRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper
            , IStudentRepository studentRepository, IQuestionRepository questionRepository, 
            ITestQuestionUnitRepository testQuestionUnitRepository, ITestPartRepository testPartRepository,
            IRecordRepository recordRepository) 
            : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _questionRepository = questionRepository;
            _testQuestionUnitRepository = testQuestionUnitRepository;
            _testPartRepository = testPartRepository;
            _dbContext = dbContext;
            _recordRepository = recordRepository;
        }

        public async Task<bool> AddUserAnswer(UserAnswerModel model, string userId)
        {
            try
            {
                //get idStudent
                var student = await _studentRepository.GetStudentByUserId(userId);

                var answer = _mapper.Map<UserAnswer>(model);
                answer.idUAnswer = Guid.NewGuid();
                answer.idStudent = student.idStudent;

                //check userChoice
                var question = await _questionRepository.GetQuestionById(answer.idQuestion);
                if (question.answer == answer.userChoice)
                {
                    answer.state = true;
                }
                Entities.Add(answer);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddListUserAnswers(IEnumerable<UserAnswerModel> models, string userId, Guid testId)
        {
            try
            {
                //get idStudent
                var student = await _studentRepository.GetStudentByUserId(userId);

                var listAnswers = _mapper.Map<List<UserAnswer>>(models);

                foreach (var answer in listAnswers)
                {
                    answer.idUAnswer = Guid.NewGuid();
                    answer.idStudent = student.idStudent;

                    //check userChoice
                    var question = await _questionRepository.GetQuestionById(answer.idQuestion);
                    if (question.answer == answer.userChoice)
                    {
                        answer.state = true;
                    }
                    else
                    {
                        answer.state = false;
                    }

                    Entities.Add(answer);
                }

                //calculate score
                var score = await CalculateScore(userId, testId);

                //map to recordModel
                var record = new RecordModel
                {
                    idRecord = Guid.NewGuid(),
                    idTest = testId,
                    idStudent = student.idStudent,
                    createDate = DateTime.Now,
                    listenCorrect = score.listenCorrect,
                    listenScore = score.listenScore,
                    readingCorrect = score.readingCorrect,
                    readScore = score.readScore,
                    correctAns = score.correctAns,
                    wrongAns = score.wrongAns,
                    totalScore = score.totalScore
                };

                //add record
                await _recordRepository.AddRecord(record);

                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tuple<int, int>> CountCorrectAnswer(string userId, Guid testId)
        {
            //get test
            var test = await _dbContext.Tests
                .Where(t => t.idTest == testId)
                .FirstOrDefaultAsync();

            //get unit
            var unitListOfTest = await _dbContext.TestQuestionUnits
                .Where(tqu => tqu.idTest == test.idTest)
                .ToListAsync();

            //get all userAnswer of student
            var allUserAnsList = await GetAllUserAnswerByStudent(userId);
            Tuple<int, int> count = new(0,0);
            foreach (var unit in unitListOfTest)
            {
                // get userAnswer of unit
                var answerOfUnit = 
                    allUserAnsList.Where(ans => ans.idQuestion == unit.idQuestionUnit).ToList();

                foreach (var answer in answerOfUnit)
                {
                    // Lấy câu hỏi tương ứng với userAnswer
                    var question = await _dbContext.Questions.FindAsync(answer.idQuestion);

                    if (question != null && answer.userChoice == question.answer)
                    {
                        count = await CountCorrectAnswerByPart(answer.idUAnswer);
                    }
                }
            }
            return count;
        }

        public async Task<Tuple<int, int>> CountCorrectAnswerByPart(Guid userAnswerId)
        {
            // get partName from UserAnswer
            var partName = await GetPartName(userAnswerId);

            // count
            int listenCorrect = 0;
            int readCorrect = 0;

            // check partName
            if (partName == "Part 1" || partName == "Part 2" || partName == "Part 3" || partName == "Part 4")
            {
                listenCorrect++;
            }
            else if (partName == "Part 5" || partName == "Part 6" || partName == "Part 7")
            {
                readCorrect++;
            }
            return Tuple.Create(listenCorrect, readCorrect);
        }

        public async Task<ScoreUserAnserModel> CalculateScore(string userId, Guid testId)
        {
            var data = new ScoreUserAnserModel();
            var count = await CountCorrectAnswer(userId, testId);
            var listParam =await _dbContext.ScoreParams.ToListAsync();

            foreach(var item in listParam)
            {
                if(count.Item1 == item.correctAnswers)
                {
                    data.listenScore = item.listenningScore;
                }
                if(count.Item2 == item.correctAnswers)
                {
                    data.readScore = item.readingScore;
                }
            }
            //map data
            data.listenCorrect = count.Item1;
            data.readingCorrect = count.Item2;
            data.correctAns = count.Item1 + count.Item2;
            data.wrongAns = 200 - (count.Item1 + count.Item2);
            data.totalScore = data.listenScore + data.readScore;

            return data;
        }

        public async Task<IEnumerable<UserAnswerModel>> GetAllUserAnswerByStudent(string userId)
        {
            //get idStudent 
            var student = await _studentRepository.GetStudentByUserId(userId);

            var data = await Entities.ToListAsync();
            var listData = new List<UserAnswerModel>();
            foreach (var item in data)
            {
                if (item.idStudent == student.idStudent)
                {
                    var obj = _mapper.Map<UserAnswerModel>(item);
                    listData.Add(obj);
                }
            } 
            return listData;
        }

        public async Task<string> GetPartName(Guid userAnswerId)
        {
            var question = await _questionRepository.GetQuestionByUserAnswer(userAnswerId);
            var unit = await _testQuestionUnitRepository.GetTestQuestionUnitByQuestion(question);
            var partId = await _testPartRepository.GetPartByUnit(unit);

            var part = await _dbContext.TestParts
                .Where(tp => tp.partId == partId)
                .Select(tp => tp.partName)
                .FirstOrDefaultAsync();

            return part;
        }
    }
}
