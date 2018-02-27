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
    public class Project
    {
        [Key] [Column(Order = 1)] public Guid ProjectID { get; set; }

        [Required] [MaxLength(20)] public string ProjectNumber { get; set; }

        [Required] [MaxLength(128)] public string ProjectName { get; set; }

        [MaxLength(1000)] public string StatusDescription { get; set; }

        [MaxLength(4000)] public string ProjectScope { get; set; }

        //Project State
        [Required] public bool ActiveProject { get; set; }
        public bool CompletedProject { get; set; }

        public DateTime Activated { get; set; }
        public DateTime? Inactived { get; set; }
        public DateTime? AgendaSetting { get; set; }
        public DateTime? AssemblyApproval { get; set; }
        public DateTime? AdvertiseForBid { get; set; }
        public DateTime? OriginalBidDate { get; set; }
        public DateTime? BidOpening { get; set; }
        public DateTime? ConsultantBidAward { get; set; }
        public DateTime? ConstructionBidAward { get; set; }
        public DateTime? DesignCompleted { get; set; }
        public DateTime? NoticeToProceed { get; set; }
        public DateTime? SubstantialCompletion { get; set; }
        public DateTime? FinalInspection { get; set; }
        public DateTime? WarrantyPeriodEnds { get; set; }
        public DateTime? ClosedDate { get; set; }

        public decimal ContractAmount { get; set; }
        public decimal ContractAmendments { get; set; }
        public decimal ChangeOrders { get; set; }
        public decimal ConsultantFees { get; set; }



        [Required]
        [Range(0, 100)]
        public int PercentDesignComplete { get; set; }

        [Required]
        [Range(0, 100)]
        public int PercentConstructionComplete { get; set; }

        public Guid ContractorID { get; set; }
        [ForeignKey("ContractorID")]
        public virtual Contractor Contractor { get; set; }

        public Guid ConsultantID { get; set; }
        [ForeignKey("ConsultantID")]
        public virtual Consultant Consultant { get; set; }

        public Guid SecretaryID { get; set; }
        [ForeignKey("SecretaryID")]
        public virtual Secretary Secretary { get; set; }

        public Guid ArchitectEngineerID { get; set; }
        [ForeignKey("ArchitectEngineerID")]
        public virtual ArchitectEngineer ArchitectEngineer { get; set; }

        public Guid ProjectManagerID { get; set; }
        [ForeignKey("ProjectManagerID")]
        public virtual ProjectManager ProjectManager { get; set; }

        public Guid ProjectTypeID { get; set; }
        [ForeignKey("ProjectTypeID")]
        public virtual ProjectType ProjectType { get; set; }

        public Guid ProjectUserID { get; set; }
        [ForeignKey("ProjectUserID")]
        public virtual ProjectUser ProjectUser { get; set; }

        public virtual ICollection<GeneralLedgerKey> GeneralLedgerKeys { get; set; }


    }
}