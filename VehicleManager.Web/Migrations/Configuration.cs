using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VehicleManager.Web.Models;
using WebGrease.Css.Extensions;
using System.Data.Entity.Migrations;
using System.Linq;

namespace VehicleManager.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VehicleManager.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VehicleManager.Web.Models.ApplicationDbContext context)
        {
            var defaultRoles = new[] {"standard", "administrator"};

            ConfigureRoles(context, defaultRoles);

            ConfigureSuperUser(context, defaultRoles);
        }

        private static void ConfigureSuperUser(ApplicationDbContext context, IEnumerable<string> defaultRoles)
        {
            const string userName = "robert@robert.com";
            if (!(context.Users.Any(user => user.UserName == userName)))
            {
                const string password = "Test@1234";

                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userName,
                    PasswordHash = password,
                    PhoneNumber = "3108183454",
                };

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var res = userManager.Create(user, password);
                if (res.Succeeded)
                {
                    //subscribing the user to all roles
                    defaultRoles.ForEach(role => userManager.AddToRole(user.Id, role));
                }
            }
        }

        private static void ConfigureRoles(ApplicationDbContext context, IEnumerable<string> defaultRoles)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            defaultRoles.ForEach(role =>
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole {Name = role});
                }
            });
        }
    }
}