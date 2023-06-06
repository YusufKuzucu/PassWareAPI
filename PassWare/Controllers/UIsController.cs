using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PassWare.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UIsController : ControllerBase
    {
        IUIService _uıService;
        ILogger<UIsController> _logger;
        public UIsController(IUIService uıService, ILogger<UIsController> logger)
        {
            _uıService = uıService;
            _logger = logger;
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
        [HttpGet("GetByUI")]
        public async Task<IActionResult> GetByUI(int id)
        {
            var result = await _uıService.GetByUI(id);
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
                _logger.LogInformation("UI create process done. Data: {@UI}", uI);
                return Ok(result);

            }
            _logger.LogError($"UI when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUI(int id)
        {
            var deleteUI = await _uıService.GetUI(id);
            var result = await _uıService.DeleteUI(id);
            if (result.Success)
            {
                _logger.LogInformation("UI deleted successfully. Data : {@deleteUI}", deleteUI.Data);
                return Ok(result);
            }
            _logger.LogError($"UI deleting failed. Erorr : {result.Message}");
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUI(UI uI,string updatedBy)
        {
            var result = await _uıService.UpdateUI(uI, updatedBy);
            var updateUI = await _uıService.GetUI(uI.Id);
            if (result.Success)
            {
                _logger.LogInformation("UI successfully updated. Data: {@updateUI}",updateUI.Data);
                return Ok(result);
            }
            _logger.LogError($"UI updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
    }
}
