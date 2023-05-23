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
    public class ProjectsController : ControllerBase
    {
        IProjectService _projectService;
        ILogger<ProjectsController> _logger;    
        public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProject()
        {
            var result=await _projectService.GetAllProject();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetProject(int id)
        {
            var result=await _projectService.GetProject(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostProject(Project project,string createdBy)
        {
            var result = await _projectService.AddProject(project, createdBy);
            if (result.Success)
            {
                _logger.LogInformation("Project create process done. Data: {@project}", project);
                return Ok(result);

            }
            _logger.LogError($"Project when creating failed. Error : {result.Message}");
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleteProject = await _projectService.GetProject(id);
            var result = await _projectService.DeleteProject(id);
            if (result.Success)
            {
                _logger.LogInformation("Project deleted successfully. Data : {@deleteproject}", deleteProject.Data);
                return Ok(result);
            }
            _logger.LogError($"Project deleting failed. Erorr : {result.Message}");
            return BadRequest(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProject(Project project,string updatedBy)
        {
            var result = await _projectService.UpdateProject(project, updatedBy);
            var updateProject = await _projectService.GetProject(project.Id);
            if (result.Success)
            {
                _logger.LogInformation("Project successfully updated. Data: {@updateproject}",updateProject.Data);
                return Ok(result);
            }
            _logger.LogError($"Project updateing failed. Hata: {result.Message}");
            return BadRequest(result);

        }
    }
}
