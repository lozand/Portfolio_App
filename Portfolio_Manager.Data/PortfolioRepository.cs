using AutoMapper;
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

        public double GetPortfolioValue(int userId)
        {
            var portfolio = dbContext.Portfolios.Where(p => p.UserId == userId);
            var sum = portfolio.Sum(p => p.Stock.LastPrice * p.Quantity);

            if (sum != null)
            {
                return sum.Value;
            }
            return 0;
        }

        public void BuyPortfolioEntry(Model.Portfolio entity)
        {
            var existingRecord = dbContext.Portfolios.Where(p => p.StockId == entity.StockId && p.UserId == entity.StockId).FirstOrDefault();
            if(existingRecord == null)
            {
                CreatePortfolioEntry(entity);
            }
            else
            {
                entity.Quantity += existingRecord.Quantity.Value;
                UpdatePortfolioQuantity(entity);
            }
            
        }

        public void SellPortfolioEntry(Model.Portfolio entity)
        {
            var existingRecord = dbContext.Portfolios.Where(p => p.StockId == entity.StockId && p.UserId == entity.StockId).FirstOrDefault();
            if(existingRecord == null)
            {
                //user tries to sell a stock that he/she doesn't own
                return;
            }
            if(existingRecord.Quantity > entity.Quantity)
            {
                entity.Quantity -= existingRecord.Quantity.Value;
                UpdatePortfolioQuantity(entity);
            }
            else if(existingRecord.Quantity <= entity.Quantity)
            {
                // if a user tries to sell more than he/she owns, we'll just sell as much as they have.
                DeletePortfolioEntry(entity.UserId, entity.StockId);
            }
        }
    }
}
