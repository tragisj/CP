using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects
{
    /// <summary>
    /// Summary description for StatusReportSummaryProjectType.
    /// </summary>
    public partial class StatusReportSummaryProjectType : GrapeCity.ActiveReports.SectionReport
    {
        private List<ProjectTypeSummary> _summaryData;
        private publicworksEntities _db = new publicworksEntities(); //database context object

        public StatusReportSummaryProjectType()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void StatusReportSummaryProjectTypeFetchData(object sender, FetchEventArgs eArgs)
        {

        }

        private void StatusReportSummaryProjectTypeDataInitialize(object sender, EventArgs e)
        {

            //LINQ query to group type funding totals on the project category value
            //and selecting only active projects
            var protypeSummary = from f in _db.Funds
                where f.Project.PPM_Project_Active == true
                group f by f.Project.ProjectType
                into m
                orderby m.Key.category
                select new
                {
                    Type = m.Key, //project type
                    Funds = m //funding records (from active projects)
                };




            if (protypeSummary.Any()) _summaryData = new List<ProjectTypeSummary>();

            //loop the query results and use the class ManagerSummary to store the results
            //and place them in the _summaryData List<ManagerSummary>
            foreach (var item in protypeSummary)
            {
                if (item.Type != null)
                {
                    var s = new ProjectTypeSummary();
                    int ct = item.Type.ActiveProjectCount;
                    var enc = item.Funds.Sum(c => c.ppf_encumbrances); //total encumbrances
                    var exp = item.Funds.Sum(x => x.ppf_expenditures); //total expenditures
                    var bud = item.Funds.Sum(b => b.ppf_budget); //total budget
                    s.ProjectType = item.Type.category;
                    s.Count = ct;
                    s.AmountComplete = bud - (exp + enc); //
                    s.TotalAllocation = bud;
                    _summaryData.Add(s);
                }
                else
                {
                    var r = "im here";
                }


                //load the _summaryData list into the datasource
                DataSource = _summaryData.ToList();

            }

        }

    }
}
