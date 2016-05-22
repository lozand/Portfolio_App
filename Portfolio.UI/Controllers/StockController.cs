using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio_Manager.Model;
using Portfolio_Manager.Data;
using Stock = Portfolio_Manager.Model.Stock;

namespace Portfolio.UI.Controllers
{
    public class StockController : Controller
    {
        PortfolioAppFactory _factory;

        public StockController()
        {
            _factory = new PortfolioAppFactory();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            return Json(_factory.StockRepository.GetStocks(), JsonRequestBehavior.AllowGet);
        }
    }
}