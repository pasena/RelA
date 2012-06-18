using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RelA.Domain.Entities;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace RelA.Domain.Concrete
{
    public class RelAContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }
    }
}
