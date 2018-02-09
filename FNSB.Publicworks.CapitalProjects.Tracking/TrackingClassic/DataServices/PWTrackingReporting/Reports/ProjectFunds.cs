using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace PWTrackingReporting.Reports
{
    /// <summary>
    /// Summary description for ProjectFunds.
    /// </summary>
    public partial class ProjectFunds : GrapeCity.ActiveReports.SectionReport
    {
        public ProjectFunds()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }
    }
}
