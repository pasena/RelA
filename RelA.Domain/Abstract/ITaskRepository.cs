using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Entities;

namespace RelA.Domain.Abstract
{
    public interface ITaskRepository
    {
        IQueryable<Task> Tasks { get; }

        void SaveTask(Task task);
    }
}
