using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Model.Interfaces
{
    public interface IPortfolio
    {
        int StockId { get; set; }
        int UserId { get; set; }
        int Quantity { get; set; }
    }
}
