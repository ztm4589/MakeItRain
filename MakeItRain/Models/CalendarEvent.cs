using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeItRain.Models
{
    public class CalendarEvent
    {
        //PK
        public int ID { get; set; }
        //FK
        public string ApplicationUserID { get; set; }
        //Attributes
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //Navigation Properties
        public virtual ApplicationUser User { get; set; }
    }
}