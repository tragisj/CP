using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for ActiveProjectsManager.
    /// </summary>
    public partial class ActiveProjectsManager : GrapeCity.ActiveReports.SectionReport
    {

        private bool _noRecords;

        private decimal _balanceTotal;
        private decimal _budgetTotal;

        private int _groupCount;
        private int _count;
        private int _selectId;

        private string _currentManager = String.Empty;

        private publicworksEntities _ctx = new publicworksEntities(); //database context object
        private IEnumerable<ProjectActiveDetailReport> _projects;
        private IList<ProjectActiveDetailReport> _projectList;


        public ActiveProjectsManager(int managerId)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _selectId = managerId;
        }

        private void ActiveProjectsManagerDataInitialize(object sender, EventArgs e)
        {
            //switch check to see if this a single sec report or an all sec report
            switch (_selectId)
            {
                case 0: //all architect report

                    _projects = from projectManager in _ctx.ProjectManagers  //query all secretaries that have active projects
                                from project in projectManager.Projects
                                where project.PPM_Project_Active == true && project.ppm_project_complete == false
                                orderby project.ProjectManager.lastname, project.PPM_Project_Number
                                select new ProjectActiveDetailReport()  //query results into reporting class
                                              {
                                                  Id = project.PPM_Recordid,
                                                  ProjectNumber = project.PPM_Project_Number,
                                                  ProjectName = project.PPM_Project_Name,
                                                  ProjectManager = project.ProjectManager,
                                                  ArchitectEngineer = project.ArchitectEngineer,
                                                  Secretary = project.Secretary,
                                                  DesignComplete = project.PPM_Per_Des_Complete,
                                                  AdvertiseBid = project.NDI_Advertise_for_Bid,
                                                  BidOpening = project.NDI_Bid_Opening,
                                                  ConstructionPercentComplete = project.PPM_Per_Const_Complete,
                                                  SubstantialCompletion = project.NDI_Substantial_Completion,
                                                  WarrentyPeriodEnds = project.NDI_Warranty_Period_Ends,
                                                  Funds = project.Funds
                                              };

                    //convert to list object for looping construct and count extension
                    _projectList = _projects.ToList();
                    var i = _projectList.Count();

                    if (i == 0) //empty query (for the all architects this should not happen)
                    {
                        managerHeaderText.Text = _ctx.ProjectManagers.Find(_selectId).FullName;
                        this.projectCount.Text = String.Format("{0:G}", 0);
                        _noRecords = true;  //prevents to fetch data from firing
                        return; //exit this method
                    }

                    break;  //exit switch

                default:    //ONE ProjectManager

                    _projects = from projectManager in _ctx.ProjectManagers  //active projects for the secretary selected from the sec dialog
                                from project in projectManager.Projects
                                where project.PPM_Project_Active == true && project.ppm_project_complete == false 
                                    && project.PPR_Recordid == _selectId
                                orderby project.ProjectManager.lastname, project.PPM_Project_Number
                                select new ProjectActiveDetailReport()    //results to the sec reporting class
                                         {
                                             Id = project.PPM_Recordid,
                                             ProjectNumber = project.PPM_Project_Number,
                                             ProjectName = project.PPM_Project_Name,
                                             ProjectManager = project.ProjectManager,
                                             ArchitectEngineer = project.ArchitectEngineer,
                                             Secretary = project.Secretary,
                                             DesignComplete = project.PPM_Per_Des_Complete,
                                             AdvertiseBid = project.NDI_Advertise_for_Bid,
                                             BidOpening = project.NDI_Bid_Opening,
                                             ConstructionPercentComplete = project.PPM_Per_Const_Complete,
                                             SubstantialCompletion = project.NDI_Substantial_Completion,
                                             WarrentyPeriodEnds = project.NDI_Warranty_Period_Ends,
                                             Funds = project.Funds
                                         };

                    _projectList = _projects.ToList();  //to list for enumeration using index in the fetchdata event
                    var j = _projectList.Count();

                    if (j == 0)
                    {
                        managerHeaderText.Value = _ctx.ProjectManagers.Find(_selectId).FullName;   //no active projects for this secretary display
                        this.projectCount.Value = String.Format("{0:G}", 0);
                        _noRecords = true;  //prevent fetch data event fire
                        return; //exit method
                    }

                    break;
            }


            //sec reporting object is used to store query values - I added a static list of field names to make adding custom fields less tedious
            //by using this loop
            foreach (var name in ProjectActiveDetailReport.ReportFields)
            {
                Fields.Add(name);
            }
            Fields.Add("ProjectCount"); //field used to count the number of projects and disp. next the user name
        }

        private void ActiveProjectManagersFetchData(object sender, FetchEventArgs eArgs)
        {
            //this reporting is not databound so I control the EOF flag
            //the EOF flag is set if the sec selected does not have active projects or the list has been iterated to the last record
            if (_count == _projectList.Count() || _noRecords)
            {
                eArgs.EOF = true;
                return;
            }

            //fields were added in dataint event and are loaded with values from the iterated list in this section 
            Fields[0].Value = _projectList[_count].ProjectNumber;
            Fields[1].Value = _projectList[_count].ProjectName;
            Fields[2].Value = _projectList[_count].ProjectManager.FullName;
            Fields[3].Value = _projectList[_count].ArchitectEngineer.FullName;
            Fields[4].Value = _projectList[_count].Secretary.Initials;
            Fields[5].Value = _projectList[_count].DesignComplete;
            Fields[6].Value = _projectList[_count].AdvertiseBid;
            Fields[7].Value = _projectList[_count].BidOpening;
            Fields[8].Value = _projectList[_count].ConstructionPercentComplete;
            Fields[9].Value = _projectList[_count].SubstantialCompletion;
            Fields[10].Value = _projectList[_count].WarrentyPeriodEnds;
            Fields[11].Value = _projectList[_count].Funds.ToList().Sum(b => b.ppf_budget);
            Fields[12].Value = _projectList[_count].Funds.ToList().Sum(b => b.ppf_balance);
            eArgs.EOF = false;  //prevent report from resetting this
            _count++;   //increment  the counter
        }

        private void GroupHeader1Format(object sender, EventArgs e)
        {
            if (_noRecords) return;

            var id = _projectList[_count].ProjectManager.ppr_recordid;

            _groupCount = _ctx.ProjectManagers.Find(id).Projects.Count(a => a.PPM_Project_Active == true);

            _budgetTotal = (decimal)_ctx.ProjectManagers.Find(id).Projects.Where(a => a.PPM_Project_Active == true).ToList().Sum(
                    f => f.Funds.ToList().Sum(d => d.ppf_budget));

            _balanceTotal = (decimal)_ctx.ProjectManagers.Find(id).Projects.Where(a => a.PPM_Project_Active == true).ToList().Sum(
                    f => f.Funds.ToList().Sum(d => d.ppf_balance));

            projectCount.Value = _groupCount;
            budgetTotalText.Value = _budgetTotal.ToString(CultureInfo.InvariantCulture);
            balanceTotalText.Value = _balanceTotal.ToString(CultureInfo.InvariantCulture);
            groupHeader1.AddBookmark(Fields[2].Value.ToString());
        }
    }
}

