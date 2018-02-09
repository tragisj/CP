namespace FNSB.Publicworks.Projects.Reporting.UI
{
    partial class FReportListing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportListing));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SecretaryButton = new System.Windows.Forms.Button();
            this.UserCommand = new System.Windows.Forms.Button();
            this.Types = new System.Windows.Forms.Button();
            this.consultCommand = new System.Windows.Forms.Button();
            this.contractorCommand = new System.Windows.Forms.Button();
            this.cmdReportProjectUpdate = new System.Windows.Forms.Button();
            this.cmdWarrentyReport = new System.Windows.Forms.Button();
            this.OrgKeys = new System.Windows.Forms.Button();
            this.ActiveSecretary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ActiveManager = new System.Windows.Forms.Button();
            this.closedProjects = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.substantialCompleteReport = new System.Windows.Forms.Button();
            this.financialsProjectNumberReport = new System.Windows.Forms.Button();
            this.architectsReportCommand = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.glkeyExceptions = new System.Windows.Forms.Button();
            this.estimatedBidCommand = new System.Windows.Forms.Button();
            this.ProjectStatus = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSecretaryProjects = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Public Works Project Tracking Reports";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(33, 108);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "Architect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(33, 139);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "Manager";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.FReportListingLoad);
            // 
            // SecretaryButton
            // 
            this.SecretaryButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SecretaryButton.Location = new System.Drawing.Point(33, 170);
            this.SecretaryButton.Margin = new System.Windows.Forms.Padding(2);
            this.SecretaryButton.Name = "SecretaryButton";
            this.SecretaryButton.Size = new System.Drawing.Size(79, 26);
            this.SecretaryButton.TabIndex = 5;
            this.SecretaryButton.Text = "Secretary";
            this.SecretaryButton.UseVisualStyleBackColor = true;
            this.SecretaryButton.Click += new System.EventHandler(this.SecretaryLoad);
            // 
            // UserCommand
            // 
            this.UserCommand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UserCommand.Location = new System.Drawing.Point(33, 201);
            this.UserCommand.Margin = new System.Windows.Forms.Padding(2);
            this.UserCommand.Name = "UserCommand";
            this.UserCommand.Size = new System.Drawing.Size(79, 26);
            this.UserCommand.TabIndex = 5;
            this.UserCommand.Text = "User";
            this.UserCommand.UseVisualStyleBackColor = true;
            this.UserCommand.Click += new System.EventHandler(this.UserLoad);
            // 
            // Types
            // 
            this.Types.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Types.Location = new System.Drawing.Point(33, 232);
            this.Types.Margin = new System.Windows.Forms.Padding(2);
            this.Types.Name = "Types";
            this.Types.Size = new System.Drawing.Size(79, 26);
            this.Types.TabIndex = 5;
            this.Types.Text = "Types";
            this.Types.UseVisualStyleBackColor = true;
            this.Types.Click += new System.EventHandler(this.TypeLoad);
            // 
            // consultCommand
            // 
            this.consultCommand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.consultCommand.Location = new System.Drawing.Point(33, 262);
            this.consultCommand.Margin = new System.Windows.Forms.Padding(2);
            this.consultCommand.Name = "consultCommand";
            this.consultCommand.Size = new System.Drawing.Size(79, 26);
            this.consultCommand.TabIndex = 5;
            this.consultCommand.Text = "Consultants";
            this.consultCommand.UseVisualStyleBackColor = true;
            this.consultCommand.Click += new System.EventHandler(this.ConsultLoad);
            // 
            // contractorCommand
            // 
            this.contractorCommand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.contractorCommand.Location = new System.Drawing.Point(33, 293);
            this.contractorCommand.Margin = new System.Windows.Forms.Padding(2);
            this.contractorCommand.Name = "contractorCommand";
            this.contractorCommand.Size = new System.Drawing.Size(79, 26);
            this.contractorCommand.TabIndex = 5;
            this.contractorCommand.Text = "Contractor";
            this.contractorCommand.UseVisualStyleBackColor = true;
            this.contractorCommand.Click += new System.EventHandler(this.ContractorLoad);
            // 
            // cmdReportProjectUpdate
            // 
            this.cmdReportProjectUpdate.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdReportProjectUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdReportProjectUpdate.Location = new System.Drawing.Point(181, 108);
            this.cmdReportProjectUpdate.Name = "cmdReportProjectUpdate";
            this.cmdReportProjectUpdate.Size = new System.Drawing.Size(79, 26);
            this.cmdReportProjectUpdate.TabIndex = 6;
            this.cmdReportProjectUpdate.Text = "Updates";
            this.cmdReportProjectUpdate.UseVisualStyleBackColor = true;
            this.cmdReportProjectUpdate.Click += new System.EventHandler(this.CmdReportProjectUpdateClick);
            // 
            // cmdWarrentyReport
            // 
            this.cmdWarrentyReport.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdWarrentyReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdWarrentyReport.Location = new System.Drawing.Point(181, 141);
            this.cmdWarrentyReport.Name = "cmdWarrentyReport";
            this.cmdWarrentyReport.Size = new System.Drawing.Size(79, 26);
            this.cmdWarrentyReport.TabIndex = 7;
            this.cmdWarrentyReport.Text = "Warrenty Period";
            this.cmdWarrentyReport.UseVisualStyleBackColor = true;
            this.cmdWarrentyReport.Click += new System.EventHandler(this.CmdWarrentyReportClick);
            // 
            // OrgKeys
            // 
            this.OrgKeys.Font = new System.Drawing.Font("Arial", 9F);
            this.OrgKeys.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OrgKeys.Location = new System.Drawing.Point(181, 173);
            this.OrgKeys.Name = "OrgKeys";
            this.OrgKeys.Size = new System.Drawing.Size(79, 26);
            this.OrgKeys.TabIndex = 8;
            this.OrgKeys.Text = "Org Keys";
            this.OrgKeys.UseVisualStyleBackColor = true;
            this.OrgKeys.Click += new System.EventHandler(this.OrgKeysClick);
            // 
            // ActiveSecretary
            // 
            this.ActiveSecretary.Font = new System.Drawing.Font("Arial", 9F);
            this.ActiveSecretary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ActiveSecretary.Location = new System.Drawing.Point(181, 206);
            this.ActiveSecretary.Name = "ActiveSecretary";
            this.ActiveSecretary.Size = new System.Drawing.Size(79, 26);
            this.ActiveSecretary.TabIndex = 9;
            this.ActiveSecretary.Text = "Secretary";
            this.ActiveSecretary.UseVisualStyleBackColor = true;
            this.ActiveSecretary.Click += new System.EventHandler(this.SecretaryReportClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(38, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Forms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(130, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Reports";
            // 
            // ActiveManager
            // 
            this.ActiveManager.Font = new System.Drawing.Font("Arial", 9F);
            this.ActiveManager.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ActiveManager.Location = new System.Drawing.Point(265, 206);
            this.ActiveManager.Name = "ActiveManager";
            this.ActiveManager.Size = new System.Drawing.Size(79, 26);
            this.ActiveManager.TabIndex = 9;
            this.ActiveManager.Text = "Manager";
            this.ActiveManager.UseVisualStyleBackColor = true;
            this.ActiveManager.Click += new System.EventHandler(this.ManagerReportClick);
            // 
            // closedProjects
            // 
            this.closedProjects.Font = new System.Drawing.Font("Arial", 9F);
            this.closedProjects.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closedProjects.Location = new System.Drawing.Point(265, 109);
            this.closedProjects.Name = "closedProjects";
            this.closedProjects.Size = new System.Drawing.Size(79, 26);
            this.closedProjects.TabIndex = 9;
            this.closedProjects.Text = "Closed";
            this.closedProjects.UseVisualStyleBackColor = true;
            this.closedProjects.Click += new System.EventHandler(this.ClosedProjectsReportClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(131, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Projects";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(131, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dates";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(131, 181);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Funding";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(131, 211);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Control";
            // 
            // substantialCompleteReport
            // 
            this.substantialCompleteReport.Font = new System.Drawing.Font("Arial", 9F);
            this.substantialCompleteReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.substantialCompleteReport.Location = new System.Drawing.Point(265, 139);
            this.substantialCompleteReport.Name = "substantialCompleteReport";
            this.substantialCompleteReport.Size = new System.Drawing.Size(79, 26);
            this.substantialCompleteReport.TabIndex = 7;
            this.substantialCompleteReport.Text = "Substantial";
            this.substantialCompleteReport.UseVisualStyleBackColor = true;
            this.substantialCompleteReport.Click += new System.EventHandler(this.SubstantialReportClick);
            // 
            // financialsProjectNumberReport
            // 
            this.financialsProjectNumberReport.Font = new System.Drawing.Font("Arial", 9F);
            this.financialsProjectNumberReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.financialsProjectNumberReport.Location = new System.Drawing.Point(265, 173);
            this.financialsProjectNumberReport.Name = "financialsProjectNumberReport";
            this.financialsProjectNumberReport.Size = new System.Drawing.Size(79, 26);
            this.financialsProjectNumberReport.TabIndex = 8;
            this.financialsProjectNumberReport.Text = "Project No.";
            this.financialsProjectNumberReport.UseVisualStyleBackColor = true;
            this.financialsProjectNumberReport.Click += new System.EventHandler(this.FinancialsProjectNumberReportClick);
            // 
            // architectsReportCommand
            // 
            this.architectsReportCommand.Font = new System.Drawing.Font("Arial", 9F);
            this.architectsReportCommand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.architectsReportCommand.Location = new System.Drawing.Point(350, 109);
            this.architectsReportCommand.Name = "architectsReportCommand";
            this.architectsReportCommand.Size = new System.Drawing.Size(79, 26);
            this.architectsReportCommand.TabIndex = 9;
            this.architectsReportCommand.Text = "Architects";
            this.architectsReportCommand.UseVisualStyleBackColor = true;
            this.architectsReportCommand.Click += new System.EventHandler(this.ActiveArchitectReportClick);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 9F);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(435, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "Project Manager";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ActiveProjectManagerReportClick);
            // 
            // glkeyExceptions
            // 
            this.glkeyExceptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.glkeyExceptions.Location = new System.Drawing.Point(33, 323);
            this.glkeyExceptions.Margin = new System.Windows.Forms.Padding(2);
            this.glkeyExceptions.Name = "glkeyExceptions";
            this.glkeyExceptions.Size = new System.Drawing.Size(79, 40);
            this.glkeyExceptions.TabIndex = 5;
            this.glkeyExceptions.Text = "GlKey Exceptions";
            this.glkeyExceptions.UseVisualStyleBackColor = true;
            this.glkeyExceptions.Click += new System.EventHandler(this.GlAcceptionsLoad);
            // 
            // estimatedBidCommand
            // 
            this.estimatedBidCommand.Font = new System.Drawing.Font("Arial", 9F);
            this.estimatedBidCommand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.estimatedBidCommand.Location = new System.Drawing.Point(350, 140);
            this.estimatedBidCommand.Name = "estimatedBidCommand";
            this.estimatedBidCommand.Size = new System.Drawing.Size(79, 26);
            this.estimatedBidCommand.TabIndex = 9;
            this.estimatedBidCommand.Text = "Estimated Bids";
            this.estimatedBidCommand.UseVisualStyleBackColor = true;
            this.estimatedBidCommand.Click += new System.EventHandler(this.EstimatedBidReportClick);
            // 
            // ProjectStatus
            // 
            this.ProjectStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.ProjectStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProjectStatus.Location = new System.Drawing.Point(552, 109);
            this.ProjectStatus.Name = "ProjectStatus";
            this.ProjectStatus.Size = new System.Drawing.Size(79, 26);
            this.ProjectStatus.TabIndex = 6;
            this.ProjectStatus.Text = "Status";
            this.ProjectStatus.UseVisualStyleBackColor = true;
            this.ProjectStatus.Click += new System.EventHandler(this.CapitalProjectStatusClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(552, 142);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "ProType Sum";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSecretaryProjects
            // 
            this.btnSecretaryProjects.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSecretaryProjects.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSecretaryProjects.Location = new System.Drawing.Point(637, 109);
            this.btnSecretaryProjects.Name = "btnSecretaryProjects";
            this.btnSecretaryProjects.Size = new System.Drawing.Size(79, 50);
            this.btnSecretaryProjects.TabIndex = 13;
            this.btnSecretaryProjects.Text = "Secretary Projects";
            this.btnSecretaryProjects.UseVisualStyleBackColor = true;
            this.btnSecretaryProjects.Click += new System.EventHandler(this.SecretaryProjectsReportClick);
            // 
            // FReportListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 524);
            this.Controls.Add(this.btnSecretaryProjects);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.estimatedBidCommand);
            this.Controls.Add(this.architectsReportCommand);
            this.Controls.Add(this.closedProjects);
            this.Controls.Add(this.ActiveManager);
            this.Controls.Add(this.ActiveSecretary);
            this.Controls.Add(this.financialsProjectNumberReport);
            this.Controls.Add(this.OrgKeys);
            this.Controls.Add(this.substantialCompleteReport);
            this.Controls.Add(this.cmdWarrentyReport);
            this.Controls.Add(this.ProjectStatus);
            this.Controls.Add(this.cmdReportProjectUpdate);
            this.Controls.Add(this.glkeyExceptions);
            this.Controls.Add(this.contractorCommand);
            this.Controls.Add(this.consultCommand);
            this.Controls.Add(this.Types);
            this.Controls.Add(this.UserCommand);
            this.Controls.Add(this.SecretaryButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "FReportListing";
            this.Text = "ActiveReportListing";
            this.Load += new System.EventHandler(this.FReportListing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SecretaryButton;
        private System.Windows.Forms.Button UserCommand;
        private System.Windows.Forms.Button Types;
        private System.Windows.Forms.Button consultCommand;
        private System.Windows.Forms.Button contractorCommand;
        private System.Windows.Forms.Button cmdReportProjectUpdate;
        private System.Windows.Forms.Button cmdWarrentyReport;
        private System.Windows.Forms.Button OrgKeys;
        private System.Windows.Forms.Button ActiveSecretary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ActiveManager;
        private System.Windows.Forms.Button closedProjects;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button substantialCompleteReport;
        private System.Windows.Forms.Button financialsProjectNumberReport;
        private System.Windows.Forms.Button architectsReportCommand;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button glkeyExceptions;
        private System.Windows.Forms.Button estimatedBidCommand;
        private System.Windows.Forms.Button ProjectStatus;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSecretaryProjects;

    }
}