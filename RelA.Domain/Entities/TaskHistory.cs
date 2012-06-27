using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RelA.Domain.Entities
{
    public class TaskHistory
    {
        public int TaskHistoryID { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public virtual Task Task { get; set; }
        [Required(ErrorMessage = "Obrigatorio!")]
        public virtual TaskStatus Status { get; set; }
        [Required(ErrorMessage = "Obrigatorio!")]
        public DateTime HistoryDate { get; set; }
    }
}
