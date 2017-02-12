using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockBrokerService.Models
{
    public class AccountDetail : BaseResponse
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public double CashInAccount { get; set; }
        public List<Stock> Portfolio { get; set; }
        public double CurrentAccountValue {
            get {
                return GetCurrentAccountValue();
            }
            private set { }
        }

        private double GetCurrentAccountValue()
        {
            List<double> valueOfEachStock = new List<double>();

            Portfolio.ForEach(p =>
            {
                valueOfEachStock.Add(p.Quantity * p.CurrentValue);
            });

            return valueOfEachStock.Sum();
        }
    }
}