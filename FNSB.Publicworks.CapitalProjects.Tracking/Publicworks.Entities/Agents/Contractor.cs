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
    public class Contractor
    {
        [Key]
        [Column(Order = 1)]
        public Guid ContractorID { get; set; }

        [Required]
        [MaxLength(128)]
        public string ContractorName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

    }
}
