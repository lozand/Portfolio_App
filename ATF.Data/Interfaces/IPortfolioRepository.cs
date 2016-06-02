using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Data.Interfaces
{
    public interface IPortfolioRepository
    {
        IEnumerable<IPortfolio> Get();

        void Create(IPortfolio entity);

        void UpdatePortfolioQuantity(IPortfolio entity);

        void Delete(int userId, int stockId);

        IEnumerable<IPortfolio> GetPortfolioByUserId(int userId);

        double GetPortfolioValue(int userId);

        void BuyPortfolioEntry(IPortfolio entity);

        void SellPortfolioEntry(IPortfolio entity);
    }
}
