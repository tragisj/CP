using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;
using FNSB.Publicworks.Projects.Model.Reporting;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.SectionReportModel;
using PWTrackingReporting.Reports.CapitalProjects;

namespace FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects
{
    /// <summary>
    /// ProjectStatusReport is a required report for the audit and is requested by the
    /// Accounting Dept annually
    /// </summary>
    public partial class ProjectStatusReport : GrapeCity.ActiveReports.SectionReport
    {

        private bool _noRecords;
        private int _count;

        public List<CapitalProjectsIndexByProject> ProjectIndexList;

        private readonly publicworksEntities _db = new publicworksEntities(); //database context object
        private IEnumerable<CapitalProjectsReport> _projects;
        private IList<CapitalProjectsReport> _projectList;
        private CapitalProjectsFinancing _capitalFin;
 
        public ProjectStatusReport()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void ProjectStatusReportReportStart(object sender, EventArgs e)
        {
            //wire the event handler for the page end routine
            PageEnd += OnPageEnd;


            //used to generate the IndexByProject Report inserted before the main report generated below. 
            //It's a enhanced table of contents for the report reader
            ProjectIndexList = new List<CapitalProjectsIndexByProject>();

            //financial details report - fired as a subreport.
            _capitalFin = new CapitalProjectsFinancing();

            //loops CapitalProjectFinancialsReport helper class to get fields for using in subreport
            foreach (var reportField in CapitalProjectFinancialsReport.ReportFields)
            {
                _capitalFin.Fields.Add(reportField);       //subreport fields loaded
            }

            //load the subreport control with the capital projects report
            financeSubReport.Report = _capitalFin;
        }

        /// <summary>
        /// Inits the query, executes as LINQ, and sets-up the fields for custom use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Not using the datasource provided by the report here. Fetch event controls flow</remarks>
        private void ProjectStatusReportDataInitialize(object sender, EventArgs e)
        {
            _projects = from project in _db.Projects  //active projects for the secretary selected from the sec dialog
                        where project.PPM_Project_Active == true
                        orderby project.PPM_Project_Number
                        select new CapitalProjectsReport    //results to the sec reporting class
                        {
                            Id = project.PPM_Recordid,
                            ProjectNumber = project.PPM_Project_Number,
                            ProjectName = project.PPM_Project_Name,
                            ProjectManager = project.ProjectManager,
                            ArchitectEngineer = project.ArchitectEngineer,
                            Secretary = project.Secretary,
                            Consultant = project.Consultant,
                            Contractor = project.Contractor,
                            IfbRfq = project.PPM_IFB_RFQ,
                            DesignPercentComplete = project.PPM_Per_Des_Complete,
                            DesignComplete = project.NDI_Design_Complete,
                            BidOpening = project.NDI_Bid_Opening,
                            ConstructionPercentComplete = project.PPM_Per_Const_Complete,
                            Ntp = project.NDI_NTP,
                            SubstantialCompletion = project.NDI_Substantial_Completion,
                            WarrentyPeriodEnds = project.NDI_Warranty_Period_Ends,
                            Closed = project.NDI_Closed,
                            CurrentStatus = project.PPM_Status_Desc,
                            Funds = project.Funds
                        };

            //prevent fetch data event fire
            if (!_projects.Any()) _noRecords = true;

            //loads the CapitalProjectsReports class List with results from the query
            _projectList = _projects.ToList();

            //use the CapitalProjectsReport field array to setup the fields for the parent report
            foreach (var reportField in CapitalProjectsReport.ReportFields)
            {
                Fields.Add(reportField);
            }
        }

        //FetchData fires until eArgs.EOF is set to true when there is no 
        //DataSource databound to the report
        private void ProjectStatusReportFetchData(object sender, FetchEventArgs eArgs)
        {
            //managing the EOF by checking counter to list count or _norecords bool
            if (_count == _projectList.Count() || _noRecords)
            {
                eArgs.EOF = true;
                return;
            }

            //plug data into fields
            Fields[0].Value = _projectList[_count].ProjectName;
            Fields[1].Value = _projectList[_count].ProjectNumber;

            Fields[2].Value = _projectList[_count].ProjectManager.FullName;
            Fields[3].Value = _projectList[_count].ArchitectEngineer.FullName;
            Fields[4].Value = _projectList[_count].Secretary.FullName;
            Fields[5].Value = _projectList[_count].Consultant.consultantname;
            Fields[6].Value = _projectList[_count].Contractor.contractorname;
            Fields[7].Value = _projectList[_count].IfbRfq;
            Fields[8].Value = _projectList[_count].DesignPercentComplete;
            Fields[9].Value = _projectList[_count].DesignComplete;
            Fields[10].Value = _projectList[_count].BidOpening;
            Fields[11].Value = _projectList[_count].ConstructionPercentComplete;
            Fields[12].Value = _projectList[_count].Ntp;
            Fields[13].Value = _projectList[_count].SubstantialCompletion;
            Fields[14].Value = _projectList[_count].WarrentyPeriodEnds;
            Fields[15].Value = _projectList[_count].Closed;
            Fields[16].Value = _projectList[_count].CurrentStatus;

            Fields[17].Value = _projectList[_count].Funds.Sum(bud => bud.ppf_budget);
            Fields[18].Value = _projectList[_count].Funds.Sum(exp => exp.ppf_expenditures);
            Fields[19].Value = _projectList[_count].Funds.Sum(enc => enc.ppf_encumbrances);
            Fields[20].Value = _projectList[_count].Funds.Sum(bal => bal.ppf_balance);



            var funds = from f in _projectList[_count].Funds.OrderBy(f => f.ppf_glkey)
                        select new CapitalProjectFinancialsReport
                                   {
                                       Balance = f.ppf_balance,
                                       Budget = f.ppf_budget,
                                       OrgKey = f.ppf_glkey,
                                       OrgKeyName = f.ppf_glkey_name,
                                       Encumbrances = f.ppf_encumbrances,
                                       Expenditures = f.ppf_expenditures
                                   };

            //enumerate funds data to an array
            var financialsReportData = funds as List<CapitalProjectFinancialsReport> ?? funds.ToList();
            if (financialsReportData.Any())
                _capitalFin.DataSource = financialsReportData.ToList();


            if (financialsReportData.Count > 8)
            {
                detail.NewPage = NewPage.After;
                eArgs.EOF = false;
                _count += 2;    //keeps the pages to 2 entries per page when page breaking for large records
                return;
            }


            detail.NewPage = NewPage.None;
            eArgs.EOF = false;
            _count++;
            int pageCount;

            Math.DivRem(_count, 2, out pageCount);
            pageBreakDetail.Enabled = pageCount != 1;

        }


        private void DetailFormat(object sender, EventArgs e)
        {

            //prolist used to generate "Index By Project"
            var prolist = new CapitalProjectsIndexByProject
            {
                ProjectNumber = Fields[1].Value.ToString(),
                ProjectName = Fields[0].Value.ToString(),
                PageNumber = PageNumber,
                ProjectArchitectEngineer = Fields[3].Value.ToString(),
                ProjectManager = Fields[2].Value.ToString()
            };


            ProjectIndexList.Add(prolist);


            var bk = new Bookmark { Label = Fields[1].Value.ToString(), PageNumber = PageNumber };
            this.Document.Bookmarks.Add(bk);
        }


        private void OnPageEnd(object sender, EventArgs eventArgs)
        {
            if (pageBreakDetail.Enabled)
            {
                pageBreakDetail.Enabled = false;
            }
        }
        
        private void ProjectStatusReportReportEnd(object sender, EventArgs e)
        {
            var index = new IndexByProject(ProjectIndexList.OrderBy(d => d.ProjectNumber).ToList());
            index.Run();

            this.Document.Pages.InsertRange(0, index.Document.Pages);

        }





    }
}
