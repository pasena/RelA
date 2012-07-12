using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelA.Domain.Entities
{
    public class TaskStatus
    {
        [HiddenInput(DisplayValue = false)]
        public int TaskStatusID { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [MaxLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Description { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Obrigatorio!")]
        public string Color { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public DateTime? DeleteDate { get; set; }

        public bool IsDefault { get; set; }
    }
}
