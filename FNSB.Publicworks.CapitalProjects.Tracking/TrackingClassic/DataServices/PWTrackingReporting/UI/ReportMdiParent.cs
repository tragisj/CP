using System;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.Reporting.UI;

namespace PWTrackingReporting.UI
{
    public partial class ActiveReportParent : Form
    {

        private FReportListing _reportListing;

        public ActiveReportParent()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            //load the guide form
            _reportListing = new FReportListing { WindowState = FormWindowState.Maximized, MdiParent = this };
            _reportListing.Show();
        }
    }
}
