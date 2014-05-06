using MakeItRain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Data;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using DayPilot.Web.Mvc.Events.Common;
using DayPilot.Web.Mvc.Events.Navigator;
using DayPilot.Web.Mvc.Json;
using BeforeCellRenderArgs = DayPilot.Web.Mvc.Events.Calendar.BeforeCellRenderArgs;
using TimeRangeSelectedArgs = DayPilot.Web.Mvc.Events.Calendar.TimeRangeSelectedArgs;
using System.Data;

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

        public ActionResult Create()
        {
            return View();
        }

        
        // GET: /NavigatorBackend/
        public ActionResult NavigatorBackend()
        {
            return new Dpn(db, /*Session["accessToken"].ToString()*/ "asdf").CallBack(this);
        }

        // GET: /Backend/
        public ActionResult Backend()
        {
            return new Dpc(db, /*Session["accessToken"].ToString()*/ "asdf").CallBack(this);
        }

        public class Dpn : DayPilotNavigator
        {
            private ApplicationDbContext db;
            private String userID;
            public Dpn(ApplicationDbContext newDB, String newUserID)
            {
                db = newDB;
                userID = newUserID;
            }
            protected override void OnVisibleRangeChanged(VisibleRangeChangedArgs visibleRangeChangedArgs)
            {
                // this select is a really bad example, no where clause
                if (Id == "dpn_recurring")
                {
                    //Events = new EventManager(Controller, "recurring").Data.AsEnumerable();
                    DataRecurrenceField = "recurrence";
                }
                else
                {
                    //Events = new EventManager(Controller).Data.AsEnumerable();
                }

                DataStartField = "Start";
                DataEndField = "End";
                DataIdField = "ID";

            }
        }

        public class Dpc : DayPilotCalendar
        {
            private ApplicationDbContext db;
            private String userID;
            public Dpc(ApplicationDbContext newDB, String newUserID)
            {
                db = newDB;
                userID = newUserID;
            }

            protected override void OnInit(InitArgs e)
            {
                base.OnInit(e);
                DataTable dt = new DataTable();
                var tmp = db.Users.Find(userID).CalendarEvents; // db.Users.Find(userID).CalendarEvents.AsEnumerable();
                List<CalendarEvent> list = tmp.ToList();

                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("start", typeof(DateTime));
                dt.Columns.Add("end", typeof(DateTime));
                dt.Columns.Add("text", typeof(string));

                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };

                foreach(CalendarEvent ev in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = ev.ID;
                    dr["start"] = ev.Start;
                    dr["end"] = ev.End;
                    dr["text"] = ev.Title;
                    dt.Rows.Add(dr);
                }

                DataStartField = "start";
                DataEndField = "end";
                DataIdField = "id";
                DataTextField = "title";

                Events = dt.AsEnumerable();
            }

            

        }
    }
}