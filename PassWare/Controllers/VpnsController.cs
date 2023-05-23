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
    public class VpnsController : ControllerBase
    {
        IVpnService _vpnService;
        ILogger<VpnsController> _logger;
        public VpnsController(IVpnService vpnService, ILogger<VpnsController> logger)
        {
            _vpnService = vpnService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllVpn()
        {
            var result = await _vpnService.GetAllVpn();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetVpn(int id)
        {
            var result = await _vpnService.GetVpn(id);
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
                _logger.LogInformation("Vpn create process done. Data: {@cmp}", vpn);
                return Ok(result);

            }
            _logger.LogError($"Vpn when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteVpn(int id)
        {
            var deleteVpn = await _vpnService.GetVpn(id);
            var result = await _vpnService.DeleteVpn(id);
            if (result.Success)
            {
                _logger.LogInformation("Vpn deleted successfully. Old Data : {@deletevpn}", deleteVpn.Data);
                return Ok(result);
            }
            _logger.LogError($"Vpn deleting failed. Erorr : {result.Message}");

            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateVpn(Vpn vpn, string updatedBy)
        {
            var result = await _vpnService.UpdateVpn(vpn, updatedBy);
            var updateVpn = await _vpnService.GetVpn(vpn.Id);
            if (result.Success)
            {
                _logger.LogInformation("Vpn successfully updated. Data: {@updatevpn}", updateVpn.Data);
                return Ok(result);
            }
            _logger.LogError($"Vpn updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
    }
}
