using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                _logger.LogInformation("Login process OK. Data : {@resData}", result.Data);
                return Ok(result.Data);
            }

            _logger.LogError($"Login process NOT OK. Data : {result.Message}");
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                _logger.LogInformation("Register process Ok. Data :{@resData} ", result.Data);
                return Ok(result.Data);
            }
            _logger.LogError($"Register process NOT OK. Data : {result.Message}");
            return BadRequest(result.Message);
        }
        [HttpPost("forgotmypassword")]
        public ActionResult ForgotMyPassword(string email)
        {
            var result = _authService.ForgotMyPassword(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(ResetPassword resetPassword)
        {
            var result = _authService.ResetPassword(resetPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
