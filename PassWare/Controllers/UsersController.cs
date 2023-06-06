using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;       
        }
        [HttpGet("claims")]
        public IActionResult GetUserClaims(string email)
        {
            User user = _userService.GetUserByMail(email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            List<OperationClaim> userClaims = _userService.GetClaims(user);
            return Ok(userClaims);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyidemail")]
        public IActionResult GetByIdEmail(string email)
        {
            var result = _userService.GetUserByIdEmail(email);
            if (result.Success)
            {
                var userDto = result.Data; 

                
                return Ok(userDto);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetUserDtoById(id);
            if (result.Success)
            {
                var userDto = result.Data;


                return Ok(userDto);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var result = _userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserDto user)
        {
            var result = _userService.UpdateByDto(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
