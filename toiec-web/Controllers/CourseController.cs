using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Course;

namespace toiec_web.Controllers
{
    public class CourseController : BaseAPIController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService; 
        }
        //[Authorize]
        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courseList = await _courseService.GetAllCourses();
            if (courseList == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(courseList);
        }

        [HttpGet]
        [Route("GetCourseById/{id:guid}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(course);
        }

        [HttpPost]
        [Route("AddCourse")]
        public async Task<IActionResult> AddCourse(CourseAddModel model)
        {
            var response = await _courseService.AddCourse(model);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("UpdateCourse/{id:guid}")]
        public async Task<IActionResult> UpdateCourse([FromBody]CourseUpdateModel model, Guid id)
        {
            var response = await _courseService.UpdateCourse(model, id);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteCourse/{id:guid}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var response = await _courseService.DeleteCourse(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
