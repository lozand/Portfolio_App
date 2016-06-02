using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ATF.Model;
using ATF.Data.Interfaces;

namespace ATF.Data
{
    public class PortfolioRepository : IPortfolioRepository
    {
        ATFEntities dbContext;

        public PortfolioRepository(ATFEntities context)
        {
            dbContext = context;
        }
        #region Basic Crud Methods
        public List<Model.Portfolio> Get()
        {
            var hi = dbContext.Portfolios.ToList();
            var there = hi.Select(p => Mapper.Map<Data.Portfolio, Model.Portfolio>(p));
            return there.ToList();
        }

        public void Create(Model.Portfolio entity)
        {
            dbContext.Portfolios.Add(Mapper.Map<Model.Portfolio, ATF.Data.Portfolio>(entity));
            dbContext.SaveChanges();
        }

        public void UpdatePortfolioQuantity(Model.Portfolio entity)
        {
            Portfolio dbportfolio = dbContext.Portfolios.Where(s => s.UserId == entity.UserId && s.StockId == entity.StockId).FirstOrDefault();

            dbportfolio.Quantity = entity.Quantity;

            dbContext.SaveChanges();
        }

        public void Delete(int userId, int stockId)
        {
            var stock = dbContext.Portfolios.Where(s => s.UserId == userId && s.StockId == stockId).FirstOrDefault();
            dbContext.Entry(stock).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion  

        public List<Model.Portfolio> GetPortfolioByUserId(int userId)
        {
            return dbContext.Portfolios.ToList().Where(p => p.UserId == userId).Select(p => Mapper.Map<Data.Portfolio, Model.Portfolio>(p)).ToList();
        }
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
            var existingRecord = dbContext.Portfolios.Where(p => p.StockId == entity.StockId && p.UserId == entity.UserId).FirstOrDefault();
            if(existingRecord == null)
            {
                Create(entity);
            }
            else
            {
                entity.Quantity += existingRecord.Quantity.Value;
                UpdatePortfolioQuantity(entity);
            }
            
        }

        public void SellPortfolioEntry(Model.Portfolio entity)
        {
            var existingRecord = dbContext.Portfolios.Where(p => p.StockId == entity.StockId && p.UserId == entity.UserId).FirstOrDefault();
            if(existingRecord == null)
            {
                //user tries to sell a stock that he/she doesn't own
                return;
            }
            if(existingRecord.Quantity == entity.Quantity)
            {
                Delete(entity.UserId, entity.StockId);
            }
            else if (existingRecord.Quantity > 0)
            {
                entity.Quantity = existingRecord.Quantity.Value - entity.Quantity;
                UpdatePortfolioQuantity(entity);
            }
            else 
            {
                //user tried to sell more than they have
            }
        }
    }
}
