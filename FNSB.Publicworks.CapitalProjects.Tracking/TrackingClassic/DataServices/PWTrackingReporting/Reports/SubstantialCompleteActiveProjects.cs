using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for SubstantialCompleteActiveProjects.
    /// </summary>
    public partial class SubstantialCompleteActiveProjects : GrapeCity.ActiveReports.SectionReport
    {
        private publicworksEntities _db = new publicworksEntities(); //database context object
        private bool _noRecords;
        private IEnumerable<SubstantialCompletionReport> _projects;
        private List<SubstantialCompletionReport> _projectList;
        private int _count;
        private DateTime _startDate;
        private DateTime _endDate;

        public SubstantialCompleteActiveProjects(DateTime startDate, DateTime endDate)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
        }

        private void SubstantialCompletionDataInitialize(object sender, EventArgs e)
        {

            _projects = from p in _db.Projects
                        where
                            p.PPM_Project_Active == true && p.NDI_Substantial_Completion > _startDate &&
                            p.NDI_Substantial_Completion < _endDate
                        orderby p.NDI_Substantial_Completion
                        select new SubstantialCompletionReport //query results into reporting class
                                   {
                                       Id = p.PPM_Recordid,
                                       SubstantialCompletion = p.NDI_Substantial_Completion,
                                       ProjectNumber = p.PPM_Project_Number,
                                       ProjectName = p.PPM_Project_Name,
                                       Manager = p.ProjectManager,
                                       ProjectStatus = p.PPM_Project_Active
                                   };

            //convert to list object for looping construct and count extension
            _projectList = _projects.ToList();
            var i = _projectList.Count();
            if (i == 0) //empty query (for the all secretaries this should not happen)
            {
                _noRecords = true; //prevents to fetch data from firing
                return; //exit this method
            }

            //sec reporting object is used to store query values - I added a static list of field names to make adding custom fields less tedious
            //by using this loop
            foreach (var name in SubstantialCompletionReport.ReportFields)
            {
                Fields.Add(name);
            }
        }

        private void SubstantialCompletionFetchData(object sender, FetchEventArgs eArgs)
        {

            //this reporting is not databound so I control the EOF flag
            //the EOF flag is set if the sec selected does not have active projects or the list has been iterated to the last record
            if (_count == _projectList.Count() || _noRecords)
            {
                eArgs.EOF = true;
                return;
            }

            //fields were added in dataint event and are loaded with values from the iterated list in this section 
            Fields[0].Value = _projectList[_count].SubstantialCompletion;
            Fields[1].Value = _projectList[_count].ProjectNumber;
            Fields[2].Value = _projectList[_count].ProjectName;
            Fields[3].Value = _projectList[_count].Manager.FullName;
            Fields[4].Value = _projectList[_count].ProjectStatus;
            eArgs.EOF = false; //prevent report from resetting this
            _count++; //increment  the counter
        }
    }
}
