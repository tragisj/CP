using System;
using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class ProjectActiveDetailReport
    {
        public static List<string> ReportFields = new List<string> 
            { "ProjectNumber",                      //0
                "ProjectName",                      //1 
                "ProjectManager",                   //2
                "ArchitectEngineer",                //3
                "Secretary",                        //4
                "DesignComplete",                   //5
                "AdvertiseBid",                     //6
                "BidOpening",                       //7
                "ConstructionPercentComplete",      //8
                "SubstantialCompletion",            //9
                "WarrantyPeriodEnds",               //10
                "ProjectBudget",                    //11
                "AvailableBalance",                 //12
                "BudgetTotal",                      //13
                "BalanceTotal"                      //14
            };

        public int Id; 
        public string ProjectNumber;  
        public string ProjectName; 
        public ProjectManager ProjectManager;
        public ArchitectEngineer ArchitectEngineer;
        public ICollection<Fund> Funds; 
        public Secretary Secretary; 
        public int? DesignComplete;
        public DateTime? AdvertiseBid;
        public DateTime? BidOpening;
        public int? ConstructionPercentComplete;
        public DateTime? SubstantialCompletion;
        public DateTime? WarrentyPeriodEnds;
    }
}
