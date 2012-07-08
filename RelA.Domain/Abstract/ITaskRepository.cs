using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Entities;

namespace RelA.Domain.Abstract
{
    public interface ITaskRepository : IRepositoryBase<Task>
    {
        void ChangeStatus(Task task, int taskStatusID);
    }
}
