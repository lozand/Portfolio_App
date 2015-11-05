using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class StockRepository
    {
        PortfolioAppEntities dbContext;

        public StockRepository()
        {
            dbContext = new PortfolioAppEntities();
        }
        public void CreateStock(string symbol, double lastPrice, string companyName)
        {
            Data.Stock stock = new Data.Stock();
            stock.Symbol = symbol.ToUpper();
            stock.LastPrice = lastPrice;
            stock.CompanyName = companyName;
            dbContext.Stocks.Add(stock);
            dbContext.SaveChanges();
        }
    }
}
