using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelA.Domain.Entities
{
    public class Task
    {
        [HiddenInput(DisplayValue=false)]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [StringLength(150, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [Display(Name="Atividade:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [Display(Name = "Derscrição:")]
        public string Description { get; set; }

        public virtual ICollection<Change> Changes { get; set; }

        [Required(ErrorMessage = "Obrigatorio!")]
        [Display(Name = "Data de Solicitação:")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Data de Conclusão:")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime? ConclusionDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [StringLength(500, ErrorMessage = "{0} não pode exceder {1} caracteres")]
        [Display(Name = "Observações:")]
        public string Note { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [HiddenInput(DisplayValue = false)]
        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<TaskHistory> History { get; set; }
    }
}
