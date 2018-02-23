using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels.Admin
{
    public class ProjectManagerViewModel
    {
        [Display(Name = "Project Manager ID")]
        public Guid ProjectManagerID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
