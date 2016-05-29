using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Portfolio_Manager.Data
{
    public class StockHistoryRepository
    {
        PortfolioAppEntities dbContext;

        public StockHistoryRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }

        #region Basic Crud Methods
        public List<Model.StockHistory> Get()
        {
            return dbContext.StockHistories.ToList().Select(s => Mapper.Map<Data.StockHistory, Model.StockHistory>(s)).ToList();
        }

        public void Add(Model.StockHistory entity)
        {
            dbContext.StockHistories.Add(Mapper.Map<Model.StockHistory, Data.StockHistory>(entity));
            dbContext.SaveChanges();
        }

        public void Update(Model.StockHistory entity)
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
