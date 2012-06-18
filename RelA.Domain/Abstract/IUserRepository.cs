using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Entities;

namespace RelA.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void SaveUser(User user);
    }
}
