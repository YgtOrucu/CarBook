using CarBook.Domain.Entities;
using CarBook.Persistence.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CarBook.Persistence.Seeders;

public static class RoleSeeder
{
    public static async Task SeedRolesAndAdminUserAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var adminSettings = serviceProvider.GetRequiredService<IOptions<AutoCreateAdmin>>().Value;

        var roles = new[] { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new AppRole { Name = role });
            }
        }

        var adminUser = await userManager.FindByEmailAsync(adminSettings.Email);

        if (adminUser == null)
        {
            var newAdmin = new AppUser
            {
                UserName = adminSettings.UserName,
                Email = adminSettings.Email,
                Name = adminSettings.Name,
                Surname = adminSettings.Surname,
                EmailConfirmed = adminSettings.EmailConfirmed,
            };

            var createResult = await userManager.CreateAsync(newAdmin, adminSettings.AdminPassword);

            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
            else
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                throw new Exception($"Admin kullanıcısı oluşturulamadı: {errors}");
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}