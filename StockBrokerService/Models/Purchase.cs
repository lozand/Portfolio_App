using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockBrokerService.Models
{
    public class Purchase :BaseResponse
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}