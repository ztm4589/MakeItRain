using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;


namespace MakeItRain.Models
{
    public class CSVParser
    {
        
        public void parse()
        {
            //?s=%40%5EDJI,IBM,GOOG,IDA&f=nsl1op&e=.csv
            string URL = "http://download.finance.yahoo.com/d/quotes.csv?s=%40%5EDJI,IBM,GOOG,IDA&f=nsl1op&e=.csv";
            WebRequest req = WebRequest.Create(URL);
            Stream stockStream = req.GetResponse().GetResponseStream();
            StreamReader stockReader = new StreamReader(stockStream);
            string sLine = "";
            int i = 0;
            while (sLine != null)
            {
                i++;
                sLine = stockReader.ReadLine();
                if (sLine != null)
                    Console.WriteLine("{0}:{1}", i, sLine);
            }
            Console.ReadLine();
        }
    }
}