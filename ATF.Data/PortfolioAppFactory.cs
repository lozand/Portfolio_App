using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Data.Interfaces;

namespace ATF.Data
{
    public class PortfolioAppFactory : IPortfolioAppFactory
    {
        ATFEntities dbContext = new ATFEntities();

        public StockRepository StockRepository { get; set; }
        public PortfolioRepository PortfolioRepository { get; set; }
        public UserRepository UserRepository { get; set; }
        public TransactionLogRepository TransactionLogRepository { get; set; }
        public StockHistoryRepository StockHistoryRepository { get; set; }

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
