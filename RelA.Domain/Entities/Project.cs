using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RelA.Domain.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
