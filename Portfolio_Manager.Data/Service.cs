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
        public int UserId { get; set; }

        public Service(string userName)
        {
            Factory = new PortfolioAppFactory();
            UserId = GetUserIdFromUserName(userName);
        }

        public void BuyStock(string symbol, int quantity)
        {
            var stock = Factory.StockRepository.GetStockBySymbol(symbol);
            Model.Portfolio portfolio = new Model.Portfolio
            {
                StockId = stock.ID,
                UserId = UserId,
                Quantity = quantity
            };
            var cash = Factory.UserRepository.GetCashValueByUserId(UserId);
            if(cash >= quantity * stock.LastPrice)
            {
                var moneyToRemove = quantity * stock.LastPrice;
                Factory.PortfolioRepository.BuyPortfolioEntry(portfolio);
                Factory.UserRepository.UpdateCashValue(UserId, -1 * moneyToRemove);
                Factory.TransactionLogRepository.CreateTransactionLogs(portfolio, stock, true);
            }
            else
            {
                //user does not have enough money to make this purchase
                //we should probably have some type of return code. 
            }
        }

        public void SellStock(string symbol, int quantity)
        {
            var stock = Factory.StockRepository.GetStockBySymbol(symbol);
            Model.Portfolio portfolio = new Model.Portfolio
            {
                StockId = stock.ID,
                UserId = UserId,
                Quantity = quantity
            };
            var moneyToAdd = quantity * stock.LastPrice;
            Factory.PortfolioRepository.SellPortfolioEntry(portfolio);
            Factory.UserRepository.UpdateCashValue(UserId, moneyToAdd);
            Factory.TransactionLogRepository.CreateTransactionLogs(portfolio, stock, false);
        }
        
        public List<Model.Portfolio> GetPortfolio()
        {
            return Factory.PortfolioRepository.Get();
        }

        public double GetPortfolioValue()
        {
            return Factory.PortfolioRepository.GetPortfolioValue(UserId);
        }

        public void CreateStock(string symbol, double price, string companyName)
        {
            Model.Stock stock = new Model.Stock
            {
                Symbol = symbol,
                LastPrice = price,
                CompanyName = companyName
            };
            Factory.StockRepository.CreateStock(stock);
        }

        private int GetUserIdFromUserName(string name)
        {
            var user = Factory.UserRepository.GetUsers().Where(u => u.Name == name).FirstOrDefault();
            if(user == null)
            {
                Model.User newUser = new Model.User
                {
                    Name = name
                };
                Factory.UserRepository.CreateUser(newUser);
                user = Factory.UserRepository.GetUsers().Where(u => u.Name == name).FirstOrDefault();
            }
            return user.Id;
        }
        
    }
}
