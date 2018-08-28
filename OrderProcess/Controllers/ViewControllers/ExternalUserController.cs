using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderProcess.Controllers.ViewControllers
{
    public class ExternalUserController : Controller
    {
        [Authorize(Roles = "ExternalRole")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}