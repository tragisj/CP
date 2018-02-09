using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{

    
    /// <summary>
    /// Summary description for ActiveProjectsManager.
    /// </summary>
    public partial class ActiveProjectsManagerList : GrapeCity.ActiveReports.SectionReport
    {

        public ActiveProjectsManagerList(int managerId)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _selectId = managerId;
        }

        private int _selectId;
        private string _currentManager = String.Empty;
        private publicworksEntities _ctx = new publicworksEntities(); //database context object
        private bool _noRecords;
        private IEnumerable<ProjectManagerReport> _projects;
        private IList<ProjectManagerReport> _projectList;
        private int _count;

        private void ActiveProjectsManagerDataInitialize(object sender, EventArgs e)
        {
            //switch check to see if this a single sec report or an all sec report
            switch (_selectId)
            {
                case 0: //all secretaries report

                    _projects = from manager in _ctx.ProjectManagers  //query all secretaries that have active projects
                                from project in manager.Projects
                                where project.PPM_Project_Active == true && project.ppm_project_complete == false
                                orderby project.ProjectManager.firstname, project.PPM_Project_Number
                                select new ProjectManagerReport()  //query results into reporting class
                                           {
                                               Id = project.PPM_Recordid,
                                               ProjectNumber = project.PPM_Project_Number,
                                               ProjectName = project.PPM_Project_Name,
                                               Manager = project.ProjectManager,
                                               Secretary = project.Secretary
                                           };

                    //convert to list object for looping construct and count extension
                    _projectList = _projects.ToList();
                    var i = _projectList.Count();
                    if (i == 0) //empty query (for the all secretaries this should not happen)
                    {
                        titleName.Text = _ctx.ProjectManagers.Find(_selectId).FullName;
                        this.projectCount.Text = String.Format("{0:G}", 0);
                        _noRecords = true;  //prevents to fetch data from firing
                        return; //exit this method
                    }

                    break;  //exit switch

                default:    //ONE Secretary

                    _projects = from manager in _ctx.ProjectManagers  //active projects for the secretary selected from the sec dialog
                                from project in manager.Projects
                                where (project.PPM_Project_Active == true && project.ppm_project_complete == false)
                                && project.PPR_Recordid == _selectId
                                orderby project.ProjectManager.firstname, project.PPM_Project_Number
                                select new ProjectManagerReport()    //results to the sec reporting class
                                        {
                                            Id = project.PPM_Recordid,
                                            ProjectNumber = project.PPM_Project_Number,
                                            ProjectName = project.PPM_Project_Name,
                                            Manager = project.ProjectManager,
                                            Secretary = project.Secretary
                                        };

                    _projectList = _projects.ToList();  //to list for enumeration using index in the fetchdata event
                    var j = _projectList.Count();
                    if (j == 0)
                    {
                        managerTitleName.Value = _ctx.ProjectManagers.Find(_selectId).FullName;   //no active projects for this secretary display
                        this.projectCount.Value = String.Format("{0:G}", 0);
                        _noRecords = true;  //prevent fetch data event fire
                        return; //exit method
                    }

                    break;
            }


            //sec reporting object is used to store query values - I added a static list of field names to make adding custom fields less tedious
            //by using this loop
            foreach (var name in ProjectManagerReport.ReportFields)
            {
                Fields.Add(name);
            }
            Fields.Add("ProjectCount"); //field used to count the number of projects and disp. next the user name
        }

        private void ActiveProjectsManagerFetchData(object sender, FetchEventArgs eArgs)
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
            Fields[2].Value = String.Format("{0}", _projectList[_count].Secretary.FullName);
            Fields[3].Value = _projectList[_count].Manager.FullName;

            //only perform project count query when the secretary changes
            //if ((string)Fields[3].Value != _currentManager)
            //{
            //    _currentManager = (string)Fields[3].Value;
            //    Fields[4].Value = _projectList[_count].Manager.ActiveProjectCount;
            //}

            eArgs.EOF = false;  //prevent report from resetting this
            _count++;   //increment  the counter
        }

        private void GroupHeader1Format(object sender, EventArgs e)
        {
            if (_noRecords) return;
            groupHeader1.AddBookmark(Fields["manager"].Value.ToString());
        }
    }
    
}
