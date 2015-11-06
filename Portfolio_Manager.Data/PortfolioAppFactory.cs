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

        public PortfolioAppFactory()
        {
            StockRepository = new StockRepository(dbContext);
            PortfolioRepository = new PortfolioRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            TransactionLogRepository = new TransactionLogRepository(dbContext);
        }
    }
}
