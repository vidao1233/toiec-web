using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toeic_web.Services;
using toeic_web.Services.IService;

namespace toeic_web.Controllers
{
    public class RecordController : BaseAPIController
    {
        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService) 
        {
            _recordService = recordService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetRecordByUserTest/{userId}&&{testId:guid}")]
        public async Task<IActionResult> GetRecordByUserTest(string userId, Guid testId)
        {
            var record = await _recordService.GetRecordByUserTest(userId, testId);
            if (record == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(record);
        }
        [Authorize]
        [HttpGet]
        [Route("GetRecordByUser/{userId}")]
        public async Task<IActionResult> GetRecordByUser(string userId)
        {
            var record = await _recordService.GetRecordByUser(userId);
            if (record == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(record);
        }
        [HttpGet]
        [Route("GetRecordByID/{recordId:guid}")]
        public async Task<IActionResult> GetRecordByID(Guid recordId)
        {
            var record = await _recordService.GetRecordByID(recordId);
            if (record == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(record);
        }
    }
}
