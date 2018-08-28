using System.Web.Mvc;

namespace OrderProcess.Controllers.ViewControllers
{
    public class ClerkController : Controller
    {
        [Authorize(Roles = "ClerkRole")]
        public ActionResult Index()
        {
            ViewBag.Title = "Clerk Page";

            return View();
        }
    }
}