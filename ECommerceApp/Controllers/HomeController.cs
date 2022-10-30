using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "India's most trusted Online Shopping App!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For queries, Please Contact:";

            return View();
        }
    }
}