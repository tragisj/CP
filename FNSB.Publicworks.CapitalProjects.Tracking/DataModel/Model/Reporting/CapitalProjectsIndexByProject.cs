using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class CapitalProjectsIndexByProject
    {

        public static List<string> ReportFields = new List<string>
            {
                "ProjectNumber",
                "PageNumber",
                "ProjectName", 
                "ProjectManager",
                "ProjectArchitectEngineer"
            };

        public int PageNumber { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string ProjectArchitectEngineer { get; set; }
    }



}
