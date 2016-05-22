using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Model
{
    public class Stock
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public double LastPrice { get; set; }
        public string CompanyName { get; set; }
    }
}
