using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class PortfolioAppFactory
    {
        public StockRepository StockRepository;
        public PortfolioRepository PortfolioRepository;
        public UserRepository UserRepository;
        public TransactionLogRepository TransactionLogRepository;

        public PortfolioAppFactory()
        {
            StockRepository = new StockRepository();
            PortfolioRepository = new PortfolioRepository();
            UserRepository = new UserRepository();
            TransactionLogRepository = new TransactionLogRepository();
        }
    }
}
