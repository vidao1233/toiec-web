using Microsoft.AspNetCore.Mvc;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Quiz;

namespace toiec_web.Controllers
{
    public class QuizController : BaseAPIController
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        [Route("GetAllQuizzes")]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizList = await _quizService.GetAllQuizzes();    
            if (quizList == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(quizList);
        }

        [HttpGet]
        [Route("GetQuizById/{id:guid}")]
        public async Task<IActionResult> GetQuizById(Guid id)
        {
            var quiz = await _quizService.GetQuizById(id);
            if (quiz == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(quiz);
        }

        [HttpPost]
        [Route("AddQuiz")]
        public async Task<IActionResult> AddQuiz(QuizAddModel model)
        {
            var response = await _quizService.AddQuiz(model);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("UpdateQuiz/{id:guid}")]
        public async Task<IActionResult> UpdateQuiz(QuizUpdateModel model, Guid id)
        {
            var response = await _quizService.UpdateQuiz(model, id);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteQuiz/{id:guid}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var response = await _quizService.DeleteQuiz(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
