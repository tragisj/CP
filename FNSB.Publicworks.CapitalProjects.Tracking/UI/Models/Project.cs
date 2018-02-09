using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.Projects")]
    public partial class Project
    {
        [Key]
        public int PPM_Recordid { get; set; }

        [StringLength(255)]
        [Display(Name  = "Name")]
        public string PPM_Project_Name { get; set; }

        [StringLength(255)]
        [Display(Name = "Number")]
        public string PPM_Project_Number { get; set; }

        [Display(Name = "Active Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PPM_Active_Date { get; set; }

        [Display(Name = "Inactive Date")]
        public DateTime? PPM_Inactive_Date { get; set; }

        [Display(Name = "Status")]
        public bool? PPM_Project_Active { get; set; }

        [Display(Name = "Status Desc.")]
        public string PPM_Status_Desc { get; set; }

        [Display(Name = "Design Complete %")]
        public int? PPM_Per_Des_Complete { get; set; }

        [Display(Name = "Scope")]
        public string PPM_Proj_Scope { get; set; }

        [Display(Name = "MSA Update")]
        public bool? PPM_MSA_Update { get; set; }

        [Display(Name = "Consultant Fee")]
        public decimal? PPM_Consultant_Fee { get; set; }

        [Display(Name = "Contract Amount")]
        public decimal? PPM_Contract_Amount { get; set; }

        [Display(Name = "Contract Amendments")]
        public decimal? PPM_Contract_Amendments { get; set; }

        [Display(Name = "Change Orders")]
        public decimal? PPM_CO { get; set; }

        [Display(Name = "Construction Complete %")]
        public int? PPM_Per_Const_Complete { get; set; }

        [StringLength(255)]
        [Display(Name = "IFB / RFQ")]
        public string PPM_IFB_RFQ { get; set; }

        [Display(Name = "User Letter")]
        public bool? PPM_User_Letter { get; set; }

        [StringLength(255)]
        [Display(Name = "RFP Number")]
        public string PPM_RFP_Number { get; set; }

        [Display(Name = "NDI RFP")]
        public DateTime? NDI_RFP { get; set; }

        [Display(Name = "NDI Scope")]
        public DateTime? NDI_Scope { get; set; }

        [Display(Name = "NDI Advertise for Bid")]
        public DateTime? NDI_Advertise_for_Bid { get; set; }

        [Display(Name = "Original Bid")]
        public DateTime? NDI_Original_Bid_Date { get; set; }

        [Display(Name = "Bid Opening")]
        public DateTime? NDI_Bid_Opening { get; set; }

        [Display(Name = "General Services Review")]
        public DateTime? NDI_Gen_Serv_Review { get; set; }

        [Display(Name = "Cosultant Award")]
        public DateTime? NDI_Consultant_Award { get; set; }

        [Display(Name = "Construction Bid Award")]
        public DateTime? NDI_Construction_Bid_Award { get; set; }

        [Display(Name = "Design Completed=")]
        public DateTime? NDI_Design_Complete { get; set; }

        [Display(Name = "Agenda Setting")]
        public DateTime? NDI_Agenda_Setting { get; set; }

        [Display(Name = "Assembly Approval")]
        public DateTime? NDI_Assembly_Approval { get; set; }

        [Display(Name = "NTP")]
        public DateTime? NDI_NTP { get; set; }

        [Display(Name = "Substantial Completion")]
        public DateTime? NDI_Substantial_Completion { get; set; }

        [Display(Name = "Final Inspection")]
        public DateTime? NDI_Final { get; set; }

        [Display(Name = "Correction Period Ends")]
        public DateTime? NDI_Warranty_Period_Ends { get; set; }

        [Display(Name = "Closed")]
        public DateTime? NDI_Closed { get; set; }

        public int? PPS_Recordid { get; set; }

        public int PPU_Recordid { get; set; }

        public int? PPT_Recordid { get; set; }
        
        public int ppr_recordid { get; set; }

        public int PPC_Recordid { get; set; }

        public int PPA_Recordid { get; set; }

        public int PPN_Recordid { get; set; }

        public int? NOU_Recordid { get; set; }

        public int? FFM_Recordid { get; set; }

        public bool? ppm_project_complete { get; set; }

        public enum SelectStatus
        {
            Active,
            Inactive,
            All
        }

    }
}
