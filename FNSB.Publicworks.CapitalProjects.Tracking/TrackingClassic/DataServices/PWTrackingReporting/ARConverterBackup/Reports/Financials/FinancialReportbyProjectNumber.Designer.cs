namespace FNSB.Publicworks.Projects.Reporting.Reports.Financials
{
    /// <summary>
    /// Summary description for FinancialReportbyProjectNumber.
    /// </summary>
    partial class FinancialReportbyProjectNumber
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FinancialReportbyProjectNumber));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.financialsProjectNumberTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.infoDate = new GrapeCity.ActiveReports.SectionReportModel.ReportInfo();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.projectNumberText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.orgKeyLongNameText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.projectBudgetText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.availableBalanceText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.projectManagerText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.secretaryText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.projectNumberLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.orgKeyLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.orgkeyNameLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.projectBudgetLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.balanceLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.managerLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.secretaryLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.crossSectionBox1 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.crossSectionLine1 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine2 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine3 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine4 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine5 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine6 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            ((System.ComponentModel.ISupportInitialize)(this.financialsProjectNumberTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLongNameText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBudgetText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableBalanceText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagerText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretaryText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgkeyNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBudgetLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managerLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretaryLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.financialsProjectNumberTitle,
            this.infoDate});
            this.pageHeader.Height = 0.35F;
            this.pageHeader.Name = "pageHeader";
            // 
            // financialsProjectNumberTitle
            // 
            this.financialsProjectNumberTitle.Height = 0.23F;
            this.financialsProjectNumberTitle.HyperLink = null;
            this.financialsProjectNumberTitle.Left = 2.118F;
            this.financialsProjectNumberTitle.Name = "financialsProjectNumberTitle";
            this.financialsProjectNumberTitle.Style = "font-size: 12pt; font-weight: bold; ddo-char-set: 0";
            this.financialsProjectNumberTitle.Text = "Financial Report by Project Number";
            this.financialsProjectNumberTitle.Top = 0.064F;
            this.financialsProjectNumberTitle.Width = 2.917F;
            // 
            // infoDate
            // 
            this.infoDate.FormatString = "{RunDateTime:MM/dd/yyyy}";
            this.infoDate.Height = 0.2F;
            this.infoDate.Left = 6.283F;
            this.infoDate.Name = "infoDate";
            this.infoDate.Style = "font-size: 8pt";
            this.infoDate.Top = 0.072F;
            this.infoDate.Width = 1F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox1,
            this.projectNumberText,
            this.orgKeyLongNameText,
            this.projectBudgetText,
            this.availableBalanceText,
            this.projectManagerText,
            this.secretaryText});
            this.detail.Height = 0.2166667F;
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.DataField = "OrgKey";
            this.textBox1.Height = 0.158F;
            this.textBox1.Left = 0.957F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 8.2pt";
            this.textBox1.Text = null;
            this.textBox1.Top = 0.016F;
            this.textBox1.Width = 0.7080001F;
            // 
            // projectNumberText
            // 
            this.projectNumberText.DataField = "ProjectNumber";
            this.projectNumberText.Height = 0.158F;
            this.projectNumberText.Left = 0.07499993F;
            this.projectNumberText.Name = "projectNumberText";
            this.projectNumberText.Style = "font-size: 8.2pt";
            this.projectNumberText.Text = null;
            this.projectNumberText.Top = 0.01599999F;
            this.projectNumberText.Width = 0.8500001F;
            // 
            // orgKeyLongNameText
            // 
            this.orgKeyLongNameText.DataField = "OrgKeyName";
            this.orgKeyLongNameText.Height = 0.158F;
            this.orgKeyLongNameText.Left = 1.701F;
            this.orgKeyLongNameText.MultiLine = false;
            this.orgKeyLongNameText.Name = "orgKeyLongNameText";
            this.orgKeyLongNameText.Style = "font-size: 8.2pt";
            this.orgKeyLongNameText.Text = null;
            this.orgKeyLongNameText.Top = 0.016F;
            this.orgKeyLongNameText.Width = 2.235F;
            // 
            // projectBudgetText
            // 
            this.projectBudgetText.DataField = "ProjectBudget";
            this.projectBudgetText.Height = 0.158F;
            this.projectBudgetText.Left = 3.976F;
            this.projectBudgetText.Name = "projectBudgetText";
            this.projectBudgetText.OutputFormat = resources.GetString("projectBudgetText.OutputFormat");
            this.projectBudgetText.Style = "font-size: 8.2pt; text-align: right";
            this.projectBudgetText.Text = null;
            this.projectBudgetText.Top = 0.016F;
            this.projectBudgetText.Width = 0.9270003F;
            // 
            // availableBalanceText
            // 
            this.availableBalanceText.DataField = "ProjectBalance";
            this.availableBalanceText.Height = 0.158F;
            this.availableBalanceText.Left = 4.935F;
            this.availableBalanceText.Name = "availableBalanceText";
            this.availableBalanceText.OutputFormat = resources.GetString("availableBalanceText.OutputFormat");
            this.availableBalanceText.Style = "font-size: 8.2pt; text-align: right";
            this.availableBalanceText.Text = null;
            this.availableBalanceText.Top = 0.016F;
            this.availableBalanceText.Width = 0.9999995F;
            // 
            // projectManagerText
            // 
            this.projectManagerText.DataField = "ProjectManager";
            this.projectManagerText.Height = 0.158F;
            this.projectManagerText.Left = 5.979F;
            this.projectManagerText.Name = "projectManagerText";
            this.projectManagerText.Style = "font-size: 8.2pt";
            this.projectManagerText.Text = null;
            this.projectManagerText.Top = 0.01599999F;
            this.projectManagerText.Width = 1.03F;
            // 
            // secretaryText
            // 
            this.secretaryText.DataField = "ProjectSecretary";
            this.secretaryText.Height = 0.158F;
            this.secretaryText.Left = 7.049F;
            this.secretaryText.Name = "secretaryText";
            this.secretaryText.Style = "font-size: 8.2pt; text-align: center";
            this.secretaryText.Text = null;
            this.secretaryText.Top = 0.016F;
            this.secretaryText.Width = 0.3919997F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.projectNumberLabel,
            this.orgKeyLabel,
            this.orgkeyNameLabel,
            this.projectBudgetLabel,
            this.balanceLabel,
            this.managerLabel,
            this.secretaryLabel,
            this.crossSectionBox1,
            this.crossSectionLine1,
            this.crossSectionLine2,
            this.crossSectionLine3,
            this.crossSectionLine4,
            this.crossSectionLine5,
            this.crossSectionLine6});
            this.groupHeader1.Height = 0.25F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // projectNumberLabel
            // 
            this.projectNumberLabel.Height = 0.15F;
            this.projectNumberLabel.HyperLink = null;
            this.projectNumberLabel.Left = 0.075F;
            this.projectNumberLabel.Name = "projectNumberLabel";
            this.projectNumberLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.projectNumberLabel.Style = "font-size: 7.8pt; font-weight: bold; ddo-char-set: 0";
            this.projectNumberLabel.Text = "Project Number";
            this.projectNumberLabel.Top = 0.072F;
            this.projectNumberLabel.Width = 0.85F;
            // 
            // orgKeyLabel
            // 
            this.orgKeyLabel.Height = 0.15F;
            this.orgKeyLabel.HyperLink = null;
            this.orgKeyLabel.Left = 0.957F;
            this.orgKeyLabel.Name = "orgKeyLabel";
            this.orgKeyLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.orgKeyLabel.Style = "font-size: 7.8pt; font-weight: bold; ddo-char-set: 0";
            this.orgKeyLabel.Text = "G/L Org Key";
            this.orgKeyLabel.Top = 0.072F;
            this.orgKeyLabel.Width = 0.7080001F;
            // 
            // orgkeyNameLabel
            // 
            this.orgkeyNameLabel.Height = 0.15F;
            this.orgkeyNameLabel.HyperLink = null;
            this.orgkeyNameLabel.Left = 1.701F;
            this.orgkeyNameLabel.Name = "orgkeyNameLabel";
            this.orgkeyNameLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.orgkeyNameLabel.Style = "font-size: 7.8pt; font-weight: bold; ddo-char-set: 0";
            this.orgkeyNameLabel.Text = "G/L Org Key Long Name";
            this.orgkeyNameLabel.Top = 0.072F;
            this.orgkeyNameLabel.Width = 2.235F;
            // 
            // projectBudgetLabel
            // 
            this.projectBudgetLabel.Height = 0.15F;
            this.projectBudgetLabel.HyperLink = null;
            this.projectBudgetLabel.Left = 3.968F;
            this.projectBudgetLabel.Name = "projectBudgetLabel";
            this.projectBudgetLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.projectBudgetLabel.Style = "font-size: 7.8pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.projectBudgetLabel.Text = "Project Budget";
            this.projectBudgetLabel.Top = 0.072F;
            this.projectBudgetLabel.Width = 0.935F;
            // 
            // balanceLabel
            // 
            this.balanceLabel.Height = 0.15F;
            this.balanceLabel.HyperLink = null;
            this.balanceLabel.Left = 4.935F;
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.balanceLabel.Style = "font-size: 7.8pt; font-weight: bold; text-align: right; ddo-char-set: 0";
            this.balanceLabel.Text = "Available Balance";
            this.balanceLabel.Top = 0.072F;
            this.balanceLabel.Width = 1F;
            // 
            // managerLabel
            // 
            this.managerLabel.Height = 0.15F;
            this.managerLabel.HyperLink = null;
            this.managerLabel.Left = 5.979F;
            this.managerLabel.Name = "managerLabel";
            this.managerLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.managerLabel.Style = "font-size: 7.8pt; font-weight: bold; ddo-char-set: 0";
            this.managerLabel.Text = "Project Manager";
            this.managerLabel.Top = 0.072F;
            this.managerLabel.Width = 1.03F;
            // 
            // secretaryLabel
            // 
            this.secretaryLabel.Height = 0.15F;
            this.secretaryLabel.HyperLink = null;
            this.secretaryLabel.Left = 7.049F;
            this.secretaryLabel.Name = "secretaryLabel";
            this.secretaryLabel.Padding = new GrapeCity.ActiveReports.PaddingEx(0, 0, 2, 0);
            this.secretaryLabel.Style = "font-size: 7.8pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.secretaryLabel.Text = "Sec #";
            this.secretaryLabel.Top = 0.072F;
            this.secretaryLabel.Width = 0.3920002F;
            // 
            // crossSectionBox1
            // 
            this.crossSectionBox1.Bottom = 0.025F;
            this.crossSectionBox1.Left = 0.04F;
            this.crossSectionBox1.LineColor = System.Drawing.Color.Silver;
            this.crossSectionBox1.LineWeight = 0.7F;
            this.crossSectionBox1.Name = "crossSectionBox1";
            this.crossSectionBox1.Radius = 2;
            this.crossSectionBox1.Right = 7.458F;
            this.crossSectionBox1.Top = 0F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0.08333334F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // crossSectionLine1
            // 
            this.crossSectionLine1.Bottom = 0.025F;
            this.crossSectionLine1.Left = 7.025F;
            this.crossSectionLine1.LineColor = System.Drawing.Color.Silver;
            this.crossSectionLine1.LineWeight = 0.7F;
            this.crossSectionLine1.Name = "crossSectionLine1";
            this.crossSectionLine1.Top = 0F;
            // 
            // crossSectionLine2
            // 
            this.crossSectionLine2.Bottom = 0.025F;
            this.crossSectionLine2.Left = 5.955F;
            this.crossSectionLine2.LineColor = System.Drawing.Color.Silver;
            this.crossSectionLine2.LineWeight = 0.7F;
            this.crossSectionLine2.Name = "crossSectionLine2";
            this.crossSectionLine2.Top = 0F;
            // 
            // crossSectionLine3
            // 
            this.crossSectionLine3.Bottom = 0.025F;
            this.crossSectionLine3.Left = 4.919F;
            this.crossSectionLine3.LineColor = System.Drawing.Color.Silver;
            this.crossSectionLine3.LineWeight = 0.7F;
            this.crossSectionLine3.Name = "crossSectionLine3";
            this.crossSectionLine3.Top = 0F;
            // 
            // crossSectionLine4
            // 
            this.crossSectionLine4.Bottom = 0.025F;
            this.crossSectionLine4.Left = 3.952F;
            this.crossSectionLine4.LineColor = System.Drawing.Color.Silver;
            this.crossSectionLine4.LineWeight = 0.7F;
            this.crossSectionLine4.Name = "crossSectionLine4";
            this.crossSectionLine4.Top = 0F;
            // 
            // crossSectionLine5
            // 
            this.crossSectionLine5.Bottom = 0.025F;
            this.crossSectionLine5.Left = 1.681F;
            this.crossSectionLine5.LineColor = System.Drawing.Color.Silver;
            this.crossSectionLine5.LineWeight = 0.7F;
            this.crossSectionLine5.Name = "crossSectionLine5";
            this.crossSectionLine5.Top = 0F;
            // 
            // crossSectionLine6
            // 
            this.crossSectionLine6.Bottom = 0.025F;
            this.crossSectionLine6.Left = 0.941F;
            this.crossSectionLine6.LineColor = System.Drawing.Color.Silver;
            this.crossSectionLine6.LineWeight = 0.7F;
            this.crossSectionLine6.Name = "crossSectionLine6";
            this.crossSectionLine6.Top = 0F;
            // 
            // FinancialReportbyProjectNumber
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.5F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.491666F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.FetchData += new GrapeCity.ActiveReports.SectionReport.FetchEventHandler(this.FinancialsByProjectNumberFetchData);
            this.ReportStart += new System.EventHandler(this.FinancialsByProjectNumberReportStart);
            this.DataInitialize += new System.EventHandler(this.FinancialsByProjectNumberDataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.financialsProjectNumberTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLongNameText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBudgetText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableBalanceText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagerText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretaryText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgkeyNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBudgetLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managerLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretaryLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion


























        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.Label financialsProjectNumberTitle;
        private GrapeCity.ActiveReports.SectionReportModel.ReportInfo infoDate;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectNumberText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox orgKeyLongNameText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectBudgetText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox availableBalanceText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectManagerText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox secretaryText;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Label projectNumberLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label orgKeyLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label orgkeyNameLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label projectBudgetLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label balanceLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label managerLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label secretaryLabel;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox crossSectionBox1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine2;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine3;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine4;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine5;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine6;
    }
}
