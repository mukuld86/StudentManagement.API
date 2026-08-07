using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInRequest request)
        {
            var user = await _userService.LoginAsync(request);
            if(user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok("Login Successful");
        }
    }
}
