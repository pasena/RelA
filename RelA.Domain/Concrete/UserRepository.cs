using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Abstract;
using System.Data.Entity;
using RelA.Domain.Entities;

namespace RelA.Domain.Concrete
{
    public class UserRepository : IUserRepository
    {
        private RelAContext context = null;

        public UserRepository()
        {
            context = new RelAContext();
        }

        public IQueryable<User> GetAll
        {
            get { return context.Users; }
        }

        public void Save(User entity)
        {
            if (entity.UserID == 0)
            {
                context.Users.Add(entity);
            }
            else
            {
                User entityUpdate = context.Users.FirstOrDefault(f => f.UserID == entity.UserID);

                if (entity != null)
                {
                    context.Entry(entity).CurrentValues.SetValues(entity);
                }
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            User entity = context.Users.FirstOrDefault(f => f.UserID == id);

            context.Users.Remove(entity);

            context.SaveChanges();
        }
    }
}
