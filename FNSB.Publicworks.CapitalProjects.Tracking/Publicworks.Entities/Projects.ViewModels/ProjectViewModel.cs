using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectViewModel
    {
        [StringLength(38)]
        [Display(Name = "Capital Project ID")]
        public Guid ProjectID { get; set; }

        [StringLength(20)]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [StringLength(128)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Status")]
        public bool ProjectStatus { get; set; }

        [StringLength(1000)]
        [Display(Name = "Status Description")]
        public string StatusDescription { get; set; }
    }
}
