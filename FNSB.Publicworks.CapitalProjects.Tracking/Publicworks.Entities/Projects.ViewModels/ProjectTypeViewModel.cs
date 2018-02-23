using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectTypeViewModel
    {
        [Display(Name = "Project Type Number")]
        public Guid ProjectTypeID { get; set; }

        [Display(Name = "Type Name")]
        public string Name { get; set; }

        [Display(Name = "Type Description")]
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
