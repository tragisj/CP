using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectTypeEditViewModel
    {
        [Display(Name = "Project Type ID")]
        public string ProjectTypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Project Type")]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
