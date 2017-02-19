using StockInfoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockInfoService
{
    public class StockInfoCore
    {
        public StockInfoCore()
        {
            data = new StockInfoData();
        }

        StockInfoData data;

        public List<StockInfo> SearchForStock(string query)
        {
            return data.SearchForStock(query);
        }

        public void AddStock(string stockSymbol, string companyname, string description)
        {
            data.SaveStock(stockSymbol, companyname, description);
        }
    }
}