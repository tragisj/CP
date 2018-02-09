using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for ProjectsClosed.
    /// </summary>
    public partial class ProjectsClosed : GrapeCity.ActiveReports.SectionReport
    {
        public ProjectsClosed(DateTime startDate, DateTime endDate)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
        }

        private bool _noRecords;

        private int _selectId;
        private int _count;
        private DateTime _endDate;
        private DateTime _startDate;
        private publicworksEntities _ctx = new publicworksEntities(); //database context object
        private IEnumerable<ProjectsClosedReport> _projects;
        private IList<ProjectsClosedReport> _projectList;



        private void ClosedProjectsDataInitialize(object sender, EventArgs e)
        {
            _projects = from p in _ctx.Projects
                        //query all secretaries that have active projects
                        where
                            p.PPM_Project_Active == false && p.PPM_Inactive_Date > _startDate &&
                            p.PPM_Inactive_Date < _endDate
                        orderby p.NDI_Closed
                        select new ProjectsClosedReport() //query results into reporting class
                                   {
                                       Id = p.PPM_Recordid,
                                       ProjectNumber = p.PPM_Project_Number,
                                       ProjectName = p.PPM_Project_Name,
                                       Fund = p.Funds,
                                       Inactived = p.PPM_Inactive_Date,
                                       ProjectClosed = p.NDI_Closed,
                                       WarrentyEnd = p.NDI_Warranty_Period_Ends
                                   };

            //convert to list object for looping construct and count extension
            _projectList = _projects.ToList();
            var i = _projectList.Count();
            if (i == 0) //empty query (for the all secretaries this should not happen)
            {
                projectCountText.Text = String.Format("{0:G}", _projectList.Count);
                _noRecords = true; //prevents to fetch data from firing
                return; //exit this method
            }

            _projectList = _projects.ToList(); //to list for enumeration using index in the fetchdata event
            var j = _projectList.Count();
            if (j == 0)
            {
                projectCountText.Value = String.Format("{0:G}", _projectList.Count);
                _noRecords = true; //prevent fetch data event fire
                return; //exit method
            }

            //sec reporting object is used to store query values - I added a static list of field names to make adding custom fields less tedious
            //by using this loop
            foreach (var name in ProjectsClosedReport.ReportFields)
            {
                Fields.Add(name);
            }

            Fields.Add("DateRange");
            Fields.Add("ProjectCount"); //field used to count the number of projects and disp. next the user name

            Fields["DateRange"].Value = String.Format("{0} - {1}", _startDate.ToShortDateString(), _endDate.ToShortDateString());
            Fields["ProjectCount"].Value = _projectList.Count.ToString(CultureInfo.InvariantCulture);
        }


        private void ClosedProjectsFetchData(object sender, FetchEventArgs eArgs)
        {
            //this reporting is not databound so I control the EOF flag
            //the EOF flag is set if the sec selected does not have active projects or the list has been iterated to the last record
            if (_count == _projectList.Count() || _noRecords)
            {
                eArgs.EOF = true;
                return;
            }

            //fields were added in dataint event and are loaded with values from the iterated list in this section 
            Fields[0].Value = _projectList[_count].ProjectClosed;
            Fields[1].Value = _projectList[_count].Inactived;
            Fields[2].Value = _projectList[_count].WarrentyEnd;
            Fields[3].Value = _projectList[_count].ProjectNumber;
            Fields[4].Value = _projectList[_count].ProjectName;
            Fields[5].Value = _projectList[_count].Fund.Sum(a => a.ppf_budget);
            Fields[6].Value = _projectList[_count].Fund.Sum(a => a.ppf_expenditures);

            eArgs.EOF = false;  //prevent report from resetting this
            _count++;   //increment  the counter
        }
    }
}