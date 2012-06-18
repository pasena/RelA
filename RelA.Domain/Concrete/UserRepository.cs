using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Abstract;

namespace RelA.Domain.Concrete
{
    public class UserRepository : IUserRepository
    {

        public IQueryable<Entities.User> Users
        {
            get { throw new NotImplementedException(); }
        }

        public void SaveUser(Entities.User user)
        {
            throw new NotImplementedException();
        }
    }
}
