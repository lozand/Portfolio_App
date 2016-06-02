using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Data.Interfaces
{
    public interface IUserRepository
    {
        List<Model.User> GetUsers();

        void Create(Model.User user);

        void Update(Model.User user);

        void Delete(int userId);

        double GetCashValueByUserId(int userId);

        void AddCashValue(int userId, double value);
    }
}
