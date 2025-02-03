using SharedLibrary.DTOs.Users;
using KanesKitchenServer.Interfaces;
using SharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagmentController : ControllerBase
    {

        private readonly IUserManagment _UserManagment;
        
        public UserManagmentController(IUserManagment userManagment) {
            _UserManagment = userManagment;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _UserManagment.RegisterAsync(registerDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _UserManagment.LoginAsync(loginDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("loginViaRefreshToken")]
        public async Task<IActionResult> LoginViaRefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var response = await _UserManagment.LoginViaRefreshTokenAsync(refreshTokenDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
