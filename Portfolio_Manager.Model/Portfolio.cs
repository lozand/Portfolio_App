using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Model
{
    public class Portfolio
    {
        public int StockId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
