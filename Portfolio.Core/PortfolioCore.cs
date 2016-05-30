using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio_Manager.Data;
using Portfolio_Manager.Model;
using Portfolio_Manager.Model.Enum;
using Stock = Portfolio_Manager.Model.Stock;
using User = Portfolio_Manager.Model.User;

namespace Portfolio.Core
{
    public class PortfolioCore
    {
        PortfolioAppFactory _factory;

        public PortfolioCore()
        {
            _factory = new PortfolioAppFactory();
        }

        public List<Stock> GetStocks()
        {
            return _factory.StockRepository.GetStocks();
        }

        public void BuyStock(int userId, int stockId, int quantity)
        {
            var money = _factory.UserRepository.GetCashValueByUserId(userId);
            var cost = _factory.StockRepository.GetStockById(stockId).LastPrice * quantity;

            if (money >= cost)
            {
                Portfolio_Manager.Model.Portfolio portfolio = new Portfolio_Manager.Model.Portfolio()
                {
                    Quantity = quantity,
                    StockId = stockId,
                    UserId = userId
                };
                _factory.PortfolioRepository.BuyPortfolioEntry(portfolio);

                _factory.UserRepository.AddCashValue(userId, -1 * cost);

                _factory.TransactionLogRepository.CreateTransactionLogs(portfolio, StockAction.Bought);
            }
        }

        public void SellStock(int userId, int stockId, int quantity)
        {
            // remove the stock from the portfolio

            // add the proceeds to their cash

            // update the transaction log
        }

        public double GetPortfolioValue(int userId)
        {
            return _factory.PortfolioRepository.GetPortfolioValue(userId);
        }

        public void CreateStock(Stock stock)
        {
            _factory.StockRepository.CreateStock(stock);
        }

        public void UpdateStock(Stock stock)
        {
            _factory.StockRepository.UpdateStock(stock);
        }

        public List<User> GetUsers()
        {
            return _factory.UserRepository.GetUsers();
        }

        public void CreateUser(User user)
        {
            _factory.UserRepository.CreateUser(user);
        }

        public List<Portfolio_Manager.Model.Portfolio> GetPortfolio()
        {
            return _factory.PortfolioRepository.Get();
        }
    }
}
