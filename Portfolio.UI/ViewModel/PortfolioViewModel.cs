﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.UI.ViewModel
{
    public class PortfolioViewModel
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