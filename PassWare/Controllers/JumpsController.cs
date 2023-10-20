using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PassWare.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JumpsController : ControllerBase
    {
        IJumpService _jumpService;
        ILogger<JumpsController> _logger;
        public JumpsController(IJumpService jumpService, ILogger<JumpsController> logger)
        {
            _jumpService = jumpService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllJump()
        {

            var result=await _jumpService.GetAllJump();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByJump")]
        public async Task<IActionResult> GetByJump(int id)
        {

            var result = await _jumpService.GetByJump(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostJump(Jump jump, string createdBy)
        {
            var result = await _jumpService.AddJump(jump, createdBy);
            if (result.Success)
            {
                _logger.LogInformation("Jump create process done. Data: {@jmp}", jump);

                return Ok(result);
            }
            _logger.LogError($"Jump when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateJump(Jump jump, string updatedBy)
        {
            var result = await _jumpService.UpdateJump(jump, updatedBy);
            var updateJump = await _jumpService.GetJump(jump.Id);
            if (result.Success)
            {
                _logger.LogInformation("Jump successfully updated. Data: {@updatejmp}", updateJump.Data);

                return Ok(result);

            }
            _logger.LogError($"Jump updateing failed. Hata: {result.Message}");
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteJump(int id)
        {
            var deleteJump = await _jumpService.GetJump(id);
            var result = await _jumpService.DeleteJump(id);
            if (result.Success)
            {
                _logger.LogInformation("Jump deleted successfully. Data : {@deletejmp}", deleteJump.Data);

                return Ok(result);
            }
            _logger.LogError($"Jump deleting failed. Erorr : {result.Message}");
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetJump(int id)
        {
            var result = await _jumpService.GetJump(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
     
    }
}
