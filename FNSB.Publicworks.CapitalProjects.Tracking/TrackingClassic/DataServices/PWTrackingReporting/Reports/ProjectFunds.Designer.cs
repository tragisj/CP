namespace PWTrackingReporting.Reports
{
    /// <summary>
    /// Summary description for ProjectFunds.
    /// </summary>
    partial class ProjectFunds
    {


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ProjectFunds));
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.fundText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.deptText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.orgkeyText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.budgetText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.expenseText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.encumbranceText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.orgkeynameText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.balanceText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.crossSectionLine1 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine2 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine3 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine4 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine5 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine6 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine7 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            ((System.ComponentModel.ISupportInitialize)(this.fundText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgkeyText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encumbranceText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgkeynameText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.fundText,
            this.deptText,
            this.orgkeyText,
            this.budgetText,
            this.expenseText,
            this.encumbranceText,
            this.orgkeynameText,
            this.balanceText});
            this.detail.Height = 0.209F;
            this.detail.Name = "detail";
            // 
            // fundText
            // 
            this.fundText.DataField = "ppf_funding";
            this.fundText.Height = 0.158F;
            this.fundText.Left = 0.03F;
            this.fundText.Name = "fundText";
            this.fundText.Style = "font-family: Consolas; font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.fundText.Text = null;
            this.fundText.Top = 0F;
            this.fundText.Width = 0.229F;
            // 
            // deptText
            // 
            this.deptText.DataField = "ppf_department";
            this.deptText.Height = 0.158F;
            this.deptText.Left = 0.32F;
            this.deptText.Name = "deptText";
            this.deptText.Style = "font-family: Consolas; font-size: 8.25pt; text-align: center; ddo-char-set: 0";
            this.deptText.Text = null;
            this.deptText.Top = 0F;
            this.deptText.Width = 0.271F;
            // 
            // orgkeyText
            // 
            this.orgkeyText.DataField = "ppf_glkey";
            this.orgkeyText.Height = 0.158F;
            this.orgkeyText.Left = 0.654F;
            this.orgkeyText.Name = "orgkeyText";
            this.orgkeyText.Style = "font-family: Consolas; font-size: 8.25pt; ddo-char-set: 0";
            this.orgkeyText.Text = null;
            this.orgkeyText.Top = 0F;
            this.orgkeyText.Width = 0.471F;
            // 
            // budgetText
            // 
            this.budgetText.DataField = "ppf_budget";
            this.budgetText.Height = 0.158F;
            this.budgetText.Left = 3.269F;
            this.budgetText.Name = "budgetText";
            this.budgetText.OutputFormat = resources.GetString("budgetText.OutputFormat");
            this.budgetText.Style = "font-family: Consolas; font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.budgetText.Text = null;
            this.budgetText.Top = 0F;
            this.budgetText.Width = 0.95F;
            // 
            // expenseText
            // 
            this.expenseText.DataField = "ppf_expenditures";
            this.expenseText.Height = 0.158F;
            this.expenseText.Left = 4.306F;
            this.expenseText.Name = "expenseText";
            this.expenseText.OutputFormat = resources.GetString("expenseText.OutputFormat");
            this.expenseText.Style = "font-family: Consolas; font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.expenseText.Text = null;
            this.expenseText.Top = 0F;
            this.expenseText.Width = 0.95F;
            // 
            // encumbranceText
            // 
            this.encumbranceText.DataField = "ppf_encumbrances";
            this.encumbranceText.Height = 0.158F;
            this.encumbranceText.Left = 5.326F;
            this.encumbranceText.Name = "encumbranceText";
            this.encumbranceText.OutputFormat = resources.GetString("encumbranceText.OutputFormat");
            this.encumbranceText.Style = "font-family: Consolas; font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.encumbranceText.Text = null;
            this.encumbranceText.Top = 0F;
            this.encumbranceText.Width = 0.95F;
            // 
            // orgkeynameText
            // 
            this.orgkeynameText.DataField = "ppf_glkey_name";
            this.orgkeynameText.Height = 0.158F;
            this.orgkeynameText.Left = 1.197F;
            this.orgkeynameText.MultiLine = false;
            this.orgkeynameText.Name = "orgkeynameText";
            this.orgkeynameText.Style = "font-family: Consolas; font-size: 8.25pt; ddo-char-set: 0";
            this.orgkeynameText.Text = null;
            this.orgkeynameText.Top = 0F;
            this.orgkeynameText.Width = 1.977F;
            // 
            // balanceText
            // 
            this.balanceText.DataField = "ppf_balance";
            this.balanceText.Height = 0.158F;
            this.balanceText.Left = 6.357F;
            this.balanceText.Name = "balanceText";
            this.balanceText.OutputFormat = resources.GetString("balanceText.OutputFormat");
            this.balanceText.Style = "font-family: Consolas; font-size: 8.25pt; text-align: right; ddo-char-set: 0";
            this.balanceText.Text = null;
            this.balanceText.Top = 0F;
            this.balanceText.Width = 0.95F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.BackColor = System.Drawing.Color.Gainsboro;
            this.reportHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.crossSectionLine1,
            this.crossSectionLine2,
            this.crossSectionLine3,
            this.crossSectionLine4,
            this.crossSectionLine5,
            this.crossSectionLine6,
            this.crossSectionLine7});
            this.reportHeader1.Height = 0.2086666F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Format += new System.EventHandler(this.reportHeader1_Format);
            // 
            // label1
            // 
            this.label1.Height = 0.148F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label1.Text = "Fund";
            this.label1.Top = 0.021F;
            this.label1.Width = 0.281F;
            // 
            // label2
            // 
            this.label2.Height = 0.148F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.31F;
            this.label2.Name = "label2";
            this.label2.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label2.Text = "Dept";
            this.label2.Top = 0.02F;
            this.label2.Width = 0.281F;
            // 
            // label3
            // 
            this.label3.Height = 0.148F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.654F;
            this.label3.Name = "label3";
            this.label3.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label3.Text = "G/L Key";
            this.label3.Top = 0.021F;
            this.label3.Width = 0.471F;
            // 
            // label4
            // 
            this.label4.Height = 0.148F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.197F;
            this.label4.Name = "label4";
            this.label4.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; ddo-char-set: 0";
            this.label4.Text = "G/L Org Key Name";
            this.label4.Top = 0.02F;
            this.label4.Width = 1.563F;
            // 
            // label5
            // 
            this.label5.Height = 0.148F;
            this.label5.HyperLink = null;
            this.label5.Left = 3.533F;
            this.label5.Name = "label5";
            this.label5.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; text-align: right; d" +
    "do-char-set: 0";
            this.label5.Text = "Budget";
            this.label5.Top = 0.03F;
            this.label5.Width = 0.6860003F;
            // 
            // label6
            // 
            this.label6.Height = 0.148F;
            this.label6.HyperLink = null;
            this.label6.Left = 4.456F;
            this.label6.Name = "label6";
            this.label6.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; text-align: right; d" +
    "do-char-set: 0";
            this.label6.Text = "Expenses";
            this.label6.Top = 0.031F;
            this.label6.Width = 0.8000002F;
            // 
            // label7
            // 
            this.label7.Height = 0.148F;
            this.label7.HyperLink = null;
            this.label7.Left = 5.486F;
            this.label7.Name = "label7";
            this.label7.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; text-align: right; d" +
    "do-char-set: 0";
            this.label7.Text = "Encumbrances";
            this.label7.Top = 0.031F;
            this.label7.Width = 0.7999997F;
            // 
            // label8
            // 
            this.label8.Height = 0.148F;
            this.label8.HyperLink = null;
            this.label8.Left = 6.734F;
            this.label8.Name = "label8";
            this.label8.Style = "font-family: Consolas; font-size: 8.25pt; font-weight: bold; text-align: right; d" +
    "do-char-set: 0";
            this.label8.Text = "Balance";
            this.label8.Top = 0.031F;
            this.label8.Width = 0.5730004F;
            // 
            // crossSectionLine1
            // 
            this.crossSectionLine1.Bottom = 0.021F;
            this.crossSectionLine1.Left = 6.313F;
            this.crossSectionLine1.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine1.LineWeight = 0.7F;
            this.crossSectionLine1.Name = "crossSectionLine1";
            this.crossSectionLine1.Top = 0F;
            // 
            // crossSectionLine2
            // 
            this.crossSectionLine2.Bottom = 0.031F;
            this.crossSectionLine2.Left = 5.286F;
            this.crossSectionLine2.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine2.LineWeight = 0.7F;
            this.crossSectionLine2.Name = "crossSectionLine2";
            this.crossSectionLine2.Top = 0.01F;
            // 
            // crossSectionLine3
            // 
            this.crossSectionLine3.Bottom = 0.02F;
            this.crossSectionLine3.Left = 4.261F;
            this.crossSectionLine3.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine3.LineWeight = 0.7F;
            this.crossSectionLine3.Name = "crossSectionLine3";
            this.crossSectionLine3.Top = 0F;
            // 
            // crossSectionLine4
            // 
            this.crossSectionLine4.Bottom = 0.02F;
            this.crossSectionLine4.Left = 3.229F;
            this.crossSectionLine4.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine4.LineWeight = 0.7F;
            this.crossSectionLine4.Name = "crossSectionLine4";
            this.crossSectionLine4.Top = 0F;
            // 
            // crossSectionLine5
            // 
            this.crossSectionLine5.Bottom = 0.021F;
            this.crossSectionLine5.Left = 1.157F;
            this.crossSectionLine5.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine5.LineWeight = 0.7F;
            this.crossSectionLine5.Name = "crossSectionLine5";
            this.crossSectionLine5.Top = 0.021F;
            // 
            // crossSectionLine6
            // 
            this.crossSectionLine6.Bottom = 0.02F;
            this.crossSectionLine6.Left = 0.624F;
            this.crossSectionLine6.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine6.LineWeight = 0.7F;
            this.crossSectionLine6.Name = "crossSectionLine6";
            this.crossSectionLine6.Top = 0.02F;
            // 
            // crossSectionLine7
            // 
            this.crossSectionLine7.Bottom = 0.02F;
            this.crossSectionLine7.Left = 0.29F;
            this.crossSectionLine7.LineColor = System.Drawing.Color.Gray;
            this.crossSectionLine7.LineWeight = 0.7F;
            this.crossSectionLine7.Name = "crossSectionLine7";
            this.crossSectionLine7.Top = 0.02F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0.03124997F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // ProjectFunds
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.354167F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.fundText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgkeyText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encumbranceText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgkeynameText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion


























        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox fundText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox deptText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox orgkeyText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox budgetText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox expenseText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox encumbranceText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox balanceText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox orgkeynameText;
        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label6;
        private GrapeCity.ActiveReports.SectionReportModel.Label label7;
        private GrapeCity.ActiveReports.SectionReportModel.Label label8;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine2;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine3;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine4;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine5;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine6;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine7;
    }
}
