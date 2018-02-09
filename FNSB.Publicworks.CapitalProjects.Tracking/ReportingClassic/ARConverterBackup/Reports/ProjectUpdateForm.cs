using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;
using GrapeCity.ActiveReports.Data;
using PWTrackingReporting.Reports;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for ProjectUpdateForm.
    /// </summary>
    public partial class ProjectUpdateForm : GrapeCity.ActiveReports.SectionReport
    {

        private Int32 _procount = 0;
        private readonly publicworksEntities _ctx = new publicworksEntities();
        private Field _fieldManager;
        private Field _fieldUser;
        private Field _fieldArchitect;
        private Field _fieldSecretary;
        private Field _fieldConsultant;
        private Field _fieldContractor;
        private ProjectFunds _fundsReport;
        private List<Project> _projects;

        //funding report variables
        private Field _fieldBudget;
        private Field _fieldExpenditures;
        private Field _fieldEncumbrances;
        private Field _fieldBalance;

        public ProjectUpdateForm()
        {
            InitializeComponent();
        }

        private void ProjectUpdateFormReportStart(object sender, EventArgs e)
        {
            _fieldManager = new Field { FieldType = FieldTypeEnum.String, Name = "manager" };
            _fieldArchitect = new Field { FieldType = FieldTypeEnum.String, Name = "fieldarchitect" };
            _fieldSecretary = new Field { FieldType = FieldTypeEnum.String, Name = "fieldsecretary" };
            _fieldUser = new Field { FieldType = FieldTypeEnum.String, Name = "fielduser" };
            _fieldConsultant = new Field { FieldType = FieldTypeEnum.String, Name = "fieldconsultant" };
            _fieldContractor = new Field { FieldType = FieldTypeEnum.String, Name = "fieldcontractor" };

            //ProjectFunding report fields
            _fieldBudget = new Field { FieldType = FieldTypeEnum.String, Name = "fieldBudget" };
            _fieldExpenditures = new Field { FieldType = FieldTypeEnum.String, Name = "fieldExpend" };
            _fieldEncumbrances = new Field { FieldType = FieldTypeEnum.String, Name = "fieldEncumb" };
            _fieldBalance = new Field { FieldType = FieldTypeEnum.String, Name = "fieldBalance" };

            _fundsReport = new ProjectFunds();
            fundsSubReport.Report = _fundsReport;
        }

        private void ProjectUpdateFormDataInitialize(object sender, EventArgs e)
        {
            try
            {
                var projects = _ctx.Projects.Where(p => p.PPM_Project_Active == true && p.ppm_project_complete == false).OrderBy(a => a.ProjectManager.ppr_recordid);
                _projects = projects.ToList();
                DataSource = _projects;

                //Fields management
                Fields.Add(_fieldManager);

                managerText.DataField = _fieldManager.Name;
                ManagerName.DataField = _fieldManager.Name;

                Fields.Add(_fieldArchitect);
                projectArcText.DataField = _fieldArchitect.Name;

                Fields.Add(_fieldSecretary);
                projectSecText.DataField = _fieldSecretary.Name;

                Fields.Add(_fieldUser);
                userNameText.DataField = _fieldUser.Name;

                Fields.Add(_fieldConsultant);
                consultantNameText.DataField = _fieldConsultant.Name;

                Fields.Add(_fieldContractor);
                contractorNameText.DataField = _fieldContractor.Name;

                projectNumberText.DataField = "ppm_project_number";
                projectNameText.DataField = "ppm_project_name";
                typeText.DataField = "Projects.ProjectType.category";
                activeCheckbox.DataField = "ppm_project_active";
                dateScopeText.DataField = "ndi_scope";
                dateGeneralServiceText.DataField = "ndi_gen_serv_review";
                dateConsultAwardText.DataField = "ndi_consultant_award";
                dateDesignCompleteText.DataField = "ndi_design_complete";
                dateAdvertiseBidText.DataField = "ndi_advertise_for_bid";
                dateBidOpenText.DataField = "ndi_bid_opening";
                currentStatusText.DataField = "ppm_status_desc";
                dateConstructionBidAwardText.DataField = "ndi_construction_bid_award";
                dateAgendaSettingText.DataField = "ndi_agenda_setting";
                dateAssemblyApprovalText.DataField = "ndi_assembly_approval";
                dateNtpText.DataField = "ndi_ntp";
                dateSubstantialCompleteText.DataField = "ndi_substantial_completion";
                dateFinalPayApprovalText.DataField = "ndi_final";
                dateClosedText.DataField = "ndi_closed";
                dateWarrentyPeriodEndsText.DataField = "ndi_warranty_period_ends";
                consultantContractAmendText.DataField = "ppm_contract_amendments";
                consultantDesignPercentCompleteText.DataField = "ppm_per_des_complete";
                consultantOriginalFeeText.DataField = "ppm_consultant_fee";
                contractorContractAmountText.DataField = "ppm_contract_amount";
                contractorChangeOrders.DataField = "ppm_co";
                contractorConstructionPercentComplete.DataField = "ppm_per_const_complete";

                Fields.Add(_fieldBudget);
                fundBudgetText.DataField = _fieldBudget.Name;
                Fields.Add(_fieldExpenditures);
                fundExpenditureText.DataField = _fieldExpenditures.Name;
                Fields.Add(_fieldEncumbrances);
                fundEncumbrancesText.DataField = _fieldEncumbrances.Name;
                Fields.Add(_fieldBalance);
                fundAvailableBalanceText.DataField = _fieldBalance.Name;
            }

            catch (Exception)
            {
                throw;
            }
        }

        private void ProjectUpdateFormFetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF) return;

            _fieldManager.Value = String.Format("{1} {0}", _projects[_procount].ProjectManager.lastname, _projects[_procount].ProjectManager.firstname);
            _fieldArchitect.Value = String.Format("{1} {0}", _projects[_procount].ArchitectEngineer.lastname, _projects[_procount].ArchitectEngineer.firstname);
            _fieldSecretary.Value = String.Format("{1} {0}", _projects[_procount].Secretary.lastname, _projects[_procount].Secretary.firstname);
            _fieldUser.Value = String.Format("{1} {0}", _projects[_procount].User.lastname, _projects[_procount].User.firstname);
            _fieldContractor.Value = String.Format("{0}", _projects[_procount].Contractor.contractorname);
            _fieldConsultant.Value = String.Format("{0}", _projects[_procount].Consultant.consultantname);

            var fundDataset = _projects[_procount].Funds.OrderBy(p => p.ppf_balance);

            //fund sums form totals display
            decimal? budget = fundDataset.Sum(f => f.ppf_budget);
            decimal? expenditure = fundDataset.Sum(f => f.ppf_expenditures);
            decimal? encumbrances = fundDataset.Sum(f => f.ppf_encumbrances);
            decimal? balance = budget - (expenditure + encumbrances);

            //field management
            _fieldBudget.Value = budget.ToString();
            _fieldExpenditures.Value = expenditure.ToString();
            _fieldEncumbrances.Value = encumbrances.ToString();

            decimal displayBal;
            _fieldBalance.Value = decimal.TryParse(balance.ToString(), out displayBal) ? displayBal.ToString() : "$0.00";

            _fundsReport.DataSource = fundDataset.ToList();
            _procount++;

        }

        private void DetailFormat(object sender, EventArgs e)
        {
            detail.AddBookmark(_fieldManager.Value.ToString());
        }


    }
}
