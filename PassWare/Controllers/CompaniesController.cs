using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService=companyService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompany()
        {
            var result = _companyService.GetAllCompany();
            if (result.IsCompleted)
            {
                return Ok(result);
            }
            return BadRequest(result);
         
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCompany(int id)
        {
            await _companyService.GetCompany(id);
            return Ok();
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostCompany(Company company)
        {
            await _companyService.AddCompany(company);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompany(id);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            await _companyService.UpdateCompany(company);

            return Ok();
        }

    }
}
