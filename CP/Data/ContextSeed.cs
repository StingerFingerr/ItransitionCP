using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP.Models;
using CP.Models.Collections;

namespace CP.Data
{
    public static class ContextSeed
    {
        public static async Task SeedSampleCollection(ApplicationDbContext dbContext)
        {
            
            await dbContext.Collections.AddAsync(new CollectionModel
            {
                Name = "col name",
                Descr = "descr descr descr descr descr descr descr descr descr descr descr descr descr descr descr descr ",
                UserID = "2334",
                
            });

            dbContext.SaveChanges();
        }

        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "srfrr",
                Email = "martinovichmain@gmail.com",
                FirstName = "Aleksey",
                LastName = "Martinovich",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user is null)
                {
                    await userManager.CreateAsync(defaultUser, "123Password.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }

            }
        }
    }
}
