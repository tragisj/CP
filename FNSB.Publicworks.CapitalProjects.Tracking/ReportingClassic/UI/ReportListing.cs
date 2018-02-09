using System;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.DataLayer.Service;
using FNSB.Publicworks.Projects.Reporting.Reports;
using FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects;
using FNSB.Publicworks.Projects.Reporting.Reports.Financials;
using FNSB.Publicworks.Projects.Reporting.Reports.UI;
using FNSB.Publicworks.Projects.Reports.UI;
using GrapeCity.ActiveReports;
using PWTrackingReporting.Reports;
using PWTrackingReporting.Reports.CapitalProjects;
using PWTrackingReporting.Reports.UI;
using PWTrackingReporting.UI;
using ArchitectEngineer = FNSB.Publicworks.Projects.Reports.UI.ArchitectEngineer;
using Consultant = FNSB.Publicworks.Projects.Reports.UI.Consultant;
using Contractor = FNSB.Publicworks.Projects.Reports.UI.Contractor;
using ProjectManager = FNSB.Publicworks.Projects.Reports.UI.ProjectManager;
using ProjectType = FNSB.Publicworks.Projects.Reports.UI.ProjectType;

namespace FNSB.Publicworks.Projects.Reporting.UI
{
    public partial class FReportListing : Form
    {


        private publicworksEntities _ctx = new publicworksEntities(); //database context object

        private PWTrackingReporting.UI.ReportProjectQuery _queryForm;
        public FReportListing()
        {
            InitializeComponent();
        }

        #region EntityCRUDForms


        private void Button1Click(object sender, EventArgs e)
        {
            ArchitectEngineer architect = new ArchitectEngineer { WindowState = FormWindowState.Normal };
            architect.Show();
        }

        private void FReportListingLoad(object sender, EventArgs e)
        {
            var manager = new ProjectManager { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            manager.Show();
        }

        private void SecretaryLoad(object sender, EventArgs e)
        {
            var secretary = new ProjectSecretary() { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            secretary.Show();
        }

        private void UserLoad(object sender, EventArgs e)
        {
            var user = new ProjectUser() { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            user.Show();
        }

        private void TypeLoad(object sender, EventArgs e)
        {
            var user = new ProjectType() { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            user.Show();
        }

        private void ConsultLoad(object sender, EventArgs e)
        {
            var consultant = new Consultant() { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            consultant.Show();
        }

        private void ContractorLoad(object sender, EventArgs e)
        {
            var contractor = new Contractor() { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            contractor.Show();
        }

        private void GlAcceptionsLoad(object sender, EventArgs e)
        {
            var gla = new ImportAcceptionManager() { WindowState = FormWindowState.Normal, StartPosition = FormStartPosition.CenterScreen };
            gla.Show();
        }

        #endregion

        #region DateReports


        private void EstimatedBidReportClick(object sender, EventArgs e)
        {
            //dialog box displays the entity to choose from and passes the variables
            var dd = new DateRangeDialog { FormTitle = "Est. Bid Schedule Date Range" };
            dd.ShowDialog();  //pop the dialog
            if (dd.SelectionCancel) return;

            SectionReport report = new EstimatedBidSchedule(dd.StartDate, dd.EndDate);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }


        private void CmdWarrentyReportClick(object sender, EventArgs e)
        {
            //dialog box displays the entity to choose from and passes the variables
            var dd = new DateRangeDialog { FormTitle = "Correction Period Date Range" };
            dd.ShowDialog();  //pop the dialog
            if (dd.SelectionCancel) return;

            SectionReport report = new ProjectWarrantyPeriod(dd.StartDate, dd.EndDate);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }

        private void SubstantialReportClick(object sender, EventArgs e)
        {
            var dd = new DateRangeDialog { FormTitle = "Substantial Completion Date Range" };
            var result = dd.ShowDialog();  //pop the dialog

            if (dd.SelectionCancel || result == DialogResult.Cancel) return;

            SectionReport report = new SubstantialCompleteActiveProjects(dd.StartDate, dd.EndDate);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }

        private void ClosedProjectsReportClick(object sender, EventArgs e)
        {
            //dialog box displays the entity to choose from and passes the variables
            var dd = new DateRangeDialog { FormTitle = "Closed Projects Date Range" };
            dd.ShowDialog();  //pop the dialog
            if (dd.SelectionCancel) return;

            SectionReport report = new ProjectsClosed(dd.StartDate, dd.EndDate);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };

            view.Show();
        }

        #endregion

        #region EntitySelectReports

        private void SecretaryReportClick(object sender, EventArgs e)
        {
            SecretaryService service = new SecretaryService(_ctx);
            //dialog box displays the entity to choose from and passes the variables
            //to dynamically setup the generic selection dialog form
            var crit = new EntityDynamicPrompt
            {
                FormTitle = "Select Secretary",
                EntitySelectDataSourceDictionary = service.GetActiveSecretariesDictionary().ToList()
            };
            var result = crit.ShowDialog();

            if (crit.SelectionCancel || result == DialogResult.Cancel) return;

            SectionReport report = new ActiveProjectsSecretaryList(crit.EntityId);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }

        private void SecretaryProjectsReportClick(object sender, EventArgs e)
        {

            SecretaryService service = new SecretaryService(_ctx);
            //dialog box displays the entity to choose from and passes the variables
            //to dynamically setup the generic selection dialog form
            var crit = new EntityDynamicPrompt
            {
                FormTitle = "Select Secretary",
                EntitySelectDataSourceDictionary = service.GetActiveSecretariesDictionary().ToList()
            };
            var result = crit.ShowDialog();

            if (crit.SelectionCancel || result == DialogResult.Cancel) return;

            SectionReport report = new ActiveProjectsSecretary(crit.EntityId);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();



        }


        private void ActiveArchitectReportClick(object sender, EventArgs e)
        {

            ArchitectEngineerService service = new ArchitectEngineerService(_ctx);

            var crit = new EntityDynamicPrompt
            {
                FormTitle = "Select Architect / Engineer",
                EntitySelectDataSourceDictionary = service.GetActiveArchitectEngineerDictionary().ToList()
            };
            var result = crit.ShowDialog();

            if (crit.SelectionCancel || result == DialogResult.Cancel) return;

            SectionReport report = new ActiveProjectsArchitect(crit.EntityId);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }

        private void ActiveProjectManagerReportClick(object sender, EventArgs e)
        {
            var service = new ProjectManagerService(_ctx);
            var crit = new EntityDynamicPrompt
            {
                FormTitle = "Select Project Manager",
                EntitySelectDataSourceDictionary = service.GetActiveProjectManagerDictionary().ToList()
            };
            var result = crit.ShowDialog();

            if (crit.SelectionCancel || result == DialogResult.Cancel) return;

            SectionReport report = new ActiveProjectsManager(crit.EntityId);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }


        private void ManagerReportClick(object sender, EventArgs e)
        {

            var service = new ProjectManagerService(_ctx);

            //dialog box displays the entity to choose from and passes the variables
            //to dynamically setup the generic selection dialog form
            var crit = new EntityDynamicPrompt
            {
                StartPosition = FormStartPosition.CenterScreen,
                FormTitle = "Select Manager for Report",
                EntitySelectDataSourceDictionary = service.GetActiveProjectManagerDictionary().ToList()
            };

            var result = crit.ShowDialog();  //pop the dialog
            if (crit.SelectionCancel || result == DialogResult.Cancel) return;

            SectionReport report = new ActiveProjectsManagerList(crit.EntityId);
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();

        }

        #endregion

        #region StraightReports

        private void CmdReportProjectUpdateClick(object sender, EventArgs e)
        {
            SectionReport report = new ProjectUpdateForm();
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }

        private void OrgKeysClick(object sender, EventArgs e)
        {
            SectionReport report = new FinancialReportByOrgKey();
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };
            view.Show();
        }


        private void FinancialsProjectNumberReportClick(object sender, EventArgs e)
        {
            SectionReport report = new FinancialReportbyProjectNumber();
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };

            view.Show();
        }


        private void CapitalProjectStatusClick(object sender, EventArgs e)
        {

            DateTime time = new DateTime(2011, 02, 01);


            //project manager summary report
            SectionReport manager = new StatusReportSummaryManager();
            manager.Run();

            //currently the parent report of the Capital Projects Report
            ProjectStatusReport projectStatusReport = new ProjectStatusReport();
            projectStatusReport.Run();

            projectStatusReport.Document.Pages.Insert(0, manager.Document.Pages[0]);






            var view = new ActiveReportViewer(projectStatusReport) { MdiParent = MdiParent };
            view.Show();
        }

        #endregion

        private void FReportListing_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            var report = new StatusReportSummaryProjectType();
            report.Run();
            var view = new ActiveReportViewer(report) { MdiParent = MdiParent };

            view.Show();

        }

        //private void glkeyExceptions_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var imc = new GlkeyImportManager(Properties.Resources.GlkeyAcceptionsFile);
        //        var bo = imc.BlockGlkeyFromImport("123456");
        //    }

        //    catch (ArgumentException argument)
        //    {
        //        MessageBox.Show("Invalid path provided to method GlKeyImportManager");
        //    }
        //}

    }
}

