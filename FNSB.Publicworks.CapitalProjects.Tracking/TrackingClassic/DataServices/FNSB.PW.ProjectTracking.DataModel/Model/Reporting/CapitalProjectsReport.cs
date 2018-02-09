using System;
using System.Collections.Generic;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.Model.Reporting
{
    public class CapitalProjectsReport
    {

        public static List<string> ReportFields = new List<string> 
            {   "ProjectName",                      //0
                "ProjectNumber",                    //1 
                "ProjectManager",                   //2
                "ArchitectEngineer",                //3
                "Secretary",                        //4
                "Consultant",                       //5
                "Contractor",                       //6
                "IFBRFQ",                           //7
                "DesignPercentComplete",            //8
                "DesignComplete",                   //9
                "BidOpening",                       //10
                "ConstructionPercentComplete",      //11
                "NTP",                              //12
                "SubstantialCompletion",            //13
                "WarrantyPeriodEnds",               //14
                "Closed",                           //15
                "CurrentStatus",                    //16
                "ProjectBudget",                    //17
                "Expenditures",                     //18
                "Encumbrances",                     //19
                "AvailableBalance"                  //20
            };

        public int Id;
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public ArchitectEngineer ArchitectEngineer { get; set; }
        public Secretary Secretary { get; set; }
        public Consultant Consultant { get; set; }
        public Contractor Contractor { get; set; }
        public string IfbRfq { get; set; }
        public int? DesignPercentComplete { get; set; }
        public DateTime? DesignComplete { get; set; }
        public DateTime? BidOpening { get; set; }
        public int? ConstructionPercentComplete { get; set; }
        public DateTime? Ntp { get; set; }
        public DateTime? SubstantialCompletion { get; set; }
        public DateTime? WarrentyPeriodEnds { get; set; }
        public DateTime? Closed { get; set; }
        public string CurrentStatus { get; set; }
        public ICollection<Fund> Funds;
    }
}
