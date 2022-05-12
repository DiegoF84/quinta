using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quinta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicación AFA";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacte a los desarrolladores de esta página";

            return View();
        }
    }
}