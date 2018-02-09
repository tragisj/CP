using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;
using GrapeCity.ActiveReports.Data;

namespace FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects
{
    /// <summary>
    /// StatusReportSummaryManager is 
    /// </summary>
    public partial class StatusReportSummaryManager : GrapeCity.ActiveReports.SectionReport
    {
        private List<ManagerSummary> _summaryData;
        private StatusReportSummaryManager _reportSummary;
        private publicworksEntities _db; //database context object
        private decimal _totalAllocation;
        private decimal _totalAmountComplete;
        private Field _allocation;
        private Field _current;

        public StatusReportSummaryManager()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        //First event to Fire - init variables for use in the report including subreport assignments
        private void StatusReportSummaryManagerReportStart(object sender, EventArgs e)
        {

            _summaryData = new List<ManagerSummary>();
            _db = new publicworksEntities();

            //allocation field sums the allocated amount
            _allocation = new Field
                              {
                                  FieldType = FieldTypeEnum.String,
                                  DefaultValue = String.Format("c"),
                                  Name = "allocation"
                              };

            //current field sums the remaining total budget
            _current = new Field
            {
                FieldType = FieldTypeEnum.String,
                DefaultValue = String.Format("c"),
                Name = "current"
            };
        }

        //Second event to fire - use to set datasource and add custom fields
        private void StatusReportSummaryManagerDataInitialize(object sender, EventArgs e)
        {
            
            //LINQ query to group manager funding totals on the managers first name value
            //and selecting only active projects
            var managerSummary = from f in _db.Funds
                                 where f.Project.PPM_Project_Active == true
                                 group f by f.Project.ProjectManager
                                     into m
                                     orderby m.Key.ppr_recordid
                                     select new
                                         {
                                             Manager = m.Key,    //manager firstname
                                             Funds = m           //funding records (from active projects)
                                         };


            var i = 0;

            
            //loop the query results and use the class ManagerSummary to store the results
            //and place them in the _summaryData List<ManagerSummary>
            foreach (var item in managerSummary)
            {
                i += item.Manager.Projects.Count();

                ManagerSummary s = new ManagerSummary();
                int ct = item.Manager.ActiveProjectCount;
                var enc = item.Funds.Sum(c => c.ppf_encumbrances);  //total encumbrances
                var exp = item.Funds.Sum(x => x.ppf_expenditures);  //total expenditures
                var bud = item.Funds.Sum(b => b.ppf_budget);        //total budget
                s.ManagerName = item.Manager.FullName;
                s.Count = ct;
                s.AmountComplete = bud - (exp + enc);   //
                s.TotalAllocation = bud;
                _summaryData.Add(s);
            }

            //load the _summaryData list into the datasource
            DataSource = _summaryData.ToList();
        }

    }
}
