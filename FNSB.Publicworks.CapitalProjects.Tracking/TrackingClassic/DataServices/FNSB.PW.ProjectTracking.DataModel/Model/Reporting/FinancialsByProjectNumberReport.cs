using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class FinancialsByProjectNumberReport
    {
        public static List<string> ReportFields = new List<string> { "ProjectNumber", "OrgKey", "OrgKeyName", "ProjectBudget", "ProjectBalance", "ProjectManager", "ProjectSecretary" };
        public int Id;
        public string ProjectNumber;
        public string OrgKey;
        public string OrgKeyName;
        public decimal Budget;
        public decimal Balance;
        public ProjectManager Manager;
        public Secretary Secretary;
        public string ManagerName;
    }
}
