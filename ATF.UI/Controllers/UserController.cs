﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATF.UI.Auth;
using ATF.Model.Interfaces;
using User = ATF.Model.User;
using ATF.Core;

namespace ATF.UI.Controllers
{
    public class UserController : Controller
    {
        PortfolioCore _core;
        public UserController()
        {
            _core = new PortfolioCore();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser()
        {
            var userId = UserContext.Instance.UserId;
            IUser user = new User()
            {
                CashValue = 0,
                IsSignedIn = false
            };

            if(userId != 0)
            {
                user = _core.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
                user.IsSignedIn = true;
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult SignIn(string name)
        {
            try
            {
                if (name != "" && name != null)
                {
                    UserContext.Instance.SignIn(name);
                    return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.OK), JsonRequestBehavior.AllowGet);
                }
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Name cannot be blank"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public void SignOut()
        {
            if(UserContext.Instance.UserId !=0)
            {
                UserContext.Instance.SignOut();
            }
            Response.Redirect("/Home/Index");
        }
    }
}