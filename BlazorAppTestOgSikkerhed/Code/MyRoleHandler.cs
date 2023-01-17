using Microsoft.AspNetCore.Identity;

namespace BlazorAppTestOgSikkerhed.Code
{
    public class MyRoleHandler
    {
        public async Task CreateUserRoles(string user, string role, IServiceProvider _serviceProvider)
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            var userRoleCheck = await roleManager.RoleExistsAsync(role);
            if (!userRoleCheck)
                roleResult = await roleManager.CreateAsync(new IdentityRole(role));

            IdentityUser identityUser = await userManager.FindByEmailAsync(user);
            await userManager.AddToRoleAsync(identityUser, role);
        }
    }
}
