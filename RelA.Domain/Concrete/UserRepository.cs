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

        public IQueryable<Entities.User> Users
        {
            get { return context.Users; }
        }

        public void SaveUser(Entities.User user)
        {
            if (user.UserID == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User entity = context.Users.FirstOrDefault(f => f.UserID == user.UserID);

                if (entity != null)
                {
                    context.Entry(entity).CurrentValues.SetValues(user);
                }
            }

            context.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            User entity = context.Users.FirstOrDefault(f => f.UserID == userID);

            context.Users.Remove(entity);

            context.SaveChanges();
        }
    }
}
