using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OrderProcess;
using OrderProcess.Models;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OrderProcess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          //CreateRolesandUsers();
        }
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
 
   
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("ClerkRole"))
            {
                var role = new IdentityRole();
                role.Name = "ClerkRole";
                roleManager.Create(role);
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("MetricsRole"))
            {
                var role = new IdentityRole();
                role.Name = "MetricsRole";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("ExternalRole"))
            {
                var role = new IdentityRole();
                role.Name = "ExternalRole";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("DeliveryDriverRole"))
            {
                var role = new IdentityRole();
                role.Name = "DeliveryDriverRole";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("StoreroomDriverRole"))
            {
                var role = new IdentityRole();
                role.Name = "StoreroomDriverRole";
                roleManager.Create(role);
            }

        }
    }
}
