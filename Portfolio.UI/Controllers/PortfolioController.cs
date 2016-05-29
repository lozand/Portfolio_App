using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.UI.ViewModel;
using Portfolio.UI.Auth;
using Portfolio.Core;

namespace Portfolio.UI.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioCore _core;

        public PortfolioController()
        {
            _core = new PortfolioCore();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPortfolio()
        {
            int userId = UserContext.Instance.UserId;
            if (userId != 0)
            {
                List<PortfolioViewModel> vm = new List<PortfolioViewModel>();
                var portfolioRecords = _core.GetPortfolio().Where(p => p.UserId == userId);
                var stocks = _core.GetStocks().Where(s => portfolioRecords.Select(p => p.StockId).Contains(s.ID));
                foreach (var portfolio in portfolioRecords)
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
            return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "You need to be signed in to use this page"), JsonRequestBehavior.AllowGet);
        }
    }
}