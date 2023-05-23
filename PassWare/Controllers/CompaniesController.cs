using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PassWare.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyService _companyService;
        ILogger<CompaniesController> _logger;
        public CompaniesController(ICompanyService companyService, ILogger<CompaniesController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompany()
        {
            var result = await _companyService.GetAllCompany();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await _companyService.GetCompany(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostCompany(Company company)
        {
            var result = await _companyService.AddCompany(company);

            if (result.Success)
            {
                _logger.LogInformation("Company create process done. Data: {@cmp}", company);

                return Ok(result);
            }
            _logger.LogError($"Company when creating failed. Error : {result.Message}");

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var deleteCompany = await _companyService.GetCompany(id);


            var result = await _companyService.DeleteCompany(id);
            if (result.Success)
            {
                _logger.LogInformation("Company deleted successfully. Data : {@deletecmp}", deleteCompany.Data);
                return Ok(result);
            }
            _logger.LogError($"Company deleting failed. Erorr : {result.Message}");

            return BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            var result = await _companyService.UpdateCompany(company);
            var Updatecompany = await _companyService.GetCompany(company.Id);
            if (result.Success)
            {
                _logger.LogInformation("Company successfully updated. Data: {@updatecmp}",Updatecompany.Data);
                return Ok(result);
            }

            _logger.LogError($"Company updateing failed. Hata: {result.Message}");

            return BadRequest(result);
        }

    }
}
