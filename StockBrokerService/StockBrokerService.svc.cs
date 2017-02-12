using StockBrokerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockBrokerService
{
    public class StockBrokerService : IStockBrokerService
    {
        public BaseResponse AddMoneyToUserAccount(int userId, double money)
        {
            //TODO: Write
            throw new NotImplementedException();
        }

        public BaseResponse WithdrawMoneyFromUserAccount(int userId, double money)
        {
            //TODO: Write
            throw new NotImplementedException();
        }

        public AccountDetail GetAccountDetailsForUser(int userId)
        { 
            //TODO: Write
            throw new NotImplementedException();
        }

        public Purchase BuyStock(int userId, string stockSymbol, int quantity, double desiredPrice = 0)
        {
            //TODO: Write
            throw new NotImplementedException();
        }

        public Purchase SellStock(int userId, string stockSymbol, int quantity, double desiredPrice = 0)
        {
            //TODO: Write
            throw new NotImplementedException();
        }

        public Stock GetStockInfo(int userId, string stockSymbol)
        {
            //TODO: Write
            throw new NotImplementedException();
        }
    }
}
