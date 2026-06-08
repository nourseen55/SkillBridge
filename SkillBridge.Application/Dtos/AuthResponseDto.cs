namespace SkillBridge.Application.Dtos;

public record AuthResponseDto(
    string Token,
    string FullName,
    string Email,
    string Role,
    DateTime ExpiresAt
);