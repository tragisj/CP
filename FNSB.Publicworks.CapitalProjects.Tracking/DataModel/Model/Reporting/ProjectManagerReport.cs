using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class ProjectManagerReport
    {
        public static List<string> ReportFields = new List<string> { "ProjectNumber", "ProjectName", "Secretary", "Manager" };
        public int Id;
        public string ProjectNumber;
        public string ProjectName;
        public Secretary Secretary;
        public ProjectManager Manager;
    }
}
