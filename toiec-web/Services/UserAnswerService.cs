﻿using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Record;
using toiec_web.ViewModels.UserAnswer;

namespace toiec_web.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IMapper _mapper;

        public UserAnswerService(IUserAnswerRepository userAnswerRepository, IMapper mapper) 
        {
            _userAnswerRepository = userAnswerRepository;
            _mapper = mapper;
        }

        public async Task<UserAnswerResponseModel> AddListUserAnswers(IEnumerable<UserAnswerModel> models, string userId, Guid testId)
        { 
            return await _userAnswerRepository.AddListUserAnswers(models, userId, testId);
        }

        public async Task<bool> AddUserAnswer(UserAnswerAddModel model, string userId)
        {
            var data = _mapper.Map<UserAnswerModel>(model);
            return await _userAnswerRepository.AddUserAnswer(data, userId);
        }

        public async Task<IEnumerable<UserAnswerViewModel>> GetUserAnswerByRecord(Guid recordId)
        {
            var listData = await _userAnswerRepository.GetUserAnswerByRecord(recordId);
            var listAnswer = new List<UserAnswerViewModel>();
            foreach(var model in listData)
            {
                var obj = _mapper.Map<UserAnswerViewModel>(model);
                listAnswer.Add(obj);
            }
            return listAnswer;
        }
    }
}
