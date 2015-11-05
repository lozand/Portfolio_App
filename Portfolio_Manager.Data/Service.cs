using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class Service
    {
        public PortfolioAppFactory Factory { get; set; }

        public Service()
        {
            Factory = new PortfolioAppFactory();
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
            Factory.StockRepository.CreateStock(symbol, price, companyName);
        }

        
    }
}
