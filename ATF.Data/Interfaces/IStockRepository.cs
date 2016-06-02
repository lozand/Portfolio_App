using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Data.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<IStock> Get();

        void Create(IStock stock);

        void Update(IStock stock);

        void Delete(int stockId);

        IStock GetStockBySymbol(string symbol);

        IStock GetStockById(int stockId);
    }
}
