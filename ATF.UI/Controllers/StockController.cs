using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATF.Model;
using ATF.UI.Auth;
using ATF.Core;
using System.Net;

namespace ATF.UI.Controllers
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
                return GetCustomError(ex.Message);
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
                return GetCustomError(ex.Message);
            }
        }

        public JsonResult DeleteStock(int stockId)
        {
            try
            {
                _core.DeleteStock(stockId);
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.OK), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return GetCustomError(ex.Message);
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
                return GetCustomError(ex.Message);
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
                return GetCustomError(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private JsonResult GetCustomError(string message)
        {
            return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, message), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}