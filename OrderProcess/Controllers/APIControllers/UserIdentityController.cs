using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using OrderProcess.Data.EntityFramework;
using OrderProcess.Data.Interface;
using OrderProcess.Models;

namespace OrderProcess.Controllers.APIControllers
{
    public class UserIdentityController : ApiController
    {
        private readonly IEFUserIdentityRepository UserIdentityRepository;

        public UserIdentityController(IEFUserIdentityRepository uir)
        {
            UserIdentityRepository = uir;
        }

        // GET: api/UserIdentity
        public IHttpActionResult Get()
        {
            IEnumerable<UserIdentityModel> users = new List<UserIdentityModel>();

            users = UserIdentityRepository.GetAllUsers();

            return Ok(users.ToList());
        }
    }
}
