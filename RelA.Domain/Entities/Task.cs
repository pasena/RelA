using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RelA.Domain.Entities
{
    public class Task
    {
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public string Description { get; set; }

        public virtual ICollection<Change> Changes { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public DateTime RequestDate { get; set; }

        public DateTime? ConclusionDate { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public virtual TaskStatus Status { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public virtual User User { get; set; }

        [StringLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Note { get; set; }

        public virtual int ProjectID { get; set; }
    }
}
