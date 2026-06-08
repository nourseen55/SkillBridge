using SkillBridge.Application.Dtos;
using SkillBridge.Application.ReturnObject;

namespace SkillBridge.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto);
        Task<Result<AuthResponseDto>> LoginAsync(LoginDto dto);
    }
}
