namespace PWTrackingReporting.Reports.UI
{
    partial class DateRangeDialog
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
            this.components = new System.ComponentModel.Container();
            this.startDateMask = new System.Windows.Forms.MaskedTextBox();
            this.endDateMask = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.submitDates = new System.Windows.Forms.Button();
            this.cancelDates = new System.Windows.Forms.Button();
            this.dateError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dateError)).BeginInit();
            this.SuspendLayout();
            // 
            // startDateMask
            // 
            this.startDateMask.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateMask.Location = new System.Drawing.Point(161, 38);
            this.startDateMask.Mask = "00/00/0000";
            this.startDateMask.Name = "startDateMask";
            this.startDateMask.Size = new System.Drawing.Size(156, 28);
            this.startDateMask.TabIndex = 0;
            this.startDateMask.Validating += new System.ComponentModel.CancelEventHandler(this.StartDateMaskValidating);
            // 
            // endDateMask
            // 
            this.endDateMask.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateMask.Location = new System.Drawing.Point(161, 72);
            this.endDateMask.Mask = "00/00/0000";
            this.endDateMask.Name = "endDateMask";
            this.endDateMask.Size = new System.Drawing.Size(156, 28);
            this.endDateMask.TabIndex = 1;
            this.endDateMask.ValidatingType = typeof(System.DateTime);
            this.endDateMask.Validating += new System.ComponentModel.CancelEventHandler(this.EndDateMaskValidating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Date";
            // 
            // submitDates
            // 
            this.submitDates.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitDates.Location = new System.Drawing.Point(95, 120);
            this.submitDates.Name = "submitDates";
            this.submitDates.Size = new System.Drawing.Size(91, 28);
            this.submitDates.TabIndex = 2;
            this.submitDates.Text = "&Submit";
            this.submitDates.UseVisualStyleBackColor = true;
            this.submitDates.EnabledChanged += new System.EventHandler(this.SubmitDatesEnabledChanged);
            this.submitDates.Click += new System.EventHandler(this.SubmitDatesClick);
            // 
            // cancelDates
            // 
            this.cancelDates.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelDates.Location = new System.Drawing.Point(203, 120);
            this.cancelDates.Name = "cancelDates";
            this.cancelDates.Size = new System.Drawing.Size(91, 28);
            this.cancelDates.TabIndex = 3;
            this.cancelDates.Text = "&Cancel";
            this.cancelDates.UseVisualStyleBackColor = true;
            this.cancelDates.Click += new System.EventHandler(this.CancelDatesClick);
            // 
            // dateError
            // 
            this.dateError.ContainerControl = this;
            // 
            // DateRangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 165);
            this.Controls.Add(this.cancelDates);
            this.Controls.Add(this.submitDates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDateMask);
            this.Controls.Add(this.startDateMask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DateRangeDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Date Ranges";
            this.Load += new System.EventHandler(this.DateRangeDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dateError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox startDateMask;
        private System.Windows.Forms.MaskedTextBox endDateMask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitDates;
        private System.Windows.Forms.Button cancelDates;
        private System.Windows.Forms.ErrorProvider dateError;
    }
}