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

        [Required]
        [MaxLength(20)]
        public string ProjectNumber { get; set; }

        [Required]
        [MaxLength(128)]
        public string ProjectName { get; set; }

        [Required]
        public bool ProjectStatus { get; set; }

        [MaxLength(1000)]
        public string StatusDescription { get; set; }

        [MaxLength(4000)]
        public string ProjectScope { get; set; }

        public DateTime ActiveDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        public DateTime? BidDate { get; set; }
        public DateTime? OriginalBidDate { get; set; }
        public DateTime? BidOpen { get; set; }
        public DateTime? ConstructionBidAward { get; set; }
        public DateTime? DesignComplete { get; set; }
        public DateTime? AgendaSetting { get; set; }

        public decimal ConsultantFees { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal ContractAmendments { get; set; }
        public decimal ChangeOrders { get; set; }


        //[PPM_Consultant_Fee]
        //[PPM_Contract_Amount]
        //[PPM_Contract_Amendments]
        //[PPM_CO]
        //[PPM_Per_Const_Complete]
        //[PPM_IFB_RFQ]
        //[PPM_User_Letter]
        //[PPM_RFP_Number]
        //[NDI_RFP]
        //[NDI_Scope]
        //[NDI_Advertise_for_Bid]
        //[NDI_Original_Bid_Date]
        //[NDI_Bid_Opening]
        //[NDI_Gen_Serv_Review]
        //[NDI_Consultant_Award]
        //[NDI_Construction_Bid_Award]
        //[NDI_Design_Complete]
        //[NDI_Agenda_Setting]
        //[NDI_Assembly_Approval]
        //[NDI_NTP]
        //[NDI_Substantial_Completion]
        //[NDI_Final]
        //[NDI_Warranty_Period_Ends]
        //[NDI_Closed]
        //[PPS_Recordid]
        //[PPU_Recordid]
        //[PPT_Recordid]
        //[PPR_Recordid]
        //[PPC_Recordid]
        //[PPA_Recordid]
        //[PPN_Recordid]
        //[NOU_Recordid]
        //[FFM_Recordid]
        //[ppm_project_complete]



        [Required]
        [Range(0, 100)]
        public int PercentDesignComplete { get; set; }

        public int PercentProjectComplete { get; set; }

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