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
           var result= await _companyService.GetCompany(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostCompany(Company company)
        {
            var result=await _companyService.AddCompany(company);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result=await _companyService.DeleteCompany(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            var result=await _companyService.UpdateCompany(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

    }
}
