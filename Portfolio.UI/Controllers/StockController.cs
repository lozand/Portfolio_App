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

        #region Views
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        #endregion

        #region Json Methods
        public JsonResult Get()
        {
            return Json(_factory.StockRepository.GetStocks(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            return Json(_factory.StockRepository.GetStocks().Where(s => s.ID == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveStock(int id, string symbol, string companyName, double price)
        {
            try {
                _factory.StockRepository.UpdateStock(new Stock()
                {
                    ID = id,
                    Symbol = symbol,
                    CompanyName = companyName,
                    LastPrice = price
                });
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.OK), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}