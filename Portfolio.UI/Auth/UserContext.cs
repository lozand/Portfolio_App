using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolio_Manager.Data;
using Portfolio_Manager.Model;

namespace Portfolio.UI.Auth
{
    public class UserContext
    {
        private static UserContext _instance;
        private int _userId = 0;
        private PortfolioAppFactory _factory;

        private UserContext()
        {
            _factory = new PortfolioAppFactory();
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
                var user = _factory.UserRepository.GetUsers().Where(u => u.Name == name).FirstOrDefault();
                if (user == null)
                {
                    _factory.UserRepository.CreateUser(new Portfolio_Manager.Model.User()
                    {
                        CashValue = 0,
                        Name = name
                    });
                    user = _factory.UserRepository.GetUsers().Where(u => u.Name == name).FirstOrDefault();
                }
                _userId = user.Id;
            }
            return _userId;
        }
    }
}