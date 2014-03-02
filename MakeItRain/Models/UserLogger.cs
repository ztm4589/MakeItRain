using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeItRain.Models
{
    public class UserLogger
    {
        //PK
        public int ID { get; set; }
        //FK
        public string ApplicationUserID { get; set; }
        //Attributes
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }
        //Navigation Properties
        public virtual ApplicationUser User { get; set; }
    }
}