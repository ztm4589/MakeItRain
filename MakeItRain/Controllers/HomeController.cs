using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Facebook;
using MakeItRain.Models;

namespace MakeItRain.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            
            if ( Session["FacebookID"] == null) 
            {
                return Redirect("~/account/Facebook/");
            }
            
            var client = new FacebookClient(Session["accessToken"].ToString());
            //dynamic result = (IDictionary<string, object>)client.Get("/me?fields=id");
            //String facebookId = (string)result["id"];
            
            // Causes InvalidOperationException
            //db.Users.Add(new User { Id = facebookId });
            
            dynamic result = client.Get("/v1.0/me/friends/", new {limit=10});
            string htmlFriends = "<ul>";
            int count = 0;
             foreach (dynamic friend in result.data  )
            {
                htmlFriends += "<li>";
                htmlFriends += "<div class='pic'>";
                htmlFriends += "<img src='https://graph.facebook.com/" + friend.id + "/picture'/>";
                htmlFriends += "</div>";
                htmlFriends += "<div class='picName'>"+friend.name+"</div>";
                htmlFriends += "</li>";
                count++;
                if (count >= 10)
                {
                    break;
                }
            }
             htmlFriends += "</ul>";
            Session["friends"]=htmlFriends;

            
            result = client.Get("/me/home");
            string htmlFeed = "<ul>";
            foreach(dynamic feed in result.data)
            {
                htmlFeed += "<li>";
                if (feed.message!=null && feed.message!="")
                {
                    htmlFeed += "<div class='statusMessage' id='" + feed.id + "'>" + feed.message + "</div>";
                }
                else
                {
                    htmlFeed += "<div class='statusMessage' id='" + feed.id + "'>" + feed.story + "</div>";
                }
                
                htmlFeed += "</li>";
            }
            htmlFeed+="</ul>";
            htmlFeed += "<script>var pagingLink='"+result.paging.next+"'</script>";
            Session["feed"] = htmlFeed;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}