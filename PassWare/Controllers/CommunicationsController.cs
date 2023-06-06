using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PassWare.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        private ICommunicationService _communicationService;
        private ILogger<CommunicationsController> _logger;
        public CommunicationsController(ICommunicationService communicationService, ILogger<CommunicationsController> logger)
        {
            _communicationService = communicationService;
            _logger = logger;
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
        [HttpGet("GetByCommunication")]
        public async Task<IActionResult> GetByCommunication(int id)
        {
            var result = await _communicationService.GetByCommunication(id);
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
                _logger.LogInformation("Communication create process done. Data: {@commn}", communication);
                return Ok(result);
            }
            _logger.LogError($"Communication when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> PutCommunication(Communication communication, string updatedBy)
        {
            var result = await _communicationService.UpdateCommunication(communication, updatedBy);
            var UpdateCommunication = await _communicationService.GetCommunication(communication.Id);
            if (result.Success)
            {
                _logger.LogInformation("Communication successfully updated. Data: {@updatecommun}", UpdateCommunication.Data);
                return Ok(result);
            }
            _logger.LogError($"Communication updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCommunication(int id)
        {
            var deleteCommunication =await _communicationService.GetCommunication(id);

            var result = await _communicationService.DeleteCommunication(id);
            if (result.Success)
            {
                _logger.LogInformation("Communication deleted successfully. Data : {@deletecommun}", deleteCommunication.Data);
                return Ok(result);
            }
            _logger.LogError($"Communication deleting failed. Erorr : {result.Message}");
            return BadRequest(result);
        }
    }
}
