using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2Token.Data
{
    public class SeedDatabase
    { public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "andre@azuris.com.br",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Andre"
                };
                userManager.CreateAsync(user, "password@123");
            }
        }
    }
}
