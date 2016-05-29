using Portfolio_Manager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.UI.ViewModel;

namespace Portfolio.UI.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioAppFactory _factory;

        public PortfolioController()
        {
            _factory = new PortfolioAppFactory();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPortfolio(int userId)
        {
            List<PortfolioViewModel> vm = new List<PortfolioViewModel>();
            var portfolioRecords = _factory.PortfolioRepository.GetPortfoio().Where(p => p.UserId == userId);
            var stocks = _factory.StockRepository.GetStocks().Where(s => portfolioRecords.Select(p => p.StockId).Contains(s.ID));
            foreach(var portfolio in portfolioRecords)
            {
                var stock = stocks.Where(s => s.ID == portfolio.StockId).FirstOrDefault();
                PortfolioViewModel v = new PortfolioViewModel()
                {
                    Price = stock.LastPrice,
                    Quantity = portfolio.Quantity,
                    Symbol = stock.Symbol
                };
                vm.Add(v);
            }
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
    }
}