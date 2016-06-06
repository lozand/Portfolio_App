using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATF.StockAPI
{
    public static class GoogleStockApi
    {
        private static string Company { get; set; }
        private static string Exchange { get; set; }
        private static double Last { get; set; }
        private static double High { get; set; }
        private static double Low { get; set; }

        public static string GetStockPrice(string symbol)
        { 
            string url = "http://www.google.com/ig/api?stock=" + symbol;
            XDocument doc = XDocument.Load(url);
            return GetData(doc, "last");
        }

        //public static string GetQuote(string symbol)
        //{
        //    string url = "http://www.google.com/ig/api?stock=" + symbol;
        //    XDocument doc = XDocument.Load(url);
        //    Company = GetData(doc, "company");
        //    Exchange = GetData(doc, "exchange");
        //    Last = Convert.ToDouble(GetData(doc, "last"));
        //    High = Convert.ToDouble(GetData(doc, "high"));
        //    Low = Convert.ToDouble(GetData(doc, "low"));
        //}

        private static string GetData(XDocument doc, string name)
        {
            return doc.Root.Element("finance").Element(name).Attribute("data").Value;
        }
    }
}
