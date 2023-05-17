using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIsController : ControllerBase
    {
        IUIService _uıService;
        public UIsController(IUIService uıService)
        {
            _uıService = uıService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUI()
        {
            var result = await _uıService.GetAllUI();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetUI(int id)
        {
            var result=await _uıService.GetUI(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostUI(UI uI,string createdBy)
        {
            var result = await _uıService.AddUI(uI, createdBy);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUI(int id)
        {
            var result = await _uıService.DeleteUI(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUI(UI uI,string updatedBy)
        {
            var result = await _uıService.UpdateUI(uI, updatedBy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
