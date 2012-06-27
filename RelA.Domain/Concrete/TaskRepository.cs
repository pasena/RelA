using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;

namespace RelA.Domain.Concrete
{
    public class TaskRepository: ITaskRepository
    {
        private RelAContext context = null;

        public TaskRepository()
        {
            context = new RelAContext();
        }

        public IQueryable<Entities.Task> GetAll
        {
            get { return context.Tasks; }
        }

        public void Save(Entities.Task entity)
        {
            if (entity.TaskID == 0)
            {
                context.Tasks.Add(entity);
            }
            else
            {
                Task updateEntity = context.Tasks.FirstOrDefault(w => w.TaskID == entity.TaskID);

                if (updateEntity != null)
                {
                    context.Entry(updateEntity).CurrentValues.SetValues(entity);
                }
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Task entity = context.Tasks.FirstOrDefault(w => w.TaskID == id);

            if (entity != null)
            {
                context.Tasks.Remove(entity);
            }

            context.SaveChanges();
        }
    }
}
