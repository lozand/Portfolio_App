using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;
using ATF.Model.Enum;

namespace ATF.Data.Interfaces
{
    public interface ITransactionLogRepository
    {
        IEnumerable<ITransactionLog> Get();

        void Create(IPortfolio portfolio, StockAction stockAction);

        void Update(ITransactionLog entity);

        void Delete(int transactionLogId);
    }
}
