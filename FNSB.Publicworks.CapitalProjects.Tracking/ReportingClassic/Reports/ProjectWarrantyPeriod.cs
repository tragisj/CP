using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using GrapeCity.ActiveReports.Data;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for ProjectWarrentyPeriod.
    /// </summary>
    public partial class ProjectWarrantyPeriod : GrapeCity.ActiveReports.SectionReport
    {
        private publicworksEntities _db = new publicworksEntities();
        private List<Project> _projects;
        private Int32 _projectCount;
        private DateTime _startDefault;
        private DateTime _endDefault;
        private Field _fieldProjectManager;
        private const string TitleLabel = "Correction Period";


        public ProjectWarrantyPeriod(DateTime startTime, DateTime endTime)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _startDefault = startTime;
            _endDefault = endTime;
        }


        private void ProjectWarrentyPeriodDataInitialize(object sender, EventArgs e)
        {

            _projects = _db.Projects.Where(s => s.NDI_Warranty_Period_Ends >= _startDefault && s.NDI_Warranty_Period_Ends <= _endDefault && s.PPM_Project_Active == true)
                .OrderBy(s => s.NDI_Warranty_Period_Ends).ToList();

            DataSource = _projects;

            titleLabel.Text = String.Format("{0} {1} - {2}", TitleLabel, _startDefault.ToShortDateString(), _endDefault.ToShortDateString());

            //Init custom fields to use in Fetchdata routing to shape
            _fieldProjectManager = new Field { FieldType = FieldTypeEnum.String, Name = "fieldProjectManager" };
            projectManagerText.DataField = _fieldProjectManager.Name;
            Fields.Add(_fieldProjectManager);

            projectNameText.DataField = "ppm_project_name";
            projectNoText.DataField = "ppm_project_number";
            warrantyDateText.DataField = "ndi_warranty_period_ends";
            statusCheckbox.DataField = "ppm_project_active";
        }


        private void ProjectWarrantyPeriodFetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF) return;
            if (_projects[_projectCount].ProjectManager != null)
            {
                _fieldProjectManager.Value = String.Format("{0} {1}", _projects[_projectCount].ProjectManager.firstname,
                    _projects[_projectCount].ProjectManager.lastname);
            }
            _projectCount++;
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }
    }
}
