using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ATF.Model.Enum;
using ATF.Data.Interfaces;
using ATF.Model.Interfaces;

namespace ATF.Data
{
    public class TransactionLogRepository : ITransactionLogRepository
    {
        ATFEntities dbContext;

        public TransactionLogRepository(ATFEntities context)
        {
            dbContext = context;
        }

        #region Basic Crud Methods
        public IEnumerable<ITransactionLog> Get()
        {
            return dbContext.TransactionLogs.Select(p => Mapper.Map<Data.TransactionLog, Model.TransactionLog>(p)).ToList();
        }

        public void Create(IPortfolio portfolio, StockAction stockAction)
        {
            var stock = dbContext.Stocks.Where(s => s.ID == portfolio.StockId).FirstOrDefault();
            bool purchased = stockAction == StockAction.Bought ? true : false;
            ITransactionLog entity = new Model.TransactionLog
            {
                Price = stock.LastPrice.Value,
                StockId = stock.ID,
                Purchased = purchased,
                Quantity = portfolio.Quantity,
                TransactionDate = DateTime.Now
            };
            dbContext.TransactionLogs.Add(Mapper.Map<ITransactionLog, Data.TransactionLog>(entity));
            dbContext.SaveChanges();
        }

        public void Update(ITransactionLog entity)
        {
            TransactionLog dbTLog = dbContext.TransactionLogs.Where(s => s.Id == entity.Id).FirstOrDefault();

            dbTLog.StockId = entity.StockId;
            dbTLog.Quantity = entity.Quantity;
            dbTLog.Price = entity.Price;
            dbTLog.Purchased = entity.Purchased;
            dbTLog.TransactionDate = entity.TransactionDate;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var log = dbContext.TransactionLogs.Where(s => s.Id == id).FirstOrDefault();
            dbContext.Entry(log).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion 
    }
}
