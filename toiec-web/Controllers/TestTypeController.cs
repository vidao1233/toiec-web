using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toiec_web.Services;
using toiec_web.Services.IService;
using toiec_web.ViewModels.TestType;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Controllers
{
    public class TestTypeController : BaseAPIController
    {
        private readonly ITestTypeService _testTypeService;

        public TestTypeController(ITestTypeService testTypeService)
        {
            _testTypeService = testTypeService;
        }

        [HttpGet]
        [Route("GetAllTestTypes")]
        public async Task<IActionResult> GetAllTestTypes()
        {
            var listType = await _testTypeService.GetAllTestTypes();
            if (listType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(listType);
        }

        [HttpGet]
        [Route("GetTestTypeById/{id:guid}")]
        public async Task<IActionResult> GetTestTypeById(Guid id)
        {
            var type = await _testTypeService.GetTestTypeById(id);
            if (type == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(type);
        }

        [Authorize(Roles = "Professor")]
        [HttpPost]
        [Route("AddTestType")]
        public async Task<IActionResult> AddTestType(TestTypeAddModel model)
        {
            var response = await _testTypeService.AddTestType(model);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize(Roles = "Professor")]
        [HttpPut]
        [Route("UpdateTestType/{id:guid}")]
        public async Task<IActionResult> UpdateTestType(TestTypeUpdateModel model, Guid id)
        {
            var response = await _testTypeService.UpdateTestType(model, id);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize(Roles = "Professor")]
        [HttpDelete]
        [Route("DeleteTestType/{id:guid}")]
        public async Task<IActionResult> DeleteTestType(Guid id)
        {
            var response = await _testTypeService.DeleteTestType(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
