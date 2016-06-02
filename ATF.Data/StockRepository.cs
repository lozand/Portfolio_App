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
        StockHistoryRepository _stockHistoryRepostitory;

        public StockRepository(ATFEntities context)
        {
            dbContext = context;
            _stockHistoryRepostitory = new StockHistoryRepository(context);
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
            var stockHistories = dbContext.StockHistories.Where(h => h.StockId == id);
            foreach(var history in stockHistories)
            {
                _stockHistoryRepostitory.Delete(history.Id);
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
