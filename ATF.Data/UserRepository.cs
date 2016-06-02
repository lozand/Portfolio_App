using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Data.Interfaces;

namespace ATF.Data
{
    public class UserRepository : IUserRepository
    {
        ATFEntities dbContext;

        public UserRepository(ATFEntities context)
        {
            dbContext = context;
        }

        #region Basic Crud Methods
        public List<Model.User> GetUsers()
        {
            return dbContext.Users.ToList().Select(p => Mapper.Map<Data.User, Model.User>(p)).ToList();
        }

        public void Create(Model.User entity)
        {
            dbContext.Users.Add(Mapper.Map<Model.User, Data.User>(entity));
            dbContext.SaveChanges();
        }

        public void Update(Model.User entity)
        {
            User user = dbContext.Users.Where(s => s.ID == entity.Id).FirstOrDefault();

            user.Name = entity.Name;
            user.CashValue = entity.CashValue;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = dbContext.Users.Where(s => s.ID == id).FirstOrDefault();
            dbContext.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion 

        public double GetCashValueByUserId(int userId)
        {
            var user = dbContext.Users.Where(s => s.ID == userId).FirstOrDefault();
            if(user == null && !user.CashValue.HasValue)
            {
                return 0;
            }
            return user.CashValue.Value;
        }

        public void AddCashValue(int userId, double value)
        {
            var user = dbContext.Users.ToList().Where(s => s.ID == userId).Select(Mapper.Map<User, Model.User>).FirstOrDefault();
            user.CashValue += value;

            Update(user);
        }
    }
}
