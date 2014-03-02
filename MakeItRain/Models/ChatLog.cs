using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeItRain.Models
{
    public class ChatLog
    {
        //PK
        public int ID { get; set; }
        //FK
        public string ApplicationUserID { get; set; }
        //Attributes
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        //Navigation Properties'
        public virtual ApplicationUser User { get; set; }
    }
}