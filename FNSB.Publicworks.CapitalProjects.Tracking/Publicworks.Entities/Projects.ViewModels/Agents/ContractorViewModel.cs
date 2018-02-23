using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels.Agents
{
    public class ContractorViewModel
    {
        [Display(Name = "Contractor ID")]
        public Guid ContractorID { get; set; }

        [Display(Name = "Contractor Name")]
        public string ContractorName { get; set; }

        [Display(Name = "Contractor Description")]
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
