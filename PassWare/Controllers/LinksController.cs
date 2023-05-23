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
    public class LinksController : ControllerBase
    {
        ILinkService _linkService;
        ILogger<LinksController> _logger;
        public LinksController(ILinkService linkService, ILogger<LinksController> logger)
        {
            _linkService = linkService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLink()
        {
            var result=await _linkService.GetAllLink();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetLink(int id)
        {
            var result = await _linkService.GetLink(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostLink(Link link,string createdBy)
        {
            var result = await _linkService.AddLink(link, createdBy);
            if (result.Success)
            {
                _logger.LogInformation("Link create process done. Data: {@link}", link);
                return Ok(result);

            }
            _logger.LogError($"Link when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            var deleteLink = await _linkService.GetLink(id);
            var result = await _linkService.DeleteLink(id);
            if (result.Success)
            {
                _logger.LogInformation("Link deleted successfully. Data : {@deletelink}", deleteLink.Data);
                return Ok(result);
            }
            _logger.LogError($"Link deleting failed. Erorr : {result.Message}");
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLink(Link link,string updatedBy)
        {
            var result = await _linkService.UpdateLink(link, updatedBy);
            var updateLink = await _linkService.GetLink(link.Id);
            if (result.Success)
            {
                _logger.LogInformation("Link successfully updated. Data: {@updatelink}",updateLink.Data);
                return Ok(result);
            }
            _logger.LogError($"Link updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
    }
}
