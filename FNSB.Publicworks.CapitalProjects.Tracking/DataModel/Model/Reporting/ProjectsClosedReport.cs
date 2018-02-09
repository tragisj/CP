using System;
using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class ProjectsClosedReport
    {
        public static List<string> ReportFields = new List<string> 
                            { 
                                "ClosedDate", 
                                "InactiveDate", 
                                "WarrentyEnd", 
                                "ProjectNumber",
                                "ProjectName",
                                "ProjectBudget", 
                                "ProjectExpenditures" 
                            };

        public int Id;
        public string ProjectNumber;
        public string ProjectName;
        public ICollection<Fund> Fund;
        public DateTime? ProjectClosed;
        public DateTime? Inactived;
        public DateTime? WarrentyEnd;
    }
}
