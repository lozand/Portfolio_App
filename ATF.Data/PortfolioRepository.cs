using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ATF.Model;
using ATF.Data.Interfaces;
using ATF.Model.Interfaces;

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
        public IEnumerable<IPortfolio> Get()
        {
            var hi = dbContext.Portfolios.ToList();
            var there = hi.Select(p => Mapper.Map<Data.Portfolio, Model.Portfolio>(p));
            return there.ToList();
        }

        public void Create(IPortfolio entity)
        {
            dbContext.Portfolios.Add(Mapper.Map<IPortfolio, ATF.Data.Portfolio>(entity));
            dbContext.SaveChanges();
        }

        public void UpdatePortfolioQuantity(IPortfolio entity)
        {
            Portfolio dbportfolio = dbContext.Portfolios.Where(s => s.UserId == entity.UserId && s.StockSymbol == entity.StockSymbol).FirstOrDefault();

            dbportfolio.Quantity = entity.Quantity;

            dbContext.SaveChanges();
        }

        public void Delete(int userId, string stockSymbol)
        {
            var stock = dbContext.Portfolios.Where(s => s.UserId == userId && s.StockSymbol == stockSymbol).FirstOrDefault();
            dbContext.Entry(stock).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion  

        public IEnumerable<IPortfolio> GetPortfolioByUserId(int userId)
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

        public void BuyPortfolioEntry(IPortfolio entity)
        {
            var existingRecord = dbContext.Portfolios.Where(p => p.StockSymbol == entity.StockSymbol && p.UserId == entity.UserId).FirstOrDefault();
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

        public void SellPortfolioEntry(IPortfolio entity)
        {
            var existingRecord = dbContext.Portfolios.Where(p => p.StockSymbol == entity.StockSymbol && p.UserId == entity.UserId).FirstOrDefault();
            if(existingRecord == null)
            {
                //user tries to sell a stock that he/she doesn't own
                return;
            }
            if(existingRecord.Quantity == entity.Quantity)
            {
                Delete(entity.UserId, entity.StockSymbol);
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
