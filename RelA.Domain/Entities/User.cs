using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelA.Domain.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(20, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(8, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
