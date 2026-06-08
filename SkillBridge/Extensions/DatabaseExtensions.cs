using System.Data;
using Microsoft.AspNetCore.Identity;
using SkillBridge.Domain.Enums;

namespace SkillBridge.API.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task SeedRolesAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var role in Enum.GetNames<eUserRole>())
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
            }
        }

    }
}
