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

        public ActionResult Login()
        {
            return View();
        }
        
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

             * */
            if ( Session["FacebookID"] == null) 
            {
                return Redirect("./account/login");
            }
            return View();
        }

        public ActionResult About()
        {
            var fb = new FacebookClient();
            try
            {
                dynamic result = fb.Get("oauth/access_token", new
                {
                    client_id = "728589213827172",
                    client_secret = "c9c49f60ec40736a0ff508732d8dbb6e",
                    grant_type = "client_credentials",
                    redirect_uri = "http://vm344b.se.rit.edu/MakeItRain/",
                });

                Session["FacebookAccessToken"] = result.access_token;
                fb.AccessToken = result.access_token;
                result = fb.Get("me?fields=id");
                var id = result.id;
                Session["FacebookID"] = id ;
            }
            catch(Exception e)
            {
               return new HttpStatusCodeResult(500, e.Message); 
            }


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return new HttpStatusCodeResult(500, Session["FacebookAccessToken"].ToString());
        }

    }
}