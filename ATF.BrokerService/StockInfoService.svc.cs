using StockInfoService.Models;
using StockInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockInfoService
{
    public class StockInfoService : IStockInfoService
    {
        public StockInfoService()
        {
            core = new StockInfoCore();
        }

        StockInfoCore core;

        public List<StockInfo> SearchForStock(string input)
        {
            List<StockInfo> stockInfos = core.SearchForStock(input);
            return stockInfos;
        }

        public StockDetail GetStockDetail(string stockSymbol)
        {
            StockDetail detail = new StockDetail();
            return detail;
        }

        public void AddStock(string stockSymbol, string companyName, string description)
        {
            core.AddStock(stockSymbol, companyName, description);
        }

    }
}
