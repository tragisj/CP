using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Publicworks.Entities.Projects;

namespace Publicworks.Entities.Admin
{
    public class ProjectManager
    {

        [Key]
        [Column(Order = 1)]
        public Guid ProjectManagerID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<Project> Projects { get; set; }


    }
}
    