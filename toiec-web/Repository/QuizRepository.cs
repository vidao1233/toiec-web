﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public QuizRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> AddQuiz(QuizModel model)
        {
            try
            {
                var quiz = _mapper.Map<Quiz>(model);
                quiz.idQuiz = Guid.NewGuid();
                Entities.Add(quiz);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteQuiz(Guid quizId)
        {
            var quiz = GetById(quizId);
            if (quiz == null)
            {
                throw new ArgumentNullException(nameof(quiz));
            }
            Entities.Remove(quiz);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<QuizModel>> GetAllQuizzes()
        {
            var listData = new List<QuizModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<QuizModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<QuizModel> GetQuizById(Guid quizId)
        {
            IAsyncEnumerable<Quiz> quizzes = Entities.AsAsyncEnumerable();
            await foreach (var quiz in quizzes)
            {
                if (quiz.idQuiz == quizId)
                {
                    QuizModel data = _mapper.Map<QuizModel>(quiz);
                    return data;
                }
            }
            return null;
        }

        public Task<bool> UpdateQuiz(QuizModel model, Guid quizId)
        {
            try
            {
                var quiz = _mapper.Map<Quiz>(model);
                quiz.idQuiz = quizId;
                Entities.Update(quiz);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
