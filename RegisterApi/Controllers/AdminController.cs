using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterApi.BL.Interfaces;

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class AdminController : Controller
    {
        private readonly IRegisterService _registerService;
        public AdminController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpDelete("Delete User")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _registerService.GetUserIdAsync(id);
            if (user == null)
                return BadRequest("No user by id");
            _registerService.DeleteUser(id);
            return Ok("User Deleted");
        }
    }
}
