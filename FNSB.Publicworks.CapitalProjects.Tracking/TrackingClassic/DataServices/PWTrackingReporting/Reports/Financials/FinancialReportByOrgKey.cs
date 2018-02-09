using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.Reporting.Reports.Financials
{
    /// <summary>
    /// Summary description for FinancialReportByOrgKey.
    /// </summary>
    public partial class FinancialReportByOrgKey : GrapeCity.ActiveReports.SectionReport
    {
        private int _pi;
        private publicworksEntities _context = new publicworksEntities();
        private List<Fund> _projectfunds;

        public FinancialReportByOrgKey()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void FinancialReportByOrgKeyReportStart(object sender, EventArgs e)
        {

        }

        private void FinancialReportByOrgKeyDataInitialize(object sender, EventArgs e)
        {
            //query the database and set datasource
            try
            {
                _projectfunds = _context.Funds.Where(f => f.Project.PPM_Project_Active == true).OrderBy(f => f.ppf_funding).ThenBy(k => k.ppf_glkey).ToList();
                DataSource = _projectfunds;

                Fields.Add("fund");             // 0
                Fields.Add("glkey");            // 1
                Fields.Add("projectno");        // 2  
                Fields.Add("glkeyname");        // 3
                Fields.Add("balance");          // 4
                Fields.Add("manager");          // 5
                Fields.Add("secretary");        // 6

                fund.DataField = "fund";
                orgKey.DataField = "glkey";
                projectNumber.DataField = "projectno";
                orgKeyLong.DataField = "glkeyname";
                balance.DataField = "balance";
                manager.DataField = "manager";
                secretary.DataField = "secretary";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FinancialReportByOrgKeyFetchData(object sender, FetchEventArgs eArgs)
        {
            //executes each iteration of the datasource
            //while (!eArgs.EOF)
            if (eArgs.EOF) return;
            Fields["fund"].Value = _projectfunds[_pi].ppf_funding;
            Fields["glkey"].Value = _projectfunds[_pi].ppf_glkey;
            Fields["projectno"].Value = _projectfunds[_pi].Project.PPM_Project_Number;
            Fields["glkeyname"].Value = _projectfunds[_pi].ppf_glkey_name;
            Fields["balance"].Value = _projectfunds[_pi].ppf_balance;
            Fields["manager"].Value = _projectfunds[_pi].Project.ProjectManager.FullName;
            Fields["secretary"].Value = _projectfunds[_pi].Project.Secretary.Initials;
            _pi++;
        }
    }
}
