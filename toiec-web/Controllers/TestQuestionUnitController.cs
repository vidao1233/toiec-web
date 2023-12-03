using Microsoft.AspNetCore.Mvc;
using toiec_web.Services;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Lesson;
using toiec_web.ViewModels.TestQuestionUnit;

namespace toiec_web.Controllers
{
    public class TestQuestionUnitController : BaseAPIController
    {
        private readonly ITestQuestionUnitService _testQuestionUnitService;
        private readonly IUploadFileService _uploadFileService;

        public TestQuestionUnitController(ITestQuestionUnitService testQuestionUnitService, IUploadFileService uploadFileService)
        {
            _testQuestionUnitService = testQuestionUnitService;
            _uploadFileService = uploadFileService;
        }

        [HttpGet]
        [Route("GetAllTestQuestionUnits")]
        public async Task<IActionResult> GetAllTestQuestionUnits()
        {
            var unitList = await _testQuestionUnitService.GetAllTestQuestionUnits();
            if (unitList == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(unitList);
        }

        [HttpGet]
        [Route("GetTestQuestionUnitById/{id:guid}")]
        public async Task<IActionResult> GetTestQuestionUnitById(Guid id)
        {
            var unit = await _testQuestionUnitService.GetTestQuestionUnitById(id);
            if (unit == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(unit);
        }

        [HttpGet]
        [Route("GetAllTestQuestionUnitByTest/{id:guid}")]
        public async Task<IActionResult> GetAllTestQuestionUnitByTest(Guid id)
        {
            var unit = await _testQuestionUnitService.GetAllTestQuestionUnitByTest(id);
            if (unit == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(unit);
        }

        [HttpGet]
        [Route("GetAllTestQuestionUnitByPart/{id:guid}")]
        public async Task<IActionResult> GetAllTestQuestionUnitByPart(int id)
        {
            var unit = await _testQuestionUnitService.GetAllTestQuestionUnitByPart(id);
            if (unit == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(unit);
        }

        [HttpPost]
        [Route("AddTestQuestionUnit")]
        public async Task<IActionResult> AddTestQuestionUnit([FromForm]TestQuestionUnitMapModel model)
        {            
            var mapModel = new TestQuestionUnitAddModel();
            
            //map data
            //mapModel.idQuestionUnit = model.idQuestionUnit;
            mapModel.idTestPart = model.idTestPart;
            mapModel.paragraph = model.paragraph;
            var audio = await _uploadFileService.AddAudioAsync(model.audio);
            mapModel.audio = audio.Url.ToString();
            var image = await _uploadFileService.AddFileAsync(model.image);
            mapModel.image = image.Url.ToString();
            mapModel.script = model.script;
            mapModel.translation = model.translation;

            var response = await _testQuestionUnitService.AddTestQuestionUnit(mapModel);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("UpdateTestQuestionUnit/{id:guid}")]
        public async Task<IActionResult> UpdateTestQuestionUnit([FromForm] TestQuestionUnitMapModel model, Guid id)
        {
            var mapModel = new TestQuestionUnitUpdateModel();
            //chang file to string
            var audio = await _uploadFileService.AddAudioAsync(model.audio);
            var image = await _uploadFileService.AddFileAsync(model.image);
            //map data
            //mapModel.idQuestionUnit = model.idQuestionUnit;
            mapModel.idTestPart = model.idTestPart;
            mapModel.paragraph = model.paragraph;
            mapModel.audio = audio.Url.ToString();
            mapModel.image = image.Url.ToString();
            mapModel.script = model.script;
            mapModel.translation = model.translation;

            var response = await _testQuestionUnitService.UpdateTestQuestionUnit(mapModel, id);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteTestQuestionUnit/{id:guid}")]
        public async Task<IActionResult> DeleteTestQuestionUnit(Guid id)
        {
            var response = await _testQuestionUnitService.DeleteTestQuestionUnit(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
