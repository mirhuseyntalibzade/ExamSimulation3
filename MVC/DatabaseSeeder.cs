using CORE.Models;
using DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public static class DatabaseSeeder
    {
        public static async Task SeedData(IServiceScope scope)
        {
            IServiceProvider provider = scope.ServiceProvider;
            var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var db = provider.GetRequiredService<AppDbContext>();

            string[] roles = ["Admin", "User"];

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string username = "admin";
            string email = "admin@gmail.com";


            if (await userManager.FindByEmailAsync(email) is null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true,
                };
                IdentityResult result = await userManager.CreateAsync(user, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            db.Database.Migrate();
        }
    }
}
