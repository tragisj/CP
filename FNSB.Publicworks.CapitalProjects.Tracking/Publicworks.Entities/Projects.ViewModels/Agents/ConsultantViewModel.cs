using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels.Agents
{
    public class ConsultantViewModel
    {

        [Display(Name = "Consultant ID")]
        public Guid ConsultantID { get; set; }

        [Display(Name = "Consultant Name")]
        public string ConsultantName { get; set; }

        [Display(Name = "Consultant Description")]
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }


    }
}
