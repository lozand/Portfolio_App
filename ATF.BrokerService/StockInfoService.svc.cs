using StockInfoService.Models;
using StockInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ATF.StockInfoService
{
    public class StockInfoService : IStockInfoService
    {
        public List<StockInfo> SearchForStock(string input)
        {
            List<StockInfo> stockInfos = new List<StockInfo>();
            //TODO: Write
            return stockInfos;
        }

        public StockDetail GetStockDetail(string stockSymbol)
        {
            StockDetail detail = new StockDetail();
            //TODO: Write
            return detail;
        }

    }
}
