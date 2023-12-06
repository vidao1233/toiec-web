using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Lesson;

namespace toiec_web.Controllers
{
    public class LessonController : BaseAPIController
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("GetAllLessons")]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessonList = await _lessonService.GetAllLessons();
            if (lessonList == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(lessonList);
        }
        
        [HttpGet]
        [Route("GetLessonById/{id:guid}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var lesson = await _lessonService.GetLessonById(id);
            if (lesson == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(lesson);
        }

        [HttpGet]
        [Route("GetAllLessonByCourse/{id:guid}")]
        public async Task<IActionResult> GetAllLessonByCourse(Guid id)
        {
            var lesson = await _lessonService.GetAllLessonByCourse(id);
            if (lesson == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(lesson);
        }

        [Authorize(Roles = "Professor")]
        [HttpPost]
        [Route("AddLesson")]
        public async Task<IActionResult> AddLesson(LessonAddModel model)
        {
            var response = await _lessonService.AddLesson(model);
            if(response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize(Roles = "Professor")]
        [HttpPut]
        [Route("UpdateLesson/{id:guid}")]
        public async Task<IActionResult> UpdateLesson([FromBody] LessonUpdateModel model, Guid id)
        {
            var response = await _lessonService.UpdateLesson(model, id);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize(Roles = "Professor")]
        [HttpDelete]
        [Route("DeleteLesson/{id:guid}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            var response = await _lessonService.DeleteLesson(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
