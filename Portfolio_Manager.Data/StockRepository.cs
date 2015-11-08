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

        public StockRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }
        #region Basic Crud Methods
        public List<Model.Stock> GetStocks()
        {
            return dbContext.Stocks.Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).ToList();
        }

        public void CreateStock(Model.Stock entity)
        {
            dbContext.Stocks.Add(Mapper.Map<Model.Stock, Data.Stock>(entity));
            dbContext.SaveChanges();
        }

        public void UpdateStock(Model.Stock entity)
        {
            Stock dbStock = dbContext.Stocks.Where(s => s.ID == entity.Id).FirstOrDefault();

            dbStock.LastPrice = entity.LastPrice;
            dbStock.Symbol = entity.Symbol;
            dbStock.CompanyName = entity.CompanyName;

            dbContext.SaveChanges();
        }

        public void DeleteStock(int id)
        {
            var stock = dbContext.Stocks.Where(s => s.ID == id).FirstOrDefault();
            dbContext.Entry(stock).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion  

        public Model.Stock GetStockBySymbol(string symbol)
        {
            try {
                return dbContext.Stocks.ToList().Where(s => s.Symbol == symbol.ToUpper()).Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).FirstOrDefault();
            }
            catch(Exception ex)
            {
                return new Model.Stock();
            }
        }

    }
}
