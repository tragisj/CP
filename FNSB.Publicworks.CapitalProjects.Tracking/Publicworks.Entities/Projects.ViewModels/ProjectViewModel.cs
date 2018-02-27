using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ProjectViewModel
    {

        [StringLength(38)]
        [Display(Name = "Project ID")]
        public Guid ProjectID { get; set; }

        [Display(Name = "Active Project")]
        public bool ActiveProject { get; set; }

        [Display(Name = "Activated")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ActiveDate { get; set; }

        [Display(Name = "CompletedProject")]
        public bool CompletedProject { get; set; }

        [StringLength(20)]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [StringLength(128)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [StringLength(1000)]
        [Display(Name = "Status Description")]
        public string StatusDescription { get; set; }

        [StringLength(4000)]
        [Display(Name = "Project Scope")]
        public string ProjectScope { get; set; }

        [Display(Name = "Agenda Setting")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AgendaSetting { get; set; }

        [Display(Name = "Assembly Approval")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AssemblyApproval { get; set; }

        [Display(Name ="Advertise for Bid")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AdvertiseForBid { get; set; }

        [Display(Name = "Original Bid Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? OriginalBidDate { get; set; }

        [Display(Name ="Bid Opening")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BidOpening { get; set; }

        [Display(Name = "Consultant Bid Award")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ConsultantBidAward { get; set; }

        [Display(Name = "Construction Bid Award")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ConstructionBidAward { get; set; }

        [Display(Name = "Design Completed")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DesignCompleted { get; set; }

        [Display(Name = "Notice to Proceed")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? NoticeToProceed { get; set; }

        [Display(Name = "Substantial Completion")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? SubstantialCompletion { get; set; }

        [Display(Name = "Final Inspection")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FinalInspection { get; set; }

        [Display(Name = "Warranty Period Ends")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? WarrantyPeriodEnds { get; set; }

        [Display(Name = "Closed Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ClosedDate { get; set; }


        [Display(Name = "Contract Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ContractAmount { get; set; }

        [Display(Name = "Contract Amendments")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ContractAmendments { get; set; }

        [Display(Name = "Change Orders")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ChangeOrders { get; set; }

        [Display(Name = "Consultant Fees")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ConsultantFees { get; set; }


        [Display(Name = "% Design Complete")]
        public int PercentDesignComplete { get; set; }

        [Display(Name = "% Construction Complete")]
        public int PercentConstructionComplete { get; set; }

        [Display(Name = "Project Type")]
        public string ProjectType { get; set; }

        [Display(Name="Contractor")]
        public string Contractor { get; set; }

        [Display(Name = "Consultant")]
        public string Consultant { get; set; }

        public string ConsultantDesc { get; set; }

        [Display(Name = "Architect / Engineer")]
        public string ArchitectEngineer { get; set; }

        [Display(Name="Project Manager")]
        public string ProjectManager { get; set; }

        [Display(Name = "Project User")]
        public string ProjectUser { get; set; }

        [Display(Name = "Admin. Assistant")]
        public string Secretary { get; set; }


    }
}
