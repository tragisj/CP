using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Finance.OneSolution.Entities;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectSummaryViewIndexModel
    {

        [StringLength(38)]
        [Display(Name = "Project ID")]
        public Guid ProjectID { get; set; }

        [StringLength(20)]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [StringLength(128)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Current Status")]
        public string ActiveProject { get; set; }

        [Display(Name = "Project Description")]
        public string ProjectDesc { get; set; }

        public List<ProjectTrackingFinance> TrackingFinances { get; set; }

    }
}
