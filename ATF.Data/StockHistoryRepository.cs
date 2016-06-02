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
    public class StockHistoryRepository : IStockHistoryRepository
    {
        ATFEntities dbContext;

        public StockHistoryRepository(ATFEntities context)
        {
            dbContext = context;
        }

        #region Basic Crud Methods
        public IEnumerable<IStockHistory> Get()
        {
            return dbContext.StockHistories.ToList().Select(s => Mapper.Map<Data.StockHistory, Model.StockHistory>(s)).ToList();
        }

        public void Add(IStockHistory entity)
        {
            dbContext.StockHistories.Add(Mapper.Map<IStockHistory, Data.StockHistory>(entity));
            dbContext.SaveChanges();
        }

        public void Update(IStockHistory entity)
        {
            StockHistory dbStock = dbContext.StockHistories.Where(s => s.Id == entity.Id).FirstOrDefault();

            dbStock.Price = entity.Price;
            dbStock.StockId = entity.StockId;
            dbStock.ObservationTime = entity.ObservationTime;
            dbStock.IsEod = entity.IsEod;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var stockhistory = dbContext.StockHistories.Where(s => s.Id == id).FirstOrDefault();
            dbContext.Entry(stockhistory).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion  
    }
}
