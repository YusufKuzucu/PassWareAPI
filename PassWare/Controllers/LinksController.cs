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
    public class FilesController : ControllerBase
    {
        IFilesService _filesService;
        
       
        ILogger<FilesController> _logger;
        public FilesController(IFilesService filesService, ILogger<FilesController> logger)
        {
            _filesService = filesService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFiles()
        {
            var result = await _filesService.GetAllFiles();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByFile")]
        public async Task<IActionResult> GetByFiles(int id)
        {
            var result = await _filesService.GetByFiles(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetFile(int id)
        {

            var result = await _filesService.GetFile(id);
            if (result.Success)
            {
                return File(result.Data, "application/octet-stream"); // Dosya içeriğini byte dizisi olarak döndürüyoruz
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostFile(Files files, string createdBy)
        {
            var result = await _filesService.AddFiles(files, createdBy);
            if (result.Success)
            {
                _logger.LogInformation("Files create process done. Data: {@file}", files);
                return Ok(result);

            }
            _logger.LogError($"Files when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var deleteFile = await _filesService.GetFiles(id);
            var result = await _filesService.DeleteFiles(id);
            if (result.Success)
            {
                _logger.LogInformation("File deleted successfully. Data : {@deletefile}", deleteFile.Data);
                return Ok(result);
            }
            _logger.LogError($"File deleting failed. Erorr : {result.Message}");
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLink(Files files, string updatedBy)
        {
            var result = await _filesService.UpdateFiles(files, updatedBy);
            var updateFile = await _filesService.GetFiles(files.Id);
            if (result.Success)
            {
                _logger.LogInformation("File successfully updated. Data: {@updatelink}", updateFile.Data);
                return Ok(result);
            }
            _logger.LogError($"File updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
    }
}
