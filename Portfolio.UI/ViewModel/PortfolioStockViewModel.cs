using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATF.UI.ViewModel
{
    public class PortfolioStockViewModel
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}