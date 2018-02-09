using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects
{
    public class ProjectType
    {

        [Key]
        [Column(Order = 1)]
        public Guid ProjectTypeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        public virtual IEnumerable<CapitalProject> CapitalProjects { get; set; }

    }
}
