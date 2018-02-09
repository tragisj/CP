using System;
using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class SubstantialCompletionReport
    {
        public static List<string> ReportFields = new List<string> { "SubstantialCompletion", "ProjectNumber", "ProjectName",  "ProjectManager", "ProjectStatus" };
        public int Id;
        public DateTime? SubstantialCompletion;
        public string ProjectNumber;
        public string ProjectName;
        public ProjectManager Manager;
        public bool? ProjectStatus;
    }
}
