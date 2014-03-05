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
            var client = new Facebook.FacebookClient();


            if (client == null)  //This needs to check if the user is "logged in"
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