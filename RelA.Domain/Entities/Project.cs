using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelA.Domain.Entities
{
    public class Project
    {
        [HiddenInput(DisplayValue=false)]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [StringLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
