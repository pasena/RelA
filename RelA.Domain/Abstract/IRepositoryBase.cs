using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RelA.Domain.Abstract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll { get; }

        void Save(T entity);

        void Delete(int id);
    }
}
