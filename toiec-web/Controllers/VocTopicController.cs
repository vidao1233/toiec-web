using Microsoft.AspNetCore.Mvc;
using toiec_web.Services.IService;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Controllers
{
    public class VocTopicController : BaseAPIController
    {
        private readonly IVocTopicService _vocTopicService;

        public VocTopicController(IVocTopicService vocTopicService) 
        {
            _vocTopicService = vocTopicService;
        }

        [HttpGet]
        [Route("GetAllVocTopic")]
        public async Task<IActionResult> GetAllVocTopic()
        {
            var listTopic = await _vocTopicService.GetAllVocTopics();
            if (listTopic == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(listTopic);
        }

        [HttpGet]
        [Route("GetVocTopicById/{id:guid}")]
        public async Task<IActionResult> GetVocTopicById(Guid id)
        {
            var topic = await _vocTopicService.GetVocTopicById(id);
            if (topic == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(topic);
        }

        [HttpPost]
        [Route("AddVocTopic")]
        public async Task<IActionResult> AddVocTopic(VocTopicAddModel model)
        {
            var response = await _vocTopicService.AddVocTopic(model);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("UpdateVocTopic/{idTopic:guid}&&{idProfessor:guid}")]
        public async Task<IActionResult> UpdateVocTopic(VocTopicUpdateModel model, Guid idTopic, Guid idProfessor)
        {
            var response = await _vocTopicService.UpdateVocTopic(model, idTopic, idProfessor);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteVocTopic/{id:guid}")]
        public async Task<IActionResult> DeleteVocTopic(Guid id)
        {
            var response = await _vocTopicService.DeleteVocTopic(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
