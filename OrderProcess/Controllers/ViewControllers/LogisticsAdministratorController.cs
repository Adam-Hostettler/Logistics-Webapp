using System.Web.Mvc;

namespace OrderProcess.Controllers.ViewControllers
{
    public class LogisticsAdministratorController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}