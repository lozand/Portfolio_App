using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model;
using ATF.Model.Interfaces;

namespace ATF.Core
{
    public interface IPortfolioCore
    {
        IEnumerable<IStock> GetStocks();

        void BuyStock(int userId, int stockId, int quantity);

        void SellStock(int userId, int stockId, int quantity);

        double GetPortfolioValue(int userId);

        double GetUserCash(int userId);

        void AddCashToUser(int userId, double value);

        void CreateStock(IStock stock);

        void UpdateStock(IStock stock);

        IEnumerable<IUser> GetUsers();

        void CreateUser(IUser user);

        IEnumerable<IPortfolio> GetPortfolio();
    }
}
