using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RelA.Domain.Entities
{
    public class Change
    {
        public int ChangeID { get; set; }
        
        [Required(ErrorMessage = "Obrigatorio!")]
        public virtual Task Task { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        public string Modification { get; set; }

        [StringLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Note { get; set; }
    }
}
