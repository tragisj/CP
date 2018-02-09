using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWTrackingReporting.Reports.UI
{
    public partial class DateRangeDialog : Form
    {
        public bool SelectionCancel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FormTitle { get; set; }

        public DateRangeDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// form load event that sets up the fiscal year and loads the properties with the default (current fiscal year)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateRangeDialogLoad(object sender, EventArgs e)
        {
            //tell user what dates the range is going to target
            if (FormTitle != String.Empty)
            {
                this.Text = FormTitle;
            }

            //load the properties with defaults for start/end date Current Fiscal Year
            StartDate = new DateTime(DateTime.Now.Year - 1, 7, 1);
            EndDate = new DateTime(DateTime.Now.Year, 6, 30);

            //set the masks to use the default properties
            startDateMask.Text = String.Format(StartDate.ToString(CultureInfo.InvariantCulture));
            endDateMask.Text = String.Format(EndDate.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// validation of the start date. checks for date validity and also check to prevent date swapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDateMaskValidating(object sender, CancelEventArgs e)
        {
            DateTime startdate, enddate;
            if (!DateTime.TryParse(endDateMask.Text, out enddate) ||
                !(DateTime.TryParse(startDateMask.Text, out startdate)))
            {
                submitDates.Enabled = false;
                return;
            }

            TimeSpan span = enddate.Subtract(startdate);

            if (dateError.GetError(endDateMask) != String.Empty) return;
            switch (Math.Sign(span.Days))
            {
                case -1:
                    dateError.SetError(startDateMask, "Start date exceeds the end date.");
                    submitDates.Enabled = false;
                    break;
                default:
                    dateError.SetError(startDateMask, String.Empty);
                    StartDate = startdate;
                    submitDates.Enabled = true;
                    e.Cancel = false;
                    break;
            }
        }

        /// <summary>
        /// validation of the end date. checks for date validity and also check to prevent date swapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndDateMaskValidating(object sender, CancelEventArgs e)
        {
            DateTime startdate, enddate;
            if (!DateTime.TryParse(endDateMask.Text, out enddate) ||
                !(DateTime.TryParse(startDateMask.Text, out startdate)))
            {
                submitDates.Enabled = false;
                return;
            }

            TimeSpan span = enddate.Subtract(startdate);

            if (dateError.GetError(startDateMask) != String.Empty) return;
            switch (Math.Sign(span.Days))
            {
                case -1:
                    dateError.SetError(endDateMask, "End date preceeds the start date.");
                    submitDates.Enabled = false;
                    e.Cancel = true;
                    break;
                default:
                    dateError.SetError(endDateMask, String.Empty);
                    EndDate = enddate;
                    submitDates.Enabled = true;
                    break;
            }
        }


        private void SubmitDatesClick(object sender, EventArgs e)
        {
          
            this.DialogResult = DialogResult.OK;
        }

        private void CancelDatesClick(object sender, EventArgs e)
        {
            SelectionCancel = true;
            this.Close();
        }

        private void SubmitDatesEnabledChanged(object sender, EventArgs e)
        {
            SelectionCancel = !submitDates.Enabled;
        }
    }
}
