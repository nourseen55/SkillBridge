using FluentValidation;
using SkillBridge.Application.Interfaces.Services;
using SkillBridge.Application.Validators.Auth;
using SkillBridge.Infrastructure.Services;

namespace SkillBridge.API.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddValidatorsFromAssemblyContaining<RegisterValidator>();

        return services;
    }
}