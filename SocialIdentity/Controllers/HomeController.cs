using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application Demo APP";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page Hello";

            return View();
        }
    }
}