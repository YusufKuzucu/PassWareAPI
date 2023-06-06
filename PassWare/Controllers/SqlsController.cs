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
    public class SqlsController : ControllerBase
    {
        ISqlService _sqlService;
        ILogger<SqlsController> _logger;
        public SqlsController(ISqlService ISqlService, ILogger<SqlsController> logger)
        {
            _sqlService = ISqlService;
            _logger = logger;
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
        [HttpGet("GetBySql")]
        public async Task<IActionResult> GetAllSql(int id)
        {
            var result = await _sqlService.GetBySql(id);
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
        public async Task<IActionResult> PostSql(Sql sql,string createdBy)
        {
            var result = await _sqlService.AddSql(sql, createdBy);
            if (result.Success)
            {
                _logger.LogInformation("Sql create process done. Data: {@sql}", sql);
                return Ok(result);

            }
            _logger.LogError($"Sql when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSql(int id)
        {
            var deleteSql = await _sqlService.GetSql(id);
            var result = await _sqlService.DeleteSql(id);
            if (result.Success)
            {
                _logger.LogInformation("Sql deleted successfully. Data : {@deletesql}", deleteSql.Data);
                return Ok(result);
            }
            _logger.LogError($"Sql deleting failed. Erorr : {result.Message}");
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSql(Sql sql,string updatedBy)
        {
            var result = await _sqlService.UpdateSql(sql, updatedBy);
            var updateSql = await _sqlService.GetSql(sql.Id);
            if (result.Success)
            {
                _logger.LogInformation("Sql successfully updated. Data: {@updatesql}", updateSql.Data);
                return Ok(result);
            }
            _logger.LogError($"Sql updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
    }
}
