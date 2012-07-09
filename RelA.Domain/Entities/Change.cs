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
        public int TaskID { get; set; }

        public virtual Task Task { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [MaxLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [MaxLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Modification { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [MaxLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        public string Note { get; set; }
    }
}
