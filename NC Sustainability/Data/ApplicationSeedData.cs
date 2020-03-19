using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Data
{
    public static class ApplicationSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Create Roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Subscriber" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Create Users
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager.FindByEmailAsync("admin1@ncstudents.niagaracollege.ca").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin1@ncstudents.niagaracollege.ca",
                    Email = "admin1@ncstudents.niagaracollege.ca"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            //Create Users
            if (userManager.FindByEmailAsync("subscriber1@ncstudents.niagaracollege.ca").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "subscriber1@ncstudents.niagaracollege.ca",
                    Email = "subscriber1@ncstudents.niagaracollege.ca"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Subscriber").Wait();
                }
            }
            if (userManager.FindByEmailAsync("user1@ncstudents.niagaracollege.ca").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user1@ncstudents.niagaracollege.ca",
                    Email = "user1@ncstudents.niagaracollege.ca"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;
                //Not in any role
            }
        }
    }
}
