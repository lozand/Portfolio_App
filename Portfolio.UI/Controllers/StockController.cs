using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio_Manager.Model;
using Portfolio.UI.Auth;
using Portfolio.Core;
using System.Net;

namespace Portfolio.UI.Controllers
{
    public class StockController : Controller
    {
        PortfolioCore _core;

        public StockController()
        {
            _core = new PortfolioCore();
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

        public ActionResult Add()
        {
            return View();
        }
        #endregion

        #region Json Methods
        public JsonResult Get()
        {
            return Json(_core.GetStocks(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            return Json(_core.GetStocks().Where(s => s.ID == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddStock(string symbol, string companyName, double price)
        {
            try
            {
                _core.CreateStock(new Stock()
                {
                    CompanyName = companyName,
                    LastPrice = price,
                    Symbol = symbol
                });
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.OK), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateStock(int id, string symbol, string companyName, double price)
        {
            try
            {
                _core.UpdateStock(new Stock()
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

        public void RetreiveStockPrices()
        {
            
        }

        public JsonResult BuyStock(int stockId, int quantity)
        {
            try
            {
                int userId = UserContext.Instance.UserId;
                if (userId > 0)
                {
                    _core.BuyStock(userId, stockId, quantity);
                }
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.OK, "Stock successfully purchased!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Stock could not be purchased at this time. Please try again later."), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SellStock(int stockId, int quantity)
        {
            try
            {
                int userId = UserContext.Instance.UserId;
                if (userId > 0)
                {
                    _core.SellStock(userId, stockId, quantity);
                }
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.OK, "Stock successfully sold!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Stock could not be sold at this time. Please try again later."), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}