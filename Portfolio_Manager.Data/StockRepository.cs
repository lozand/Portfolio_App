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
        public Model.Stock GetStockBySymbol(string symbol)
        {
            return dbContext.Stocks.Where(s => s.Symbol == symbol.ToUpper()).Select(s => Mapper.Map<Data.Stock, Model.Stock>(s)).FirstOrDefault();
        }
        public void CreateStock(Model.Stock entity)
        {
            dbContext.Stocks.Add(Mapper.Map<Model.Stock, Data.Stock>(entity));
            dbContext.SaveChanges();
        }

    }
}
