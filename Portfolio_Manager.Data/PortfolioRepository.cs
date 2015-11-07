﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;


namespace Portfolio_Manager.Data
{
    public class PortfolioRepository
    {
        PortfolioAppEntities dbContext;

        public PortfolioRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }
        #region Basic Crud Methods
        public List<Model.Portfolio> GetPortfoio()
        {
            return dbContext.Portfolios.Select(p => Mapper.Map<Data.Portfolio, Model.Portfolio>(p)).ToList();
        }

        public void CreatePortfolioEntry(Model.Portfolio entity)
        {
            dbContext.Portfolios.Add(Mapper.Map<Model.Portfolio, Data.Portfolio>(entity));
            dbContext.SaveChanges();
        }

        public void UpdatePortfolioQuantity(Model.Portfolio entity)
        {
            Portfolio dbportfolio = dbContext.Portfolios.Where(s => s.UserId == entity.UserId && s.StockId == entity.StockId).FirstOrDefault();

            dbportfolio.Quantity = entity.Quantity;

            dbContext.SaveChanges();
        }

        public void DeletePortfolioEntry(int userId, int stockId)
        {
            var stock = dbContext.Portfolios.Where(s => s.UserId == userId && s.StockId == stockId).FirstOrDefault();
            dbContext.Entry(stock).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion  
    }
}
