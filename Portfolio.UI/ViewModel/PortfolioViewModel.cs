using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolio_Manager.Model;

namespace Portfolio.UI.ViewModel
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel()
        {
            Folio = new List<PortfolioStockViewModel>();
        }
        public List<PortfolioStockViewModel> Folio { get; set; }
        public double FolioValue { get; set; }
        public double UserCash { get; set; }
    }
}