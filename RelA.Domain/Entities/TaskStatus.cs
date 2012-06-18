using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RelA.Domain.Entities
{
    public class TaskStatus
    {
        public int TaskStatusID { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
