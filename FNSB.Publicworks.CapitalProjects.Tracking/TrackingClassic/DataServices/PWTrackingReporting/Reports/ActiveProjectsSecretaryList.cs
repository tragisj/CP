using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for ActiveProjectsSecretary.
    /// </summary>
    /// 
    public partial class ActiveProjectsSecretaryList : GrapeCity.ActiveReports.SectionReport
    {
        private int _selectId;
        private string _currentSecretary = String.Empty;
        private publicworksEntities _ctx = new publicworksEntities(); //database context object
        private bool _noRecords;
        private IEnumerable<ProjectSecretaryReport> _projects;
        private IList<ProjectSecretaryReport> _projectList;
        private int _count;

        public ActiveProjectsSecretaryList(int secretaryId)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _selectId = secretaryId;

        }

        private void ActiveProjectsSecretaryReportStart(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void ActiveProjectsSecretaryDataInitialize(object sender, EventArgs e)
        {
            //switch check to see if this a single sec report or an all sec report
            switch (_selectId)
            {
                case 0: //all secretaries report

                    _projects = from s in _ctx.Secretaries  //query all secretaries that have active projects
                                from p in s.Projects
                                where p.PPM_Project_Active == true && p.ppm_project_complete == false
                                orderby p.Secretary.firstname, p.PPM_Project_Number
                                select new ProjectSecretaryReport  //query results into reporting class
                                           {
                                               Id = p.PPM_Recordid,
                                               ProjectNumber = p.PPM_Project_Number,
                                               ProjectName = p.PPM_Project_Name,
                                               Manager = p.ProjectManager,
                                               Secretary = p.Secretary,
                                               Architect = p.ArchitectEngineer,
                                               Warrenty = p.NDI_Warranty_Period_Ends
                                           };



                    //convert to list object for looping construct and count extension
                    _projectList = _projects.ToList();
                    var i = _projectList.Count();
                    if (i == 0) //empty query (for the all secretaries this should not happen)
                    {
                        secretaryTitleName.Text = _ctx.Secretaries.Find(_selectId).FullName;
                        this.projectCount.Text = String.Format("{0:G}", 0);
                        _noRecords = true;  //prevents to fetch data from firing
                        return; //exit this method
                    }

                    break;  //exit switch

                default:    //ONE Secretary

                    _projects = from s in _ctx.Secretaries  //active projects for the secretary selected from the sec dialog
                                from p in s.Projects
                                where (p.PPM_Project_Active == true && p.ppm_project_complete == false) && p.PPS_Recordid == _selectId
                                orderby p.Secretary.firstname, p.PPM_Project_Number
                                select new ProjectSecretaryReport()    //results to the sec reporting class
                                        {
                                            Id = p.PPM_Recordid,
                                            ProjectNumber = p.PPM_Project_Number,
                                            ProjectName = p.PPM_Project_Name,
                                            Manager = p.ProjectManager,
                                            Secretary = p.Secretary,
                                            Architect = p.ArchitectEngineer,
                                            Warrenty = p.NDI_Warranty_Period_Ends
                                        };

                    _projectList = _projects.ToList();  //to list for enumeration using index in the fetchdata event
                    var j = _projectList.Count();
                    if (j == 0)
                    {
                        secretaryTitleName.Value = _ctx.Secretaries.Find(_selectId).FullName;   //no active projects for this secretary display
                        this.projectCount.Value = String.Format("{0:G}", 0);
                        _noRecords = true;  //prevent fetch data event fire
                        return; //exit method
                    }

                    break;
            }


            //sec reporting object is used to store query values - I added a static list of field names to make adding custom fields less tedious
            //by using this loop
            foreach (var name in ProjectSecretaryReport.ReportFields)
            {
                Fields.Add(name);
            }
            Fields.Add("ProjectCount"); //field used to count the number of projects and disp. next the user name
        }

        private void ActiveProjectsSecretaryFetchData(object sender, FetchEventArgs eArgs)
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
            Fields[2].Value = String.Format("{0} ({1})", _projectList[_count].Secretary.FullName, _projectList[_count].Secretary.Initials);

            //only perform project count query when the secretary changes
            if ((string)Fields[2].Value != _currentSecretary)
            {
                _currentSecretary = (string)Fields[2].Value;
                Fields[6].Value = _projectList[_count].Secretary.SecretariesProjectCount;
            }

            Fields[3].Value = _projectList[_count].Manager.FullName;
            Fields[4].Value = _projectList[_count].Architect.FullName;

            if (_projectList[_count].Warrenty != null)
            {
                Fields[5].Value = String.Format("{0:d}", _projectList[_count].Warrenty);
            }

            eArgs.EOF = false;  //prevent report from resetting this
            _count++;   //increment  the counter
        }

        private void GroupHeader1Format(object sender, EventArgs e)
        {
            if (_noRecords) return;
            groupHeader1.AddBookmark(Fields["secretary"].Value.ToString());
        }


    }
}

