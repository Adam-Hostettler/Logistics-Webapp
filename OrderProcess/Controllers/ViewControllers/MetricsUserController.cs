using System.Web.Mvc;

namespace OrderProcess.Controllers.ViewControllers
{
    public class MetricsUserController : Controller
    {
        [Authorize(Roles = "MetricsRole")]
        public ActionResult Index()
        {
            return View();
        }
    }
}