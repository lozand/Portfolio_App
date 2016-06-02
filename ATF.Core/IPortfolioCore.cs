using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model;

namespace ATF.Core
{
    public interface IPortfolioCore
    {
        List<Stock> GetStocks();

        void BuyStock(int userId, int stockId, int quantity);

        void SellStock(int userId, int stockId, int quantity);

        double GetPortfolioValue(int userId);

        double GetUserCash(int userId);

        void AddCashToUser(int userId, double value);

        void CreateStock(Stock stock);

        void UpdateStock(Stock stock);

        List<User> GetUsers();

        void CreateUser(User user);

        List<Portfolio> GetPortfolio();
    }
}
