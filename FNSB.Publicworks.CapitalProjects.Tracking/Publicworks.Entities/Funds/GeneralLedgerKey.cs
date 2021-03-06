﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Entities;
using Publicworks.Entities.Projects;

namespace Publicworks.Entities.Funds
{
    public class GeneralLedgerKey
    {

        [Key]
        [Column(Order = 1)]
        public Guid GeneralLedgerKeyID { get; set; }
   
        [Required]
        public string GLKey { get; set; }
        public DateTime FinanceImportDate { get; set; }
        public bool ActiveKey { get; set; }

        public Guid ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

    }
}
