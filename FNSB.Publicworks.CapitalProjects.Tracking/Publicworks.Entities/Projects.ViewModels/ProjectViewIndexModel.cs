using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectViewIndexModel
    {

        [StringLength(20)]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [StringLength(128)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [StringLength(38)]
        [Display(Name = "Project ID")]
        public Guid ProjectID { get; set; }

        [Display(Name = "Active Project")]
        public bool ActiveProject { get; set; }

        [Display(Name = "Activated")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ActiveDate { get; set; }
    }

  
}
