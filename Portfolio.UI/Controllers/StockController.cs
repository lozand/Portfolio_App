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
        StockRepository _repository;

        public StockController()
        {
            _repository = new StockRepository(new PortfolioAppEntities());
        }

        public ActionResult Index()
        {
            return View();
        }

        public List<Stock> Get()
        {
            return _repository.GetStocks();
        }
    }
}