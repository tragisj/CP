namespace PWTrackingReporting.UI
{
    partial class ActiveReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer = new GrapeCity.ActiveReports.Viewer.Win.Viewer();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.BackColor = System.Drawing.SystemColors.Control;
            this.reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Document = new GrapeCity.ActiveReports.Document.SectionDocument("ARNet Document");
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ReportViewer.CurrentPage = 0;
            this.reportViewer.ReportViewer.MultiplePageCols = 3;
            this.reportViewer.ReportViewer.MultiplePageRows = 2;
            this.reportViewer.ReportViewer.ViewType = GrapeCity.Viewer.Common.Model.ViewType.SinglePage;
            this.reportViewer.Size = new System.Drawing.Size(977, 782);
            this.reportViewer.TabIndex = 2;
            this.reportViewer.TableOfContents.Text = "Table Of Contents";
            this.reportViewer.TableOfContents.Width = 200;
            this.reportViewer.TabTitleLength = 35;
            this.reportViewer.Toolbar.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // ActiveReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 782);
            this.Controls.Add(this.reportViewer);
            this.Name = "ActiveReportViewer";
            this.Text = "TrackingViewer";
            
            this.ResumeLayout(false);

        }

        #endregion

        private GrapeCity.ActiveReports.Viewer.Win.Viewer reportViewer;


    }
}