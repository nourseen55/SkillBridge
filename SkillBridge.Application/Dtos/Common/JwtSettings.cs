namespace SkillBridge.Application.Dtos.Common
{
    public class JwtSettings
    {
        public string Key { get; init; } = default!;
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public int ExpiryInDays { get; init; }
    }
}
