using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Facebook;

namespace MakeItRain.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            /*
            var fb = new FacebookClient();
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = "728589213827172",
                client_secret = "c9c49f60ec40736a0ff508732d8dbb6e",
                grant_type = "client_credentials"
            });

            if (result == null || result.client_id != null) 
            {
                return Redirect("./account/login");
            }
             * */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var fb = new FacebookClient();
            dynamic result = fb.Get("dialog/oauth", new
            {
                client_id = "728589213827172",
                client_secret = "c9c49f60ec40736a0ff508732d8dbb6e",
                redirect_uri = "http://vm344b.se.rit.edu/MakeItRain/"
            });


            //Session["FacebookID"] = result;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}