using HikingInformationSystemDomain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HikingInforamtionSystemCore.Seeders;

public class AuthDbSeeder
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthDbSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        await AddDefaultRoles();
        await AddAdminUser();
    }

    private async Task AddAdminUser()
    {
        var newAdminUser = new User()
        {
            Email = "admin@x.com",
            UserName = "admin@x.com"
        };

        var existingAdminUser = await _userManager.FindByEmailAsync(newAdminUser.Email);
        if (existingAdminUser == null)
        {
            var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "VerySafePassword1!");
            if (createAdminUserResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }
        }
    }

    private async Task AddDefaultRoles()
    {
        foreach (var role in UserRoles.All)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
                await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}