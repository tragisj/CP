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

        [Display(Name = "Project Status")]
        public bool ProjectStatus { get; set; }


        
        [StringLength(38)]
        [Display(Name = "Project ID")]
        public Guid ProjectID { get; set; }

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



        //Project Dates Group
        [Display(Name ="Active Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ActiveDate { get; set; }

        [Display(Name ="Bid Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BidDate { get; set; }

        [Display(Name = "Original Bid Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? OriginalBidDate { get; set; }

        [Display(Name ="Bid Opening")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BidOpen { get; set; }

        [Display(Name = "Construction Bid Award")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ConstructionBidAward { get; set; }

        [Display(Name = "Design Complete")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DesignComplete { get; set; }

        [Display(Name = "Agenda Setting")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? AgendaSetting { get; set; }

        [Display(Name = "Design Complete %")]
        public int PercentDesignComplete { get; set; }

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
