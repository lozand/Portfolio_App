using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Model.Interfaces
{
    public interface IStock
    {
        int ID { get; set; }
        string Symbol { get; set; }
        double LastPrice { get; set; }
        string CompanyName { get; set; }
    }
}
