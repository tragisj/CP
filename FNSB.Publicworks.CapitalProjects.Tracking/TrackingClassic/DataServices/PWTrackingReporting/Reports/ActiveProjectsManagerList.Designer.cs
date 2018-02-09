namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for ActiveProjectsManager.
    /// </summary>
    partial class ActiveProjectsManagerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveProjectsManagerList));
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.projectName = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.projectNumber = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.projectManager = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.pageNumberInfo = new GrapeCity.ActiveReports.SectionReportModel.ReportInfo();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.labelProject = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.labelProjectName = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.secretaryLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.reportHeader1 = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.reportFooter1 = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.daterunReportInfo = new GrapeCity.ActiveReports.SectionReportModel.ReportInfo();
            this.managerTitleName = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Title = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.projectCount = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.mastImage = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.mastLabel = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.projectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProjectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretaryLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterunReportInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managerTitleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mastImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mastLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.projectName,
            this.projectNumber,
            this.projectManager});
            this.detail.Height = 0.2336666F;
            this.detail.Name = "detail";
            // 
            // projectName
            // 
            this.projectName.DataField = "ProjectName";
            this.projectName.Height = 0.2F;
            this.projectName.Left = 1.05F;
            this.projectName.MultiLine = false;
            this.projectName.Name = "projectName";
            this.projectName.Style = "font-size: 9pt; ddo-char-set: 0";
            this.projectName.Text = null;
            this.projectName.Top = 0.011F;
            this.projectName.Width = 4.483001F;
            // 
            // projectNumber
            // 
            this.projectNumber.DataField = "ProjectNumber";
            this.projectNumber.Height = 0.2F;
            this.projectNumber.Left = 0.032F;
            this.projectNumber.Name = "projectNumber";
            this.projectNumber.Style = "font-size: 9pt; ddo-char-set: 0";
            this.projectNumber.Text = null;
            this.projectNumber.Top = 0.011F;
            this.projectNumber.Width = 0.921F;
            // 
            // projectManager
            // 
            this.projectManager.DataField = "Secretary";
            this.projectManager.Height = 0.2F;
            this.projectManager.Left = 5.848F;
            this.projectManager.Name = "projectManager";
            this.projectManager.Style = "font-size: 9pt; ddo-char-set: 0";
            this.projectManager.Text = null;
            this.projectManager.Top = 0.011F;
            this.projectManager.Width = 1.13F;
            // 
            // pageHeader
            // 
            this.pageHeader.BackColor = System.Drawing.Color.Gainsboro;
            this.pageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.labelProject,
            this.labelProjectName,
            this.secretaryLabel});
            this.pageHeader.Height = 0.254F;
            this.pageHeader.Name = "pageHeader";
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.pageNumberInfo});
            this.pageFooter.Height = 0.275F;
            this.pageFooter.Name = "pageFooter";
            // 
            // pageNumberInfo
            // 
            this.pageNumberInfo.FormatString = "Page {PageNumber} of {PageCount}";
            this.pageNumberInfo.Height = 0.2F;
            this.pageNumberInfo.Left = 2.67F;
            this.pageNumberInfo.Name = "pageNumberInfo";
            this.pageNumberInfo.Style = "font-size: 7pt";
            this.pageNumberInfo.Top = 0.024F;
            this.pageNumberInfo.Width = 1.717F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.managerTitleName,
            this.Title,
            this.projectCount,
            this.label1});
            this.groupHeader1.DataField = "Manager";
            this.groupHeader1.Height = 0.2875F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.GroupHeader1Format);
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0.07291664F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // labelProject
            // 
            this.labelProject.Height = 0.187F;
            this.labelProject.HyperLink = null;
            this.labelProject.Left = 0.032F;
            this.labelProject.Name = "labelProject";
            this.labelProject.Style = "font-family: Arial; font-size: 9pt; font-weight: bold; text-align: left; ddo-char" +
    "-set: 0";
            this.labelProject.Text = "Project ProjectNumber";
            this.labelProject.Top = 0.027F;
            this.labelProject.Width = 0.9F;
            // 
            // labelProjectName
            // 
            this.labelProjectName.Height = 0.187F;
            this.labelProjectName.HyperLink = null;
            this.labelProjectName.Left = 1.05F;
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Style = "font-family: Arial; font-size: 9pt; font-weight: bold; ddo-char-set: 0";
            this.labelProjectName.Text = "Project Name";
            this.labelProjectName.Top = 0.029F;
            this.labelProjectName.Width = 1.057F;
            // 
            // secretaryLabel
            // 
            this.secretaryLabel.Height = 0.195F;
            this.secretaryLabel.HyperLink = null;
            this.secretaryLabel.Left = 5.848F;
            this.secretaryLabel.Name = "secretaryLabel";
            this.secretaryLabel.Style = "font-family: Arial; font-size: 9pt; font-weight: bold; ddo-char-set: 0";
            this.secretaryLabel.Text = "Secretary";
            this.secretaryLabel.Top = 0.03F;
            this.secretaryLabel.Width = 0.97F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.daterunReportInfo,
            this.mastImage,
            this.mastLabel});
            this.reportHeader1.Height = 0.7496666F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // daterunReportInfo
            // 
            this.daterunReportInfo.FormatString = "{RunDateTime:M/d/yyyy}";
            this.daterunReportInfo.Height = 0.2F;
            this.daterunReportInfo.Left = 5.99F;
            this.daterunReportInfo.Name = "daterunReportInfo";
            this.daterunReportInfo.Style = "font-size: 7pt; text-align: right";
            this.daterunReportInfo.Top = 0.083F;
            this.daterunReportInfo.Width = 1.242F;
            // 
            // managerTitleName
            // 
            this.managerTitleName.DataField = "Manager";
            this.managerTitleName.Height = 0.225F;
            this.managerTitleName.Left = 1.355F;
            this.managerTitleName.Name = "managerTitleName";
            this.managerTitleName.Style = "font-family: MS Reference Sans Serif; font-size: 9.75pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.managerTitleName.Text = null;
            this.managerTitleName.Top = 0.032F;
            this.managerTitleName.Width = 1.99F;
            // 
            // Title
            // 
            this.Title.Height = 0.225F;
            this.Title.HyperLink = null;
            this.Title.Left = 0.03200001F;
            this.Title.Name = "Title";
            this.Title.Style = "font-family: MS Reference Sans Serif; font-size: 9.75pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.Title.Text = "Project Manager:";
            this.Title.Top = 0.032F;
            this.Title.Width = 1.278F;
            // 
            // projectCount
            // 
            this.projectCount.DataField = "ProjectCount";
            this.projectCount.Height = 0.225F;
            this.projectCount.Left = 4.012F;
            this.projectCount.Name = "projectCount";
            this.projectCount.RightToLeft = true;
            this.projectCount.Style = "color: Black; font-family: MS Reference Sans Serif; font-size: 9.75pt; font-style" +
    ": normal; font-weight: bold; text-align: right; text-decoration: none; ddo-char-" +
    "set: 1";
            this.projectCount.Text = null;
            this.projectCount.Top = 0.032F;
            this.projectCount.Width = 0.25F;
            // 
            // mastImage
            // 
            this.mastImage.Height = 0.5620001F;
            this.mastImage.ImageData = ((System.IO.Stream)(resources.GetObject("mastImage.ImageData")));
            this.mastImage.Left = 0.135F;
            this.mastImage.Name = "mastImage";
            this.mastImage.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.mastImage.Top = 0.083F;
            this.mastImage.Width = 0.738F;
            // 
            // mastLabel
            // 
            this.mastLabel.Height = 0.335F;
            this.mastLabel.HyperLink = null;
            this.mastLabel.Left = 0.9530001F;
            this.mastLabel.Name = "mastLabel";
            this.mastLabel.Style = "font-family: Tahoma; font-size: 18pt; ddo-char-set: 1";
            this.mastLabel.Text = "Active Projects  - Managers List";
            this.mastLabel.Top = 0.083F;
            this.mastLabel.Width = 3.573F;
            // 
            // label1
            // 
            this.label1.Height = 0.225F;
            this.label1.HyperLink = null;
            this.label1.Left = 3.425F;
            this.label1.Name = "label1";
            this.label1.Style = "font-family: MS Reference Sans Serif; font-size: 9.75pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label1.Text = "Count:";
            this.label1.Top = 0.032F;
            this.label1.Width = 0.5380001F;
            // 
            // ActiveProjectsManagerList
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.4F;
            this.PageSettings.Margins.Top = 0.95F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.500667F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.FetchData += new GrapeCity.ActiveReports.SectionReport.FetchEventHandler(this.ActiveProjectsManagerFetchData);
            this.DataInitialize += new System.EventHandler(this.ActiveProjectsManagerDataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.projectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProjectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretaryLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterunReportInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managerTitleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mastImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mastLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion























        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectName;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectNumber;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectManager;
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox titleName;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportInfo pageNumberInfo;
        private GrapeCity.ActiveReports.SectionReportModel.Label labelProject;
        private GrapeCity.ActiveReports.SectionReportModel.Label labelProjectName;
        private GrapeCity.ActiveReports.SectionReportModel.Label secretaryLabel;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox managerTitleName;
        private GrapeCity.ActiveReports.SectionReportModel.Label Title;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox projectCount;
        private GrapeCity.ActiveReports.SectionReportModel.ReportHeader reportHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.ReportInfo daterunReportInfo;
        private GrapeCity.ActiveReports.SectionReportModel.Picture mastImage;
        private GrapeCity.ActiveReports.SectionReportModel.Label mastLabel;
        private GrapeCity.ActiveReports.SectionReportModel.ReportFooter reportFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;

    }
}
