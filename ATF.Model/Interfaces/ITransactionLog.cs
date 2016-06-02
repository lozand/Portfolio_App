using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Model.Interfaces
{
    public interface ITransactionLog
    {
        int Id { get; set; }
        int StockId { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
        bool Purchased { get; set; }
        DateTime TransactionDate { get; set; }
    }
}
