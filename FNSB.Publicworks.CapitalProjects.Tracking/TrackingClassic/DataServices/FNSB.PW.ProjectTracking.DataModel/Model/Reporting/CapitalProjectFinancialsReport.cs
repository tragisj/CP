using System.Collections.Generic;

namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class CapitalProjectFinancialsReport
    {
        public static List<string> ReportFields = new List<string>
                                                      {
                                                          "OrgKey",
                                                          "OrgKeyName", 
                                                          "Budget",
                                                          "Expenditures",
                                                          "Encumbrances",
                                                          "Balance"
                                                      };

        public int Id { get; set; }
        public string OrgKey { get; set; }
        public string OrgKeyName { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Expenditures { get; set; }
        public decimal? Encumbrances { get; set; }
        public decimal? Balance { get; set; }
    }
}
