using System;
using System.Collections.Generic;
using System.Linq;
using ATF.Data;
using ATF.Model.Enum;
using ATF.Model.Interfaces;
using Stock = ATF.Model.Stock;
using User = ATF.Model.User;
using Portfolio = ATF.Model.Portfolio;
using ATF.Data.Interfaces;
using ATF.Model.Exceptions;

namespace ATF.Core
{
    public class PortfolioCore : IPortfolioCore
    {
        IPortfolioAppFactory _factory;

        public PortfolioCore()
        {
            _factory = new PortfolioAppFactory();
        }

        public IEnumerable<IStock> GetStocks()
        {
            return _factory.StockRepository.Get();
        }

        public void BuyStock(int userId, int stockId, int quantity)
        {
            var money = _factory.UserRepository.GetCashValueByUserId(userId);
            var cost = _factory.StockRepository.GetStockById(stockId).LastPrice * quantity;

            if (money >= cost)
            {
                Portfolio portfolio = new Portfolio()
                {
                    Quantity = quantity,
                    StockId = stockId,
                    UserId = userId
                };
                _factory.PortfolioRepository.BuyPortfolioEntry(portfolio);

                _factory.UserRepository.AddCashValue(userId, -1 * cost);

                _factory.TransactionLogRepository.Create(portfolio, StockAction.Bought);
            }
            else
            {
                throw new NotEnoughCashException();
            }
        }

        public void SellStock(int userId, int stockId, int quantity)
        {
            var currentEntry = _factory.PortfolioRepository.GetPortfolioByUserId(userId).Where(p => p.StockId == stockId).First();
            if (currentEntry.Quantity >= quantity)
            {
                var stock = _factory.StockRepository.GetStockById(stockId);
                var proceeds = stock.LastPrice * quantity;

                Portfolio entry = new Portfolio()
                {
                    Quantity = quantity,
                    StockId = stockId,
                    UserId = userId
                };

                _factory.PortfolioRepository.SellPortfolioEntry(entry);

                _factory.UserRepository.AddCashValue(userId, proceeds);

                _factory.TransactionLogRepository.Create(entry, StockAction.Sold);
            }
            else
            {
                throw new NotEnoughSharesException();
            }
        }

        public double GetPortfolioValue(int userId)
        {
            return _factory.PortfolioRepository.GetPortfolioValue(userId);
        }

        public double GetUserCash(int userId)
        {
            return _factory.UserRepository.GetCashValueByUserId(userId);
        }

        public void AddCashToUser(int userId, double value)
        {
            _factory.UserRepository.AddCashValue(userId, value);
        }

        public void CreateStock(IStock stock)
        {
            _factory.StockRepository.Create(stock);
        }

        public void UpdateStock(IStock stock)
        {
            _factory.StockRepository.Update(stock);
        }

        public IEnumerable<IUser> GetUsers()
        {
            return _factory.UserRepository.GetUsers();
        }

        public void CreateUser(IUser user)
        {
            _factory.UserRepository.Create(user);
        }

        public IEnumerable<IPortfolio> GetPortfolio()
        {
            return _factory.PortfolioRepository.Get();
        }
    }
}
