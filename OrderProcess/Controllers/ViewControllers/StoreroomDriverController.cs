using System.Web.Mvc;

namespace OrderProcess.Controllers.ViewControllers
{
    public class StoreroomDriverController : Controller
    {
        [Authorize(Roles = "StoreroomDriverRole")]
        public ActionResult Index()
        {
            return View();
        }
    }
}