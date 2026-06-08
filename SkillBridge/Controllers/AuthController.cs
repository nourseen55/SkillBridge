using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillBridge.Application.Dtos;
using SkillBridge.Application.Interfaces.Services;
using SkillBridge.Application.Validators.Auth;

namespace SkillBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService ) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
           
            var result = await _authService.RegisterAsync(dto);

            return result.IsSuccess
                  ? Ok(result.Data)
                  : BadRequest(new { error = result.ErrorMessage });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {

            var result = await _authService.LoginAsync(dto);

            return result.IsSuccess
                  ? Ok(result.Data)
                  : BadRequest(new { error = result.ErrorMessage });
        }

    }
}
