using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockBrokerService.Models
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            HasError = false;
        }

        bool HasError { get; set; }
        string Message { get; set; }
    }
}