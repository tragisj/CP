using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Publicworks.Entities.Projects;

namespace Publicworks.Entities.Admin
{
    public class Secretary
    {


        [Key]
        [Column(Order = 1)]
        public Guid SecretaryID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual IEnumerable<CapitalProject> CapitalProjects { get; set; }


    }
}
