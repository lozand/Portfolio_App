using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class Service
    {
        public Service()
        {
        }

        public void BuyStock()
        {

        }

        public void SellStock()
        {

        }

        public List<Portfolio> GetPortfolio()
        {
            return new List<Portfolio>();
        }

        public void CreateStock(string symbol, double price, string companyName)
        {
            new StockRepository().CreateStock(symbol, price, companyName);
        }

        
    }
}
