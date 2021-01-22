using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcViewModels.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Database
{
    public class SeedDatabase
    {
        public static IHost CreateDatabaseIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<IdentityPersonDbContext>();
                    context.Database.Migrate();

                    if (context.Roles.Any() == false)
                    {
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                        roleManager.CreateAsync(new IdentityRole("SuperAdmin")).Wait();
                        roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                        roleManager.CreateAsync(new IdentityRole("Member")).Wait();

                        var userManager = services.GetRequiredService<UserManager<AppUser>>();

                        AppUser superAdmin = new AppUser() { UserName = "SuperAdmin" };

                        userManager.CreateAsync(superAdmin, "!TimLindborg0").Wait();

                        superAdmin = userManager.FindByNameAsync("SuperAdmin").Result;

                        userManager.AddToRoleAsync(superAdmin, "SuperAdmin").Wait();

                    }
                }

                catch (Exception)
                {
                    throw;
                }

                return host;

            }
          
        }
    }
}
