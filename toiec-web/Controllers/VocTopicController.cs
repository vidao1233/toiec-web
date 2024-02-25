using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toeic_web.Services.IService;
using toeic_web.ViewModels.VocTopic;

namespace toeic_web.Controllers
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

        [Authorize(Roles = "Professor")]
        [HttpPost]
        [Route("AddVocTopic")]
        public async Task<IActionResult> AddVocTopic(VocTopicAddModel model, string userId)
        {
            var response = await _vocTopicService.AddVocTopic(model, userId);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize(Roles = "Professor")]
        [HttpPut]
        [Route("UpdateVocTopic/{idTopic:guid}&&{userId}")]
        public async Task<IActionResult> UpdateVocTopic(VocTopicUpdateModel model, Guid idTopic, string userId)
        {
            var response = await _vocTopicService.UpdateVocTopic(model, idTopic, userId);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize(Roles = "Professor")]
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
