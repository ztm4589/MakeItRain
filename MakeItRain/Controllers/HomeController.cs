using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MakeItRain.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            HttpCookie facebookCookie = new HttpCookie("http://vm344b.se.rit.edu/");
            facebookCookie = Request.Cookies["c_user"];


            if (facebookCookie == null) 
            {
                return Redirect("./account/login");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}