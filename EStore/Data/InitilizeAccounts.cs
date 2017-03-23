using EStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data
{
    public static class InitilizeAccounts
    {
        private static readonly List<string[]> Accounts = new List<string[]> {
            new string[]{ "admin@demo", "Demo.1", "Admin" },
            new string[]{ "customer@demo", "Demo.1", "Customer" },
            new string[]{ "seller@demo", "Demo.1", "Seller" },
        };

        public static async Task SeedAccounts(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                foreach (var userData in Accounts)
                {
                    if (userManager.FindByNameAsync(userData[0]) != null)
                    {
                        var user = new ApplicationUser()
                        {
                            UserName = userData[0],
                            Email = userData[0]
                        };

                        var results = await userManager.CreateAsync(user, userData[1]);
                        await userManager.AddToRoleAsync(user, userData[2]);
                    }
                }
            }
        }
    }
}
