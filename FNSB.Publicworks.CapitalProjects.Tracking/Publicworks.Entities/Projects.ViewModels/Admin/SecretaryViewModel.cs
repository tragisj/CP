using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Publicworks.Entities.Projects.ViewModels.Admin
{
    public class SecretaryViewModel
    {
        [Display(Name = "Admin ID")]
        public Guid SecretaryID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }



    }
}
