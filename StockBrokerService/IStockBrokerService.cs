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
    [ServiceContract]
    public interface IStockBrokerService
    {
        BaseResponse AddMoneyToUserAccount(int userId, double money);

        BaseResponse WithdrawMoneyFromUserAccount(int userId, double money);

        AccountDetail GetAccountDetailsForUser(int userId);

        Purchase BuyStock(int userId, string stockSymbol, int quantity, double desiredPrice = 0);

        Purchase SellStock(int userId, string stockSymbol, int quantity, double desiredPrice = 0);

        /// <summary>
        /// Returns the brokers' stock information for the current user. Should just be pretty much a quantity for now. In the future, this could return average buying price as well.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="stockSymbol"></param>
        /// <returns></returns>
        Stock GetStockInfo(int userId, string stockSymbol);
    }
}
