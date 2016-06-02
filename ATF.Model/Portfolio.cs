using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Model
{
    public class Portfolio : IPortfolio
    {
        public int StockId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
