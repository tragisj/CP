using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Model.Reporting;
using PWTrackingReporting.Reports.UI;

namespace FNSB.Publicworks.Projects.Reporting.Reports.Financials
{
    /// <summary>
    /// Summary description for FinancialReportbyProjectNumber.
    /// </summary>
    public partial class FinancialReportbyProjectNumber : GrapeCity.ActiveReports.SectionReport
    {

        private publicworksEntities _ctx = new publicworksEntities(); //database context object
        private bool _noRecords;
        private IEnumerable<FinancialsByProjectNumberReport> _projects;
        private IList<FinancialsByProjectNumberReport> _projectList;
        private int _count;
        private DateRangeDialog _dialog;

        public FinancialReportbyProjectNumber()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }


        private void FinancialsByProjectNumberReportStart(object sender, EventArgs e)
        {
            try
            {

                _ctx.Configuration.LazyLoadingEnabled = false;

                //dialog box displays the entity to choose from and passes the variables
                _dialog = new DateRangeDialog();
                _dialog.ShowDialog(); //pop the dialog
                if (_dialog.SelectionCancel) Cancel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void FinancialsByProjectNumberDataInitialize(object sender, EventArgs e)
        {

            _projects = from p in _ctx.Projects
                        from f in _ctx.Funds
                        where
                            p.PPM_Project_Active == true && p.PPM_Active_Date > _dialog.StartDate &&
                            p.PPM_Active_Date < _dialog.EndDate && f.ppm_recordid == p.PPM_Recordid
                        select new FinancialsByProjectNumberReport //query results into reporting class
                                   {
                                       Id = p.PPM_Recordid,
                                       ProjectNumber = p.PPM_Project_Number,
                                       OrgKey = f.ppf_glkey,
                                       OrgKeyName = f.ppf_glkey_name,
                                       Budget = (decimal)f.ppf_budget,
                                       Balance = (decimal)f.ppf_balance,
                                       Manager = p.ProjectManager,
                                       Secretary = p.Secretary
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
            foreach (var name in FinancialsByProjectNumberReport.ReportFields)
            {
                Fields.Add(name);
            }
        }

        private void FinancialsByProjectNumberFetchData(object sender, FetchEventArgs eArgs)
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
            Fields[1].Value = _projectList[_count].OrgKey;
            Fields[2].Value = _projectList[_count].OrgKeyName;
            Fields[3].Value = _projectList[_count].Budget;
            Fields[4].Value = _projectList[_count].Balance;
            Fields[5].Value = _projectList[_count].Manager.FullName;
            Fields[6].Value = _projectList[_count].Secretary.Initials;

            eArgs.EOF = false; //prevent report from resetting this
            _count++; //increment  the counter
        }
    }
}

