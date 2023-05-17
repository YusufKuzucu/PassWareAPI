using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        ILinkService _linkService;
        public LinksController(ILinkService linkService)
        {
            _linkService = linkService;
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
        public async Task<IActionResult> PostLink(Link link)
        {
            var result = await _linkService.AddLink(link);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            var result = await _linkService.DeleteLink(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLink(Link link)
        {
            var result = await _linkService.UpdateLink(link);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
