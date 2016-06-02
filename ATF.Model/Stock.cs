using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Model
{
    public class Stock : IStock
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public double LastPrice { get; set; }
        public string CompanyName { get; set; }
    }
}
