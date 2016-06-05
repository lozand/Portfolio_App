using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Model
{
    public class TransactionLog : ITransactionLog
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string StockSymbol { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool Purchased { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
