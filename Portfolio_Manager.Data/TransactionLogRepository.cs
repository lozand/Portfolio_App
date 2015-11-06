using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class TransactionLogRepository
    {
        PortfolioAppEntities dbContext;

        public TransactionLogRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }
    }
}
