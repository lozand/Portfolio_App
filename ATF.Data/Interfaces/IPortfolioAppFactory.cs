using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Data.Interfaces
{
    public interface IPortfolioAppFactory
    {
        StockRepository StockRepository { get; set; }
        PortfolioRepository PortfolioRepository { get; set; }
        UserRepository UserRepository { get; set; }
        TransactionLogRepository TransactionLogRepository { get; set; }
        StockHistoryRepository StockHistoryRepository { get; set; }
    }
}
