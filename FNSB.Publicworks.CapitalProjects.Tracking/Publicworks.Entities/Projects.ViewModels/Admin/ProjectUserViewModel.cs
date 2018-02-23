using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Publicworks.Entities.Projects.ViewModels.Admin
{
    public class ProjectUserViewModel
    {

        [StringLength(38)]
        [Display(Name = "Project User ID")]
        public Guid ProjectUserID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }

    }
}
