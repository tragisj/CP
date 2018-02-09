using System;
using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class ProjectSecretaryReport
    {
        public static List<string> ReportFields = new List<string> { "ProjectNumber", "ProjectName", "Secretary", "Manager", "Architect", "Warrenty" };
        public int Id;
        public string ProjectNumber;
        public string ProjectName;
        public Secretary Secretary;
        public ProjectManager Manager;
        public ArchitectEngineer Architect;
        public DateTime? Warrenty;
    }
}
