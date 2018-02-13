using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Funds;

namespace Publicworks.Entities.Projects

{
    public class CapitalProject
    {
        [Key] [Column(Order = 1)] public Guid CapitalProjectID { get; set; }

        [Required] [MaxLength(20)] public string ProjectNumber { get; set; }

        [Required] [MaxLength(128)] public string ProjectName { get; set; }

        [Required] public bool ProjectStatus { get; set; }

        [MaxLength(1000)] public string StatusDescription { get; set; }

        [MaxLength(4000)] public string ProjectScope { get; set; }

        public DateTime ActiveDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public DateTime BidDate { get; set; }
        public DateTime OriginalBidDate { get; set; }
        public DateTime BidOpen { get; set; }
        public DateTime ConstructionBidAward { get; set; }
        public DateTime DesignComplete { get; set; }
        public DateTime AgendaSetting { get; set; }

        [Required]
        [Range(0, 100)]
        public int PercentDesignComplete { get; set; }

        [ForeignKey("ContractorID")]
        public Guid ContractorID { get; set; }
        public virtual Contractor Contractor { get; set; }

        public virtual Consultant Consultant { get; set; }
        public virtual Secretary Secretary { get; set; }
        public virtual ArchitectEngineer ArchitectEngineer { get; set; }
        public virtual ProjectManager ProjectManager { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual ProjectUser ProjectUser { get; set; }

        public virtual IEnumerable<GeneralLedgerKey> GeneralLedgerKeys { get; set; }


    }
}