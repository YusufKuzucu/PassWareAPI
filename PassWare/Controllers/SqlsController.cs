using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlsController : ControllerBase
    {
        ISqlService _sqlService;
        public SqlsController(ISqlService ISqlService)
        {
            _sqlService = ISqlService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSql()
        {
            var result=await _sqlService.GetAllSql();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetSql(int id)
        {
            var result=await _sqlService.GetSql(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostSql(Sql sql)
        {
            var result = await _sqlService.AddSql (sql);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSql(int id)
        {
            var result = await _sqlService.DeleteSql(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSql(Sql sql)
        {
            var result = await _sqlService.AddSql(sql);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
