using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeItRain.Models
{
    public class StockTransaction
    {
        //PK
        public int ID { get; set; }
        //FK
        public string ApplicationUserID { get; set; }
        //Attributes
        public DateTime Timestamp { get; set; }
        public string StockID { get; set; }
        public string StockName { get; set; }
        public int StockAmount { get; set; }
        public double StockPrice { get; set; }
        //Navigation Properties
        public virtual ApplicationUser User { get; set; }
    }
}