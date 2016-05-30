using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio_Manager.Model.Enum;


namespace Portfolio_Manager.Data
{
    public class TransactionLogRepository
    {
        PortfolioAppEntities dbContext;

        public TransactionLogRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }

        #region Basic Crud Methods
        public List<Model.TransactionLog> GetTransactionLogs()
        {
            return dbContext.TransactionLogs.Select(p => Mapper.Map<Data.TransactionLog, Model.TransactionLog>(p)).ToList();
        }

        public void CreateTransactionLogs(Model.Portfolio portfolio, StockAction stockAction)
        {
            var stock = dbContext.Stocks.Where(s => s.ID == portfolio.StockId).FirstOrDefault();
            bool purchased = stockAction == StockAction.Bought ? true : false;
            Model.TransactionLog entity = new Model.TransactionLog
            {
                Price = stock.LastPrice.Value,
                StockId = stock.ID,
                Purchased = purchased,
                Quantity = portfolio.Quantity,
                TransactionDate = DateTime.Now
            };
            dbContext.TransactionLogs.Add(Mapper.Map<Model.TransactionLog, Data.TransactionLog>(entity));
            dbContext.SaveChanges();
        }

        public void UpdateTransactionLog(Model.TransactionLog entity)
        {
            TransactionLog dbTLog = dbContext.TransactionLogs.Where(s => s.Id == entity.Id).FirstOrDefault();

            dbTLog.StockId = entity.StockId;
            dbTLog.Quantity = entity.Quantity;
            dbTLog.Price = entity.Price;
            dbTLog.Purchased = entity.Purchased;
            dbTLog.TransactionDate = entity.TransactionDate;

            dbContext.SaveChanges();
        }

        public void DeleteTransactionLogEntry(int id)
        {
            var log = dbContext.TransactionLogs.Where(s => s.Id == id).FirstOrDefault();
            dbContext.Entry(log).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion 
    }
}
