﻿using System;
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
            db.Users.Add(new User() { Id = Session["accessToken"].ToString() });
            var client = new FacebookClient(Session["accessToken"].ToString());
            dynamic result = client.Get("/me/friends");
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