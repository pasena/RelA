using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;

namespace RelA.Domain.Concrete
{
    public class ChangeRepository : IChangeRepository
    {
        private RelAContext context = null;

        public ChangeRepository()
        {
            context = new RelAContext();
        }

        public IQueryable<Entities.Change> GetAll
        {
            get { throw new NotImplementedException(); }
        }

        public void Save(Entities.Change entity)
        {
            if (entity.ChangeID == 0)
            {
                context.Changes.Add(entity);
            }
            else
            {
                Change updateEntity = context.Changes.FirstOrDefault(w => w.ChangeID == entity.ChangeID);

                if (updateEntity != null)
                {
                    context.Entry(updateEntity).CurrentValues.SetValues(entity);
                }
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Change entity = context.Changes.FirstOrDefault(w => w.ChangeID == id);

            if (entity != null)
            {
                context.Changes.Remove(entity);
            }

            context.SaveChanges();
        }
    }
}
