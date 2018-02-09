using System;
using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.Reporting.Reports
{
    /// <summary>
    /// Summary description for EstimatedBidSchedule.
    /// </summary>
    public partial class EstimatedBidSchedule : GrapeCity.ActiveReports.SectionReport
    {
        private publicworksEntities _db = new publicworksEntities();
        private List<Project> _projects;
        private Int32 _projectCount;
        private DateTime _startDefault;
        private DateTime _endDefault;

        public EstimatedBidSchedule(DateTime startDate, DateTime endDate)
        {
            //
            // Required for Windows Form Designer support
            //
            _startDefault = startDate;
            _endDefault = endDate;
            InitializeComponent();
        }

        private void EstimatedBidDataInitialize(object sender, EventArgs e)
        {

            _projects =
                _db.Projects.Where(
                    d => d.NDI_Advertise_for_Bid >= _startDefault && d.NDI_Advertise_for_Bid <= _endDefault).OrderBy(d => d.NDI_Bid_Opening).ToList();

            DataSource = _projects; //projects datasource

            dateThruLabel.Text = String.Format("{0} - {1} (Bid Opening)", _startDefault.ToShortDateString(), _endDefault.ToShortDateString());

        }

        private void EstimatedBidFetchData(object sender, FetchEventArgs eArgs)
        {


        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }
    }
}
