using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATF.Model;
using ATF.Core;

namespace ATF.UI.Auth
{
    public class UserContext
    {
        private static UserContext _instance;
        private int _userId = 0;
        private PortfolioCore _core;

        private UserContext()
        {
            _core = new PortfolioCore();
        }

        public static UserContext Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UserContext();
                }
                return _instance;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public void SignOut()
        {
            _userId = 0;
        }

        public int SignIn(string name)
        {
            if (_userId == 0)
            {
                var user = _core.GetUsers().Where(u => u.Name == name).FirstOrDefault();
                if (user == null)
                {
                    _core.CreateUser(new ATF.Model.User()
                    {
                        CashValue = 0,
                        Name = name
                    });
                    user = _core.GetUsers().Where(u => u.Name == name).FirstOrDefault();
                }
                _userId = user.Id;
            }
            return _userId;
        }
    }
}