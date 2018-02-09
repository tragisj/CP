namespace PWTrackingReporting.Reports.CapitalProjects
{
    /// <summary>
    /// Summary description for CapitalProjectsFinancing.
    /// </summary>
    partial class CapitalProjectsFinancing
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CapitalProjectsFinancing));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.orgKeyText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.budgetText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.expendText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.encumbranceText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.balanceText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.orgKeyLongText = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.orgKeyLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.budgetLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.expendLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.EncumbranceLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.balanceLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.orgKeyLongLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.crossSectionBox1 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox();
            this.crossSectionLine1 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine2 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine3 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine4 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine5 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expendText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encumbranceText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLongText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expendLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncumbranceLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLongLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.orgKeyText,
            this.budgetText,
            this.expendText,
            this.encumbranceText,
            this.balanceText,
            this.orgKeyLongText});
            this.detail.Height = 0.15625F;
            this.detail.Name = "detail";
            // 
            // orgKeyText
            // 
            this.orgKeyText.DataField = "OrgKey";
            this.orgKeyText.Height = 0.127F;
            this.orgKeyText.Left = 0.085F;
            this.orgKeyText.Name = "orgKeyText";
            this.orgKeyText.Style = "font-family: Microsoft Sans Serif; font-size: 7.75pt; ddo-char-set: 1";
            this.orgKeyText.Text = null;
            this.orgKeyText.Top = 0.013F;
            this.orgKeyText.Width = 0.7400001F;
            // 
            // budgetText
            // 
            this.budgetText.DataField = "Budget";
            this.budgetText.Height = 0.127F;
            this.budgetText.Left = 0.9910001F;
            this.budgetText.Name = "budgetText";
            this.budgetText.OutputFormat = resources.GetString("budgetText.OutputFormat");
            this.budgetText.Style = "font-family: Microsoft Sans Serif; font-size: 7.75pt; text-align: right; ddo-char" +
    "-set: 1";
            this.budgetText.Text = null;
            this.budgetText.Top = 0.01F;
            this.budgetText.Width = 1F;
            // 
            // expendText
            // 
            this.expendText.DataField = "Expenditures";
            this.expendText.Height = 0.127F;
            this.expendText.Left = 2.126F;
            this.expendText.Name = "expendText";
            this.expendText.OutputFormat = resources.GetString("expendText.OutputFormat");
            this.expendText.Style = "font-family: Microsoft Sans Serif; font-size: 7.75pt; text-align: right; ddo-char" +
    "-set: 1";
            this.expendText.Text = null;
            this.expendText.Top = 0.013F;
            this.expendText.Width = 1F;
            // 
            // encumbranceText
            // 
            this.encumbranceText.DataField = "Encumbrances";
            this.encumbranceText.Height = 0.127F;
            this.encumbranceText.Left = 3.24F;
            this.encumbranceText.Name = "encumbranceText";
            this.encumbranceText.OutputFormat = resources.GetString("encumbranceText.OutputFormat");
            this.encumbranceText.Style = "font-family: Microsoft Sans Serif; font-size: 7.75pt; text-align: right; ddo-char" +
    "-set: 1";
            this.encumbranceText.Text = null;
            this.encumbranceText.Top = 0.013F;
            this.encumbranceText.Width = 1F;
            // 
            // balanceText
            // 
            this.balanceText.DataField = "Balance";
            this.balanceText.Height = 0.127F;
            this.balanceText.Left = 4.344F;
            this.balanceText.Name = "balanceText";
            this.balanceText.OutputFormat = resources.GetString("balanceText.OutputFormat");
            this.balanceText.Style = "font-family: Microsoft Sans Serif; font-size: 7.75pt; text-align: right; ddo-char" +
    "-set: 1";
            this.balanceText.Text = null;
            this.balanceText.Top = 0.013F;
            this.balanceText.Width = 1F;
            // 
            // orgKeyLongText
            // 
            this.orgKeyLongText.CanGrow = false;
            this.orgKeyLongText.DataField = "OrgKeyName";
            this.orgKeyLongText.Height = 0.127F;
            this.orgKeyLongText.Left = 5.448F;
            this.orgKeyLongText.MultiLine = false;
            this.orgKeyLongText.Name = "orgKeyLongText";
            this.orgKeyLongText.Style = "font-family: Microsoft Sans Serif; font-size: 7.75pt; white-space: nowrap; ddo-ch" +
    "ar-set: 1";
            this.orgKeyLongText.Text = null;
            this.orgKeyLongText.Top = 0.013F;
            this.orgKeyLongText.Width = 2.125F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.orgKeyLabel,
            this.budgetLabel,
            this.expendLabel,
            this.EncumbranceLabel,
            this.balanceLabel,
            this.orgKeyLongLabel,
            this.crossSectionBox1,
            this.crossSectionLine1,
            this.crossSectionLine2,
            this.crossSectionLine3,
            this.crossSectionLine4,
            this.crossSectionLine5});
            this.groupHeader1.Height = 0.1979167F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // orgKeyLabel
            // 
            this.orgKeyLabel.Height = 0.148F;
            this.orgKeyLabel.HyperLink = null;
            this.orgKeyLabel.Left = 0.09500001F;
            this.orgKeyLabel.Name = "orgKeyLabel";
            this.orgKeyLabel.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; ddo-char-set: 1";
            this.orgKeyLabel.Text = "G/L Org Key";
            this.orgKeyLabel.Top = 0.033F;
            this.orgKeyLabel.Width = 0.7400001F;
            // 
            // budgetLabel
            // 
            this.budgetLabel.Height = 0.148F;
            this.budgetLabel.HyperLink = null;
            this.budgetLabel.Left = 0.9910001F;
            this.budgetLabel.Name = "budgetLabel";
            this.budgetLabel.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: right; ddo-" +
    "char-set: 1";
            this.budgetLabel.Text = "Project Budget";
            this.budgetLabel.Top = 0.033F;
            this.budgetLabel.Width = 1F;
            // 
            // expendLabel
            // 
            this.expendLabel.Height = 0.148F;
            this.expendLabel.HyperLink = null;
            this.expendLabel.Left = 2.126F;
            this.expendLabel.Name = "expendLabel";
            this.expendLabel.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: right; ddo-" +
    "char-set: 1";
            this.expendLabel.Text = "LTD Expenditures";
            this.expendLabel.Top = 0.033F;
            this.expendLabel.Width = 1F;
            // 
            // EncumbranceLabel
            // 
            this.EncumbranceLabel.Height = 0.148F;
            this.EncumbranceLabel.HyperLink = null;
            this.EncumbranceLabel.Left = 3.24F;
            this.EncumbranceLabel.Name = "EncumbranceLabel";
            this.EncumbranceLabel.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: right; ddo-" +
    "char-set: 1";
            this.EncumbranceLabel.Text = "Encumbrances";
            this.EncumbranceLabel.Top = 0.033F;
            this.EncumbranceLabel.Width = 1F;
            // 
            // balanceLabel
            // 
            this.balanceLabel.Height = 0.148F;
            this.balanceLabel.HyperLink = null;
            this.balanceLabel.Left = 4.344F;
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: right; ddo-" +
    "char-set: 1";
            this.balanceLabel.Text = "Available Balance:";
            this.balanceLabel.Top = 0.033F;
            this.balanceLabel.Width = 1F;
            // 
            // orgKeyLongLabel
            // 
            this.orgKeyLongLabel.Height = 0.148F;
            this.orgKeyLongLabel.HyperLink = null;
            this.orgKeyLongLabel.Left = 5.448F;
            this.orgKeyLongLabel.Name = "orgKeyLongLabel";
            this.orgKeyLongLabel.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; ddo-char-set: 1";
            this.orgKeyLongLabel.Text = "G/L Org Key Long Name";
            this.orgKeyLongLabel.Top = 0.033F;
            this.orgKeyLongLabel.Width = 2.125F;
            // 
            // crossSectionBox1
            // 
            this.crossSectionBox1.Bottom = 0F;
            this.crossSectionBox1.Left = 0.03F;
            this.crossSectionBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.crossSectionBox1.LineWeight = 1F;
            this.crossSectionBox1.Name = "crossSectionBox1";
            this.crossSectionBox1.Radius = new GrapeCity.ActiveReports.Controls.CornersRadius(1F);
            this.crossSectionBox1.Right = 7.6F;
            this.crossSectionBox1.Top = 0F;
            // 
            // crossSectionLine1
            // 
            this.crossSectionLine1.Bottom = 0F;
            this.crossSectionLine1.Left = 0.9070001F;
            this.crossSectionLine1.LineColor = System.Drawing.Color.Gainsboro;
            this.crossSectionLine1.LineWeight = 1F;
            this.crossSectionLine1.Name = "crossSectionLine1";
            this.crossSectionLine1.Top = 0F;
            // 
            // crossSectionLine2
            // 
            this.crossSectionLine2.Bottom = 0F;
            this.crossSectionLine2.Left = 2.064F;
            this.crossSectionLine2.LineColor = System.Drawing.Color.Gainsboro;
            this.crossSectionLine2.LineWeight = 1F;
            this.crossSectionLine2.Name = "crossSectionLine2";
            this.crossSectionLine2.Top = 0F;
            // 
            // crossSectionLine3
            // 
            this.crossSectionLine3.Bottom = 0F;
            this.crossSectionLine3.Left = 3.178F;
            this.crossSectionLine3.LineColor = System.Drawing.Color.Gainsboro;
            this.crossSectionLine3.LineWeight = 1F;
            this.crossSectionLine3.Name = "crossSectionLine3";
            this.crossSectionLine3.Top = 0F;
            // 
            // crossSectionLine4
            // 
            this.crossSectionLine4.Bottom = 0F;
            this.crossSectionLine4.Left = 4.29F;
            this.crossSectionLine4.LineColor = System.Drawing.Color.Gainsboro;
            this.crossSectionLine4.LineWeight = 1F;
            this.crossSectionLine4.Name = "crossSectionLine4";
            this.crossSectionLine4.Top = 0F;
            // 
            // crossSectionLine5
            // 
            this.crossSectionLine5.Bottom = 0F;
            this.crossSectionLine5.Left = 5.398F;
            this.crossSectionLine5.LineColor = System.Drawing.Color.Gainsboro;
            this.crossSectionLine5.LineWeight = 1F;
            this.crossSectionLine5.Name = "crossSectionLine5";
            this.crossSectionLine5.Top = 0F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // CapitalProjectsFinancing
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.645834F;
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
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expendText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encumbranceText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLongText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expendLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncumbranceLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgKeyLongLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion





















        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label orgKeyLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label budgetLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label expendLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label EncumbranceLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label balanceLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Label orgKeyLongLabel;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox orgKeyText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox budgetText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox expendText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox encumbranceText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox balanceText;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox orgKeyLongText;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox crossSectionBox1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine2;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine3;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine4;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine5;
    }
}
