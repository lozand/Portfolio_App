using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Model
{
    public class Stock
    {
        int Id { get; set; }
        string Symbol { get; set; }
        double LastPrice { get; set; }
        string CompanyName { get; set; }
    }
}
