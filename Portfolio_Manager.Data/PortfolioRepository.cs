using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class PortfolioRepository
    {
        PortfolioAppEntities dbContext;

        public PortfolioRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }
    }
}
