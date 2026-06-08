namespace SkillBridge.Application.Dtos;

public record RegisterDto(
    string FullName,
    string Email,
    string Password,
    string Role
);