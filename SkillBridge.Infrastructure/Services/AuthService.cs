namespace SkillBridge.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto)
    {
        // 1. تأكد إن الإيميل مش موجود
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existingUser is not null)
            return Result<AuthResponseDto>.Failure("Email already registered.");

        // 2. تأكد إن الـ Role صحيح وموجود في الـ DB
        var roleExists = await _roleManager.RoleExistsAsync(dto.Role);
        if (!roleExists)
            return Result<AuthResponseDto>.Failure("Invalid role.");

        // 3. إنشاء الـ User
        var user = new AppUser
        {
            FullName = dto.FullName.Trim(),
            Email = dto.Email.ToLower().Trim(),
            UserName = dto.Email.ToLower().Trim()
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return Result<AuthResponseDto>.Failure(errors);
        }

        // 4. ضيف الـ Role
        await _userManager.AddToRoleAsync(user, dto.Role);

        // 5. ولّد الـ Token
        var (token, expiresAt) = await GenerateTokenAsync(user);

        return Result<AuthResponseDto>.Success("User created successfully",
                                               "201",
            new AuthResponseDto(token, user.FullName, user.Email!, dto.Role, expiresAt)
          );
    }

    public async Task<Result<AuthResponseDto>> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            return Result<AuthResponseDto>.Failure("Invalid email or password.");

        var isValid = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!isValid)
            return Result<AuthResponseDto>.Failure("Invalid email or password.");

        var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresAt) = await GenerateTokenAsync(user);

        return Result<AuthResponseDto>.Success(
            new AuthResponseDto(token, user.FullName, user.Email!, roles.FirstOrDefault() ?? "", expiresAt));
    }

    private async Task<(string token, DateTime expiresAt)> GenerateTokenAsync(AppUser user)
    {
        var expiresAt = DateTime.UtcNow.AddDays(_jwtSettings.ExpiryInDays);

        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault();

        var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, user.Id),
        new(ClaimTypes.Email, user.Email!),
        new(ClaimTypes.Name, user.FullName),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        // 🟣 1. Add Role claim
        if (role is not null)
            claims.Add(new Claim(ClaimTypes.Role, role));

        // 🟣 2. Get permissions from role (SYSTEM CONTROLLED)
        var permissions = RolePermissions.GetPermissions(role ?? "");

        // 🟣 3. Add permissions as claims
        claims.AddRange(
            permissions.Select(p => new Claim("Permission", p))
        );

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: creds
        );

        return (
            new JwtSecurityTokenHandler().WriteToken(token),
            expiresAt
        );
    }

}