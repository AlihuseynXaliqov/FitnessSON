using System.Reflection;
using System.Text;
using FitnessApp.Core;
using FitnessApp.Core.User;
using FitnessApp.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FitnessApp.API;

public static class RegisterProgramAPI
{
    public static void UseSeedData(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            CreateRoles(roleManager).Wait();
            CreateAdmin(userManager, configuration).Wait();
        }
    }

    private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
    {
        int res = await roleManager.Roles.CountAsync();

        if (res == 0)
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                await roleManager.CreateAsync(new IdentityRole(role.ToString()!));
            }
        }
    }

    private static async Task CreateAdmin(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        var adminSettings = configuration.GetSection("AdminSettings");

        var adminUsername = adminSettings["Username"];
        var adminFirstName = adminSettings["FirstName"];
        var adminLastName = adminSettings["LastName"];
        var adminEmail = adminSettings["Email"];
        var adminPassword = adminSettings["Password"];

        if (!await userManager.Users.AnyAsync(x => x.UserName == adminUsername))
        {
            AppUser user = new AppUser
            {
                UserName = adminUsername,
                FirstName = adminFirstName!,
                LastName = adminLastName!,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, adminPassword!);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}