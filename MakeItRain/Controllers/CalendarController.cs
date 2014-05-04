using MakeItRain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeItRain.Controllers
{
    public class CalendarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Backend/
        /*public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }*/
    }
}