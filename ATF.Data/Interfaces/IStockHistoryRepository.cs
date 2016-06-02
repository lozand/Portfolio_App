using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Data.Interfaces
{
    public interface IStockHistoryRepository
    {
        IEnumerable<IStockHistory> Get();

        void Add(IStockHistory entity);

        void Update(IStockHistory entity);

        void Delete(int id);
    }
}
