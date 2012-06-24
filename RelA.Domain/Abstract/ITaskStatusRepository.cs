﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Entities;

namespace RelA.Domain.Abstract
{
    interface ITaskStatusRepository
    {
        IQueryable<TaskStatus> Status { get; }

        void SaveStatus(TaskStatus status);
    }
}
