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
            await _communicationService.GetAllCommunication();
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCommunication(int id)
        {
            await _communicationService.GetCommunication(id);
            return Ok();
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostCommunication(Communication communication)
        {
            await _communicationService.AddCommunication(communication);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> PutCommunication(Communication communication)
        {
            await _communicationService.UpdateCommunication(communication);
            return Ok();

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCommunication(int id)
        {
            await _communicationService.DeleteCommunication(id);
            return Ok();
        }
    }
}
