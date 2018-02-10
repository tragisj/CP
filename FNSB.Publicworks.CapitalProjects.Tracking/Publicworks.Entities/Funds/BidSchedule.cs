using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Publicworks.Entities.Agents;

namespace Publicworks.Entities.Funds
{
    public class BidSchedule
    {
        [Key]
        [Column(Order = 1)]
        public Guid  BidScheduleID { get; set; }

        public DateTime BidDate { get; set; }
        public DateTime OriginalBidDate { get; set; }
        public DateTime BidOpen { get; set; }
        public DateTime GeneralServicesReview { get; set; }
        public DateTime ConstructionBidAward { get; set; }

        [Required]
        [Range(0, 100)]
        public int PercentDesignComplete { get; set; }

        public DateTime DesignComplete { get; set; }
        public DateTime AgendaSetting { get; set; }

        public Guid GeneralLedgerKeyID { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual Consultant Consultant { get; set; }

    }
}


//[PPM_Recordid],
//[PPM_Project_Name],
//[PPM_Project_Number], 
//[PPM_Active_Date],
//[PPM_Inactive_Date],
//[PPM_Project_Active], 
//[PPM_Status_Desc],
//[PPM_Per_Des_Complete],
//[PPM_Proj_Scope], 
//[PPM_MSA_Update], 
//[PPM_Consultant_Fee],
//[PPM_Contract_Amount],
//[PPM_Contract_Amendments], 
//[PPM_CO],
//[PPM_Per_Const_Complete], 
//[PPM_IFB_RFQ], 
//[PPM_User_Letter], 
//[PPM_RFP_Number],
//[NDI_RFP], 
//[NDI_Scope], 
//[NDI_Advertise_for_Bid],
//[NDI_Original_Bid_Date], 
//[NDI_Bid_Opening],
//[NDI_Gen_Serv_Review], 
//[NDI_Consultant_Award], 
//[NDI_Construction_Bid_Award],
//[NDI_Design_Complete],
//[NDI_Agenda_Setting],
//[NDI_Assembly_Approval], 
//[NDI_NTP], 
//[NDI_Substantial_Completion], 
//[NDI_Final],
//[NDI_Warranty_Period_Ends],
//[NDI_Closed],
//[PPS_Recordid], 
//[PPU_Recordid], 
//[PPT_Recordid],
//[PPR_Recordid], 
//[PPC_Recordid], 
//[PPA_Recordid], 
//[PPN_Recordid],
//[NOU_Recordid], 
//[FFM_Recordid], 
//[ppm_project_complete] 