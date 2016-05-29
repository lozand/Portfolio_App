﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio_Manager.Data;
using Portfolio_Manager.Model;
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