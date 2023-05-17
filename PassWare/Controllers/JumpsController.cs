using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JumpsController : ControllerBase
    {
        IJumpService _jumpService;
        public JumpsController(IJumpService jumpService)
        {
            _jumpService = jumpService;
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
        [HttpPost("Post")]
        public async Task<IActionResult> PostJump(Jump jump, string createdBy)
        {
            var result = await _jumpService.AddJump(jump, createdBy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateJump(Jump jump, string updatedBy)
        {
            var result = await _jumpService.UpdateJump(jump, updatedBy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteJump(int id)
        {
            var result = await _jumpService.DeleteJump(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCommunication(int id)
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
