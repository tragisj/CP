//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FNSB.Publicworks.Projects.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.Funds = new HashSet<Fund>();
        }
    
        public int PPM_Recordid { get; set; }
        public string PPM_Project_Name { get; set; }
        public string PPM_Project_Number { get; set; }
        public Nullable<System.DateTime> PPM_Active_Date { get; set; }
        public Nullable<System.DateTime> PPM_Inactive_Date { get; set; }
        public Nullable<bool> PPM_Project_Active { get; set; }
        public string PPM_Status_Desc { get; set; }
        public Nullable<int> PPM_Per_Des_Complete { get; set; }
        public string PPM_Proj_Scope { get; set; }
        public Nullable<bool> PPM_MSA_Update { get; set; }
        public Nullable<decimal> PPM_Consultant_Fee { get; set; }
        public Nullable<decimal> PPM_Contract_Amount { get; set; }
        public Nullable<decimal> PPM_Contract_Amendments { get; set; }
        public Nullable<decimal> PPM_CO { get; set; }
        public Nullable<int> PPM_Per_Const_Complete { get; set; }
        public string PPM_IFB_RFQ { get; set; }
        public Nullable<bool> PPM_User_Letter { get; set; }
        public string PPM_RFP_Number { get; set; }
        public Nullable<System.DateTime> NDI_RFP { get; set; }
        public Nullable<System.DateTime> NDI_Scope { get; set; }
        public Nullable<System.DateTime> NDI_Advertise_for_Bid { get; set; }
        public Nullable<System.DateTime> NDI_Original_Bid_Date { get; set; }
        public Nullable<System.DateTime> NDI_Bid_Opening { get; set; }
        public Nullable<System.DateTime> NDI_Gen_Serv_Review { get; set; }
        public Nullable<System.DateTime> NDI_Consultant_Award { get; set; }
        public Nullable<System.DateTime> NDI_Construction_Bid_Award { get; set; }
        public Nullable<System.DateTime> NDI_Design_Complete { get; set; }
        public Nullable<System.DateTime> NDI_Agenda_Setting { get; set; }
        public Nullable<System.DateTime> NDI_Assembly_Approval { get; set; }
        public Nullable<System.DateTime> NDI_NTP { get; set; }
        public Nullable<System.DateTime> NDI_Substantial_Completion { get; set; }
        public Nullable<System.DateTime> NDI_Final { get; set; }
        public Nullable<System.DateTime> NDI_Warranty_Period_Ends { get; set; }
        public Nullable<System.DateTime> NDI_Closed { get; set; }
        public Nullable<int> PPS_Recordid { get; set; }
        public int PPU_Recordid { get; set; }
        public Nullable<int> PPT_Recordid { get; set; }
        public int PPR_Recordid { get; set; }
        public int PPC_Recordid { get; set; }
        public int PPA_Recordid { get; set; }
        public int PPN_Recordid { get; set; }
        public Nullable<int> NOU_Recordid { get; set; }
        public Nullable<int> FFM_Recordid { get; set; }
        public Nullable<bool> ppm_project_complete { get; set; }
    
        public virtual ArchitectEngineer ArchitectEngineer { get; set; }
        public virtual Consultant Consultant { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual ICollection<Fund> Funds { get; set; }
        public virtual ProjectManager ProjectManager { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual Secretary Secretary { get; set; }
        public virtual User User { get; set; }
    }
}
