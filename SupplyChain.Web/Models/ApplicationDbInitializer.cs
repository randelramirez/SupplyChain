using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace SupplyChain.Web.Models
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                // *** INITIALIZE WITH CUSTOM APPLICATION ROLE CLASS:
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.CreateAsync(role);
            }

            var user = userManager.FindByNameAsync(name).Result;
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.CreateAsync(user, password);
                result = userManager.SetLockoutEnabledAsync(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRolesAsync(user.Id).Result;
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRoleAsync(user.Id, role.Name);
            }
        }
    }
}