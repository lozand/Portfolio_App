using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class PortfolioAppFactory
    {
        PortfolioAppEntities dbContext = new PortfolioAppEntities();

        public StockRepository StockRepository;
        public PortfolioRepository PortfolioRepository;
        public UserRepository UserRepository;
        public TransactionLogRepository TransactionLogRepository;
        public StockHistoryRepository StockHistoryRepository;

        public PortfolioAppFactory()
        {
            AutomapperConfig.SetMappings();
            StockRepository = new StockRepository(dbContext);
            StockHistoryRepository = new StockHistoryRepository(dbContext);
            PortfolioRepository = new PortfolioRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            TransactionLogRepository = new TransactionLogRepository(dbContext);
        }
    }
}
