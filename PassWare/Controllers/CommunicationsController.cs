using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        ICommunicationService _communicationService;
        public CommunicationsController(ICommunicationService communicationService)
        {
            _communicationService= communicationService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCommunication()
        {
            var result = await _communicationService.GetAllCommunication();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCommunication(int id)
        {
            var result = await _communicationService.GetCommunication(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostCommunication(Communication communication,string createdBy)
        {
            var result = await _communicationService.AddCommunication(communication, createdBy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> PutCommunication(Communication communication, string updatedBy)
        {
            var result = await _communicationService.UpdateCommunication(communication, updatedBy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCommunication(int id)
        {
            var result = await _communicationService.DeleteCommunication(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
