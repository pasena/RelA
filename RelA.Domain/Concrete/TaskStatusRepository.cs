using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;

namespace RelA.Domain.Concrete
{
    public class TaskStatusRepository: ITaskStatusRepository
    {
        private RelAContext context = null;

        public TaskStatusRepository()
        {
            context = new RelAContext();
        }

        public IQueryable<Entities.TaskStatus> GetAll
        {
            get { return context.TaskStatus; }
        }

        public void Save(Entities.TaskStatus entity)
        {
            if (entity.TaskStatusID == 0)
            {
                context.TaskStatus.Add(entity);
            }
            else
            {
                TaskStatus updateEntity = context.TaskStatus.FirstOrDefault(w => w.TaskStatusID == entity.TaskStatusID);

                if (updateEntity != null)
                {
                    context.Entry(updateEntity).CurrentValues.SetValues(entity);
                }
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TaskStatus entity = context.TaskStatus.FirstOrDefault(w => w.TaskStatusID == id);

            if (entity != null)
            {
                context.TaskStatus.Remove(entity);
            }

            context.SaveChanges();
        }
    }
}
