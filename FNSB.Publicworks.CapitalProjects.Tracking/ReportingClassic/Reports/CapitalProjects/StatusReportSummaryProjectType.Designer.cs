namespace FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects
{
    /// <summary>
    /// Summary description for StatusReportSummaryProjectType.
    /// </summary>
    partial class StatusReportSummaryProjectType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusReportSummaryProjectType));
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.projectManager = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.projectCount = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.totalAllocation = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.totalComplete = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.logoPicture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.statusReportLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.totalsLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.projectManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusReportLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.projectManager,
            this.projectCount,
            this.totalAllocation,
            this.totalComplete});
            this.detail.Height = 0.2291665F;
            this.detail.Name = "detail";
            // 
            // projectManager
            // 
            this.projectManager.DataField = "ProjectType";
            this.projectManager.Height = 0.169F;
            this.projectManager.Left = 0.294F;
            this.projectManager.Name = "projectManager";
            this.projectManager.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; ddo-char-set: 0";
            this.projectManager.Text = null;
            this.projectManager.Top = 0.03F;
            this.projectManager.Width = 2.01F;
            // 
            // projectCount
            // 
            this.projectCount.DataField = "Count";
            this.projectCount.Height = 0.169F;
            this.projectCount.Left = 2.38F;
            this.projectCount.Name = "projectCount";
            this.projectCount.OutputFormat = resources.GetString("projectCount.OutputFormat");
            this.projectCount.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; text-align: right; ddo-c" +
    "har-set: 0";
            this.projectCount.Text = null;
            this.projectCount.Top = 0.03F;
            this.projectCount.Width = 0.948F;
            // 
            // totalAllocation
            // 
            this.totalAllocation.DataField = "TotalAllocation";
            this.totalAllocation.Height = 0.169F;
            this.totalAllocation.Left = 3.635F;
            this.totalAllocation.Name = "totalAllocation";
            this.totalAllocation.OutputFormat = resources.GetString("totalAllocation.OutputFormat");
            this.totalAllocation.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; text-align: right; ddo-c" +
    "har-set: 0";
            this.totalAllocation.Text = null;
            this.totalAllocation.Top = 0.03F;
            this.totalAllocation.Width = 1.396F;
            // 
            // totalComplete
            // 
            this.totalComplete.DataField = "AmountComplete";
            this.totalComplete.Height = 0.169F;
            this.totalComplete.Left = 5.363F;
            this.totalComplete.Name = "totalComplete";
            this.totalComplete.OutputFormat = resources.GetString("totalComplete.OutputFormat");
            this.totalComplete.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; text-align: right; ddo-c" +
    "har-set: 0";
            this.totalComplete.Text = null;
            this.totalComplete.Top = 0.03F;
            this.totalComplete.Width = 1.541999F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.logoPicture,
            this.textBox4,
            this.line3,
            this.statusReportLabel});
            this.reportHeader1.Height = 1.207583F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // logoPicture
            // 
            this.logoPicture.Height = 0.8430001F;
            this.logoPicture.HyperLink = null;
            this.logoPicture.ImageData = ((System.IO.Stream)(resources.GetObject("logoPicture.ImageData")));
            this.logoPicture.Left = 0.294F;
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.logoPicture.Top = 0F;
            this.logoPicture.Width = 0.822F;
            // 
            // textBox4
            // 
            this.textBox4.Height = 0.267F;
            this.textBox4.Left = 1.182F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "font-family: Arial Narrow; font-size: 15.75pt; font-weight: normal; ddo-char-set:" +
    " 0";
            this.textBox4.Text = "Fairbanks North Star Borough";
            this.textBox4.Top = 0.278F;
            this.textBox4.Width = 3.584F;
            // 
            // line3
            // 
            this.line3.Height = 0F;
            this.line3.Left = 1.182F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.5930001F;
            this.line3.Width = 4.238998F;
            this.line3.X1 = 1.182F;
            this.line3.X2 = 5.420998F;
            this.line3.Y1 = 0.5930001F;
            this.line3.Y2 = 0.5930001F;
            // 
            // statusReportLabel
            // 
            this.statusReportLabel.Height = 0.3860002F;
            this.statusReportLabel.HyperLink = null;
            this.statusReportLabel.Left = 1.182F;
            this.statusReportLabel.Name = "statusReportLabel";
            this.statusReportLabel.Style = "font-family: Microsoft Sans Serif; font-size: 11.25pt; font-weight: normal; ddo-c" +
    "har-set: 0";
            this.statusReportLabel.Text = "Public Works Dept. - Project Status Report Summary\r\nProject Type $ Values\r\n";
            this.statusReportLabel.Top = 0.634F;
            this.statusReportLabel.Width = 4.239001F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.totalsLabel,
            this.line1,
            this.line2});
            this.reportFooter1.Height = 0.2604167F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // textBox1
            // 
            this.textBox1.DataField = "AmountComplete";
            this.textBox1.Height = 0.169F;
            this.textBox1.Left = 5.363F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; text-align: right; ddo-c" +
    "har-set: 0";
            this.textBox1.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.textBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.textBox1.Text = null;
            this.textBox1.Top = 0.06F;
            this.textBox1.Width = 1.541999F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "Count";
            this.textBox2.Height = 0.169F;
            this.textBox2.Left = 2.38F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; text-align: right; ddo-c" +
    "har-set: 0";
            this.textBox2.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.textBox2.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.textBox2.Text = null;
            this.textBox2.Top = 0.06F;
            this.textBox2.Width = 0.948F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "TotalAllocation";
            this.textBox3.Height = 0.169F;
            this.textBox3.Left = 3.635F;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; text-align: right; ddo-c" +
    "har-set: 0";
            this.textBox3.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.textBox3.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.textBox3.Text = null;
            this.textBox3.Top = 0.06F;
            this.textBox3.Width = 1.396F;
            // 
            // totalsLabel
            // 
            this.totalsLabel.Height = 0.18F;
            this.totalsLabel.HyperLink = null;
            this.totalsLabel.Left = 0.075F;
            this.totalsLabel.Name = "totalsLabel";
            this.totalsLabel.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 0";
            this.totalsLabel.Text = "Totals:";
            this.totalsLabel.Top = 0.05F;
            this.totalsLabel.Width = 0.615F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0.05F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.01F;
            this.line1.Width = 6.855F;
            this.line1.X1 = 0.05F;
            this.line1.X2 = 6.905F;
            this.line1.Y1 = 0.01F;
            this.line1.Y2 = 0.01F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0.05F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.03F;
            this.line2.Width = 6.855F;
            this.line2.X1 = 0.05F;
            this.line2.X2 = 6.905F;
            this.line2.Y1 = 0.03F;
            this.line2.Y2 = 0.03F;
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label2,
            this.label3,
            this.label4,
            this.label5});
            this.pageHeader.Height = 0.21875F;
            this.pageHeader.Name = "pageHeader";
            // 
            // label2
            // 
            this.label2.Height = 0.2F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.294F;
            this.label2.Name = "label2";
            this.label2.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; font-weight: bold; text-" +
    "decoration: underline; ddo-char-set: 0";
            this.label2.Text = "Project Type";
            this.label2.Top = 2.980232E-08F;
            this.label2.Width = 1.25F;
            // 
            // label3
            // 
            this.label3.Height = 0.2F;
            this.label3.HyperLink = null;
            this.label3.Left = 2.38F;
            this.label3.Name = "label3";
            this.label3.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; font-weight: bold; text-" +
    "align: right; text-decoration: underline; ddo-char-set: 0";
            this.label3.Text = "# of Projects";
            this.label3.Top = 0F;
            this.label3.Width = 0.948F;
            // 
            // label4
            // 
            this.label4.Height = 0.2F;
            this.label4.HyperLink = null;
            this.label4.Left = 3.885F;
            this.label4.Name = "label4";
            this.label4.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; font-weight: bold; text-" +
    "align: right; text-decoration: underline; ddo-char-set: 0";
            this.label4.Text = "Total Allocation";
            this.label4.Top = 0F;
            this.label4.Width = 1.146F;
            // 
            // label5
            // 
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 5.363001F;
            this.label5.Name = "label5";
            this.label5.Style = "font-family: MS Reference Sans Serif; font-size: 8.25pt; font-weight: bold; text-" +
    "align: right; text-decoration: underline; ddo-char-set: 0";
            this.label5.Text = "Total Amount Complete";
            this.label5.Top = 0F;
            this.label5.Width = 1.542F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // StatusReportSummaryProjectType
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.166667F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.FetchData += new GrapeCity.ActiveReports.SectionReport.FetchEventHandler(this.StatusReportSummaryProjectTypeFetchData);
            this.DataInitialize += new System.EventHandler(this.StatusReportSummaryProjectTypeDataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.projectManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusReportLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectManager;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectCount;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox totalAllocation;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox totalComplete;
        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Picture logoPicture;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.Line line3;
        private GrapeCity.ActiveReports.SectionReportModel.Label statusReportLabel;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.Label totalsLabel;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;
    }
}
