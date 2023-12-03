using Microsoft.AspNetCore.Mvc;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Vocabulary;

namespace toiec_web.Controllers
{
    public class VocabularyController : BaseAPIController
    {
        private readonly IVocabularyService _vocabularyService;

        public VocabularyController(IVocabularyService vocabularyService)
        {
            _vocabularyService = vocabularyService;
        }

        [HttpGet]
        [Route("GetAllVocabularies")]
        public async Task<IActionResult> GetAllVocabularies()
        {
            var listVoc = await _vocabularyService.GetAllVocabularies();
            if (listVoc == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(listVoc);
        }

        [HttpGet]
        [Route("GetVocabularyById/{id:guid}")]
        public async Task<IActionResult> GetVocabularyById(Guid id)
        {
            var voc = await _vocabularyService.GetVocabularyById(id);
            if (voc == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(voc);
        }

        [HttpGet]
        [Route("GetVocabularyByTopic/{id:guid}")]
        public async Task<IActionResult> GetAllVocabularyByTopic(Guid id)
        {
            var voc = await _vocabularyService.GetAllVocabularyByTopic(id);
            if (voc == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(voc);
        }

        [HttpPost]
        [Route("AddVocabulary")]
        public async Task<IActionResult> AddVocabulary(VocabularyAddModel model, string userId)
        {
            var response = await _vocabularyService.AddVocabulary(model, userId);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("UpdateVocabulary/{idTopic:guid}&&{idProfessor:guid}")]
        public async Task<IActionResult> UpdateVocabulary(VocabularyUpdateModel model, Guid idTopic, string userId)
        {
            var response = await _vocabularyService.UpdateVocabulary(model, idTopic, userId);
            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("DeleteVocabulary/{id:guid}")]
        public async Task<IActionResult> DeleteVocabulary(Guid id)
        {
            var response = await _vocabularyService.DeleteVocabulary(id);
            if (response == true)
            {
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
