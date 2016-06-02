using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<IUser> GetUsers();

        void Create(IUser user);

        void Update(IUser user);

        void Delete(int userId);

        double GetCashValueByUserId(int userId);

        void AddCashValue(int userId, double value);
    }
}
