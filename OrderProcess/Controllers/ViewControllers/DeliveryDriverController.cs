using System.Web.Mvc;

namespace OrderProcess.Controllers.ViewControllers
{
    public class DeliveryDriverController : Controller
    {
        [Authorize(Roles = "DeliveryDriverRole")]
        public ActionResult Index()
        {
            return View();
        }
    }
}