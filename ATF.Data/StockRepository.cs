using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ATF.Data.Interfaces;
using ATF.Model.Interfaces;

namespace ATF.Data
{
    public class StockRepository : IStockRepository
    {
        ATFEntities dbContext;

        public StockRepository(ATFEntities context)
        {
            dbContext = context;
        }
        #region Basic Crud Methods
        public IEnumerable<IStock> Get()
        {
            return dbContext.Stocks.ToList().Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).ToList();
        }

        public void Create(IStock entity)
        {
            dbContext.Stocks.Add(Mapper.Map<IStock, Data.Stock>(entity));
            dbContext.SaveChanges();
        }

        public void Update(IStock entity)
        {
            Stock dbStock = dbContext.Stocks.Where(s => s.ID == entity.ID).FirstOrDefault();

            dbStock.LastPrice = entity.LastPrice;
            dbStock.Symbol = entity.Symbol;
            dbStock.CompanyName = entity.CompanyName;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var portfolioEntries = dbContext.Portfolios.Where(p => p.StockId == id);
            foreach(var entry in portfolioEntries)
            {
                var userId = entry.UserId;
                var symbol = entry.StockSymbol;
                dbContext.Entry(entry).State = System.Data.Entity.EntityState.Deleted;
            }
            var transactionLogs = dbContext.TransactionLogs.Where(t => t.StockId == id);
            foreach(var log in transactionLogs)
            {
                dbContext.Entry(log).State = System.Data.Entity.EntityState.Deleted;
            }
            var stockHistories = dbContext.StockHistories.Where(h => h.StockId == id);
            foreach(var history in stockHistories)
            {
                dbContext.Entry(history).State = System.Data.Entity.EntityState.Deleted;
            }
            var stock = dbContext.Stocks.Where(s => s.ID == id).FirstOrDefault();
            dbContext.Entry(stock).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion  

        public IStock GetStockBySymbol(string symbol)
        {
            try
            {
                return dbContext.Stocks.ToList().Where(s => s.Symbol == symbol.ToUpper()).Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).FirstOrDefault();
            }
            catch
            {
                return new Model.Stock();
            }
        }

        public IStock GetStockById(int stockId)
        {
            try
            {
                return dbContext.Stocks.ToList().Where(s => s.ID == stockId).Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).FirstOrDefault();
            }
            catch
            {
                return new Model.Stock();
            }
        }

    }
}
