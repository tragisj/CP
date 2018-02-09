namespace PWTrackingReporting.Reports.Tools
{
    partial class ReportDateRange
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
            this.CancelDates = new System.Windows.Forms.Button();
            this.SubmitDates = new System.Windows.Forms.Button();
            this.StartDate = new System.Windows.Forms.MaskedTextBox();
            this.EndDate = new System.Windows.Forms.MaskedTextBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelDates
            // 
            this.CancelDates.Location = new System.Drawing.Point(167, 89);
            this.CancelDates.Name = "CancelDates";
            this.CancelDates.Size = new System.Drawing.Size(75, 23);
            this.CancelDates.TabIndex = 0;
            this.CancelDates.Text = "&Cancel";
            this.CancelDates.UseVisualStyleBackColor = true;
            // 
            // SubmitDates
            // 
            this.SubmitDates.Location = new System.Drawing.Point(86, 89);
            this.SubmitDates.Name = "SubmitDates";
            this.SubmitDates.Size = new System.Drawing.Size(75, 23);
            this.SubmitDates.TabIndex = 0;
            this.SubmitDates.Text = "&Submit";
            this.SubmitDates.UseVisualStyleBackColor = true;
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(110, 22);
            this.StartDate.Mask = "00/00/0000";
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(115, 22);
            this.StartDate.TabIndex = 1;
            this.StartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StartDate.ValidatingType = typeof(System.DateTime);
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(110, 50);
            this.EndDate.Mask = "00/00/0000";
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(115, 22);
            this.EndDate.TabIndex = 1;
            this.EndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EndDate.ValidatingType = typeof(System.DateTime);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(15, 25);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(89, 17);
            this.startLabel.TabIndex = 2;
            this.startLabel.Text = "Report Start:";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(15, 53);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(84, 17);
            this.endLabel.TabIndex = 2;
            this.endLabel.Text = "Report End:";
            // 
            // ReportDateRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 151);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.SubmitDates);
            this.Controls.Add(this.CancelDates);
            this.Name = "ReportDateRange";
            this.Text = "Report Date Range";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelDates;
        private System.Windows.Forms.Button SubmitDates;
        private System.Windows.Forms.MaskedTextBox StartDate;
        private System.Windows.Forms.MaskedTextBox EndDate;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
    }
}