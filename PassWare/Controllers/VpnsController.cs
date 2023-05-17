using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VpnsController : ControllerBase
    {
        IVpnService _vpnService;
        public VpnsController(IVpnService vpnService)
        {
            _vpnService = vpnService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllVpn()
        {
            var result=await _vpnService.GetAllVpn();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetVpn(int id)
        {
            var result=await _vpnService.GetVpn(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostVpn(Vpn vpn, string createdBy)
        {
            var result = await _vpnService.AddVpn(vpn, createdBy);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _vpnService.DeleteVpn(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateVpn(Vpn vpn, string updatedBy)
        {
            var result = await _vpnService.UpdateVpn(vpn, updatedBy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
