using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager.Data
{
    public class UserRepository
    {
        PortfolioAppEntities dbContext;

        public UserRepository(PortfolioAppEntities context)
        {
            dbContext = context;
        }

        #region Basic Crud Methods
        public List<Model.User> GetUsers()
        {
            return dbContext.Users.Select(p => Mapper.Map<Data.User, Model.User>(p)).ToList();
        }

        public void CreateUser(Model.User entity)
        {
            dbContext.Users.Add(Mapper.Map<Model.User, Data.User>(entity));
            dbContext.SaveChanges();
        }

        public void UpdateUser(Model.User entity)
        {
            User user = dbContext.Users.Where(s => s.ID == entity.Id).FirstOrDefault();

            user.Name = entity.Name;

            dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = dbContext.Users.Where(s => s.ID == id).FirstOrDefault();
            dbContext.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
        #endregion 
    }
}
