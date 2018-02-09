using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Entities.Projects;

namespace Publicworks.Entities.Admin
{
    public class ProjectUser
    {
        [Key]
        [Column(Order = 1)]
        public Guid ProjectUserID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual IEnumerable<CapitalProject> CapitalProjects { get; set; }

    }
}
