using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ConsultantEditViewModel
    {

        [Required]
        [Display(Name = "Customer Number")]
        public string ConsultantID { get; set; }


        [Required]
        [Display(Name = "Consultant Name")]
        [StringLength(128)]
        public string ConsultantName { get; set; }

        [Display(Name = "Consultant Description")]
        [StringLength(255)]
        public string Description { get; set; }


    }
}
