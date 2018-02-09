using System;
using System.Windows.Forms;
using GrapeCity.ActiveReports;

namespace PWTrackingReporting.UI
{
    public partial class ActiveReportViewer : Form
    {
        public ActiveReportViewer()
        {
            InitializeComponent();
        }

        public ActiveReportViewer(SectionReport report)
        {
            try
            {
                if (report == null) throw new Exception("Tracking Report Viewer throwing Null exception for report");
                InitializeComponent();

                reportViewer.TableOfContents.Enabled = true;

                reportViewer.Document = report.Document;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
