using System;
using System.Collections.Generic;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;

namespace FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects
{
    /// <summary>
    /// Summary description for IndexByProject.
    /// </summary>
    public partial class IndexByProject : GrapeCity.ActiveReports.SectionReport
    {

        private readonly List<CapitalProjectsIndexByProject> _projects;
        private publicworksEntities _ctx = new publicworksEntities();   //database context object
        private int _count;
        private bool _noRecords;

        public IndexByProject(List<CapitalProjectsIndexByProject> dictionary)
        {
            //move incoming dictionary to local resource
            _projects = dictionary;
            if (_projects.Count == 0) _noRecords = true;

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void PageHeaderFormat(object sender, EventArgs e)
        {
        }


        private void IndexByProjectReportStart(object sender, EventArgs e)
        {
        }


        private void IndexByProjectDataInitialize(object sender, EventArgs e)
        {
            foreach (var field in CapitalProjectsIndexByProject.ReportFields)
            {
                Fields.Add(field);
            }


        }


        private void IndexByProjectFetchData(object sender, FetchEventArgs eArgs)
        {

            //this reporting is not databound so I control the EOF flag
            //the EOF flag is set if the sec selected does not have active projects or the list has been iterated to the last record
            if (_count == _projects.Count || _noRecords)
            {
                eArgs.EOF = true;
                return;
            }
            //Fields Assignments
            Fields[0].Value = _projects[_count].ProjectNumber;
            Fields[1].Value = _projects[_count].PageNumber;
            Fields[2].Value = _projects[_count].ProjectName;
            Fields[3].Value = _projects[_count].ProjectManager;
            Fields[4].Value = _projects[_count].ProjectArchitectEngineer;

            eArgs.EOF = false;  //prevent report from resetting this
            _count++;   //increment  the counter

        }





    }
}
