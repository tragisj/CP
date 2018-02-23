using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectEditViewModel
    {

        public string ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Number")]
        [StringLength(20)]
        public string ProjectNumber { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(128)]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Status")]
        public bool ProjectStatus { get; set; }


        [StringLength(1000)]
        [Display(Name = "Status Description")]
        public string StatusDescription { get; set; }


    }
}
