using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrderProcess.Data.Interface;
using OrderProcess.Models;
using WebGrease;

namespace OrderProcess.Data.EntityFramework
{
    public class UserIdentityRepository : IEFUserIdentityRepository
    {
        private readonly ApplicationDbContext _context;

        public UserIdentityRepository() : this(null)
        {
            
        }

        public UserIdentityRepository(ApplicationDbContext context)
        {
            _context = context ?? new ApplicationDbContext();
        }

        public IEnumerable<UserIdentityModel> GetAllUsers()
        {
            List<UserIdentityModel> result = new List<UserIdentityModel>();
            var u = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            foreach (ApplicationUser user in u.Users.ToList())
            {
                UserIdentityModel newUser = new UserIdentityModel();
                newUser.RoleName = u.GetRoles(user.Id).First();
                newUser.UserName = user.UserName;
                newUser.Id = user.Id;
                result.Add(newUser);
            }
            return result;
        }

        public string GetClerk()
        {
            var u = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var role = roleManager.Roles.Single(item => item.Name == "ClerkRole");
            var clerkId = role.Users.First().UserId;

            return (clerkId);
        }
    }
}