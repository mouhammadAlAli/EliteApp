using Microsoft.AspNetCore.Identity;
using MudBlazorWebApp1.Data;
using MudBlazorWebApp1.Data.Entities.Identity;

public static class DataInitializer
{

    public static void SeedLocal(ApplicationDbContext applicationDbContext,
                                  RoleManager<Role> roleManager,
                                  UserManager<User> userManager)
    {
        // Seed roles if not already created
        if (!applicationDbContext.Roles.Any())
        {
            var roles = new List<Role>
            {
                new Role { Name = AppConsts.UserConsts.AdminRole },
                new Role { Name = AppConsts.UserConsts.DoctorRole }
            };

            foreach (var role in roles)
            {
                var result = roleManager.CreateAsync(role).Result;
                if (!result.Succeeded)
                {
                    // Handle errors
                    throw new Exception($"Error creating role {role.Name}");
                }
            }
        }

        if (!applicationDbContext.Users.Any())
        {
            var adminRole = applicationDbContext.Roles.FirstOrDefault(x => x.Name == AppConsts.UserConsts.AdminRole);

            if (adminRole == null)
            {
                throw new Exception($"Role {AppConsts.UserConsts.AdminRole} not found.");
            }

            var users = new List<User>
            {
                new User
                {
                    UserName = AppConsts.UserConsts.AdminEmail,
                    Email = AppConsts.UserConsts.AdminEmail,
                    FirstName = "Admin",
                    LastName = "Admin"
                }
            };

            foreach (var user in users)
            {
                var result = userManager.CreateAsync(user, "1q2w3E*").Result;
                if (!result.Succeeded)
                {
                    throw new Exception($"Error creating user {user.UserName}");
                }

                var roleResult = userManager.AddToRoleAsync(user, adminRole.Name).Result;
                if (!roleResult.Succeeded)
                {
                    throw new Exception($"Error assigning role {adminRole.Name} to user {user.UserName}");
                }
            }
        }
    }
}
