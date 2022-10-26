using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterApi.BL.Interfaces;
using RegisterApi.Domain.Dtos;

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserAccountsService _userAccountsService;
        private readonly IJWTService _jwtService;

        public AuthController(IUserAccountsService userAccountsService, IJWTService jwtService)
        {
            _userAccountsService = userAccountsService;
            _jwtService = jwtService;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromForm] SingupDto signupDto)
        {

            var success = await _userAccountsService.CreateUserAccountAsync(signupDto);

            return success ? Ok() : BadRequest(new { ErrorMessage = "User already exist" });
        }
        [HttpPost("Login")]
        public async Task<ActionResult> LogIn(LoginDto loginModel)
        {
            var (loginSuccess, role) = await _userAccountsService.LogInAsync(loginModel.UserName, loginModel.Password);
            if (!loginSuccess)
            {
                return BadRequest(new { ErrorMessage = "No such user" });
            }
            return Ok(_jwtService.GetJwtToken(loginModel.UserName, role));
        }
    }
}
