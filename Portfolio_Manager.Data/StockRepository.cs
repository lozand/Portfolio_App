using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Portfolio_Manager.Data
{
    public class StockRepository
    {
        PortfolioAppEntities dbContext;
        StockHistoryRepository _stockHistoryRepostitory;

        public StockRepository(PortfolioAppEntities context)
        {
            dbContext = context;
            _stockHistoryRepostitory = new StockHistoryRepository(context);
        }
        #region Basic Crud Methods
        public List<Model.Stock> GetStocks()
        {
            return dbContext.Stocks.ToList().Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).ToList();
        }

        public void CreateStock(Model.Stock entity)
        {
            dbContext.Stocks.Add(Mapper.Map<Model.Stock, Data.Stock>(entity));
            dbContext.SaveChanges();
        }

        public void UpdateStock(Model.Stock entity)
        {
            Stock dbStock = dbContext.Stocks.Where(s => s.ID == entity.ID).FirstOrDefault();

            dbStock.LastPrice = entity.LastPrice;
            dbStock.Symbol = entity.Symbol;
            dbStock.CompanyName = entity.CompanyName;

            dbContext.SaveChanges();
        }

        public void DeleteStock(int id)
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

        public Model.Stock GetStockBySymbol(string symbol)
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

    }
}
