using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toiec_web.Models;
using toiec_web.Services;
using toiec_web.Services.IService;
using toiec_web.ViewModels.UserAnswer;
using toiec_web.ViewModels.Vocabulary;

namespace toiec_web.Controllers
{
    [Authorize]
    public class UserAnswerController : BaseAPIController
    {
        private readonly IUserAnswerService _userAnswerService;

        public UserAnswerController(IUserAnswerService userAnswerService) 
        {
            _userAnswerService = userAnswerService;
        }

        [HttpPost]
        [Route("AddListUserAnswers/{userId}")]
        public async Task<IActionResult> AddListUserAnswers(IEnumerable<UserAnswerModel> models, string userId, Guid testId)
        {
            var response = await _userAnswerService.AddListUserAnswers(models, userId, testId);
            if (response)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
