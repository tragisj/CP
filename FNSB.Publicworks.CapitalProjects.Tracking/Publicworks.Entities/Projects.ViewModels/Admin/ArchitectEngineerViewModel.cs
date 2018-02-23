using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels.Admin
{
    public class ArchitectEngineerViewModel
    {
        [Display(Name = "A/E ID")]
        public Guid ArchitectEngineerID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}
