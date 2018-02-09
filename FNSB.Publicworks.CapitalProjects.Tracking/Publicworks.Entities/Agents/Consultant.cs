using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Entities.Projects;

namespace Publicworks.Entities.Agents
{
    public class Consultant
    {


        [Key]
        [Column(Order = 1)]
        public Guid ConsultantID { get; set; }

        [Required]
        [MaxLength(128)]
        public string ConsultantName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual IEnumerable<CapitalProject> CapitalProjects { get; set; }

    }
}
