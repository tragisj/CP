namespace FNSB.Publicworks.Projects.Reports.UI
{
    partial class ArchitectEngineer
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
            this.selectBoxLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.architectFirst = new System.Windows.Forms.TextBox();
            this.architectLast = new System.Windows.Forms.TextBox();
            this.architectCombo = new System.Windows.Forms.ComboBox();
            this.newArchitect = new System.Windows.Forms.Button();
            this.saveArchitect = new System.Windows.Forms.Button();
            this.clearArchitect = new System.Windows.Forms.Button();
            this.deleteArchitect = new System.Windows.Forms.Button();
            this.exitArchitect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectBoxLabel
            // 
            this.selectBoxLabel.AutoSize = true;
            this.selectBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectBoxLabel.Location = new System.Drawing.Point(23, 43);
            this.selectBoxLabel.Name = "selectBoxLabel";
            this.selectBoxLabel.Size = new System.Drawing.Size(157, 20);
            this.selectBoxLabel.TabIndex = 0;
            this.selectBoxLabel.Text = "Architect / Engineer";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstNameLabel.Location = new System.Drawing.Point(77, 74);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(92, 20);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lastNameLabel.Location = new System.Drawing.Point(77, 107);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(91, 20);
            this.lastNameLabel.TabIndex = 0;
            this.lastNameLabel.Text = "Last Name";
            // 
            // architectFirst
            // 
            this.architectFirst.Font = new System.Drawing.Font("Arial", 9F);
            this.architectFirst.Location = new System.Drawing.Point(186, 73);
            this.architectFirst.Name = "architectFirst";
            this.architectFirst.Size = new System.Drawing.Size(184, 25);
            this.architectFirst.TabIndex = 1;
            this.architectFirst.TextChanged += new System.EventHandler(this.ArchitectFirstTextChanged);
            // 
            // architectLast
            // 
            this.architectLast.Font = new System.Drawing.Font("Arial", 9F);
            this.architectLast.Location = new System.Drawing.Point(186, 106);
            this.architectLast.Name = "architectLast";
            this.architectLast.Size = new System.Drawing.Size(184, 25);
            this.architectLast.TabIndex = 2;
            this.architectLast.TextChanged += new System.EventHandler(this.ArchitectLastTextChanged);
            // 
            // architectCombo
            // 
            this.architectCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.architectCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.architectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.architectCombo.Font = new System.Drawing.Font("Arial", 9F);
            this.architectCombo.FormattingEnabled = true;
            this.architectCombo.Location = new System.Drawing.Point(186, 42);
            this.architectCombo.Name = "architectCombo";
            this.architectCombo.Size = new System.Drawing.Size(328, 25);
            this.architectCombo.TabIndex = 0;
            this.architectCombo.SelectedIndexChanged += new System.EventHandler(this.ArchitectComboSelectedIndexChanged);
            // 
            // newArchitect
            // 
            this.newArchitect.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newArchitect.Location = new System.Drawing.Point(40, 180);
            this.newArchitect.Name = "newArchitect";
            this.newArchitect.Size = new System.Drawing.Size(90, 30);
            this.newArchitect.TabIndex = 3;
            this.newArchitect.Text = "&New";
            this.newArchitect.UseVisualStyleBackColor = true;
            this.newArchitect.Click += new System.EventHandler(this.SetupNewArchitect);
            // 
            // saveArchitect
            // 
            this.saveArchitect.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveArchitect.Location = new System.Drawing.Point(232, 180);
            this.saveArchitect.Name = "saveArchitect";
            this.saveArchitect.Size = new System.Drawing.Size(90, 30);
            this.saveArchitect.TabIndex = 5;
            this.saveArchitect.Text = "&Save";
            this.saveArchitect.UseVisualStyleBackColor = true;
            this.saveArchitect.Click += new System.EventHandler(this.SaveArchitectClick);
            // 
            // clearArchitect
            // 
            this.clearArchitect.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearArchitect.Location = new System.Drawing.Point(136, 180);
            this.clearArchitect.Name = "clearArchitect";
            this.clearArchitect.Size = new System.Drawing.Size(90, 30);
            this.clearArchitect.TabIndex = 4;
            this.clearArchitect.Text = "&Clear";
            this.clearArchitect.UseVisualStyleBackColor = true;
            this.clearArchitect.Click += new System.EventHandler(this.ClearArchitectClick);
            // 
            // deleteArchitect
            // 
            this.deleteArchitect.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteArchitect.Location = new System.Drawing.Point(328, 180);
            this.deleteArchitect.Name = "deleteArchitect";
            this.deleteArchitect.Size = new System.Drawing.Size(90, 30);
            this.deleteArchitect.TabIndex = 6;
            this.deleteArchitect.Text = "&Delete";
            this.deleteArchitect.UseVisualStyleBackColor = true;
            this.deleteArchitect.Click += new System.EventHandler(this.DeleteArchitectClick);
            // 
            // exitArchitect
            // 
            this.exitArchitect.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitArchitect.Location = new System.Drawing.Point(424, 180);
            this.exitArchitect.Name = "exitArchitect";
            this.exitArchitect.Size = new System.Drawing.Size(90, 30);
            this.exitArchitect.TabIndex = 7;
            this.exitArchitect.Text = "&Exit";
            this.exitArchitect.UseVisualStyleBackColor = true;
            this.exitArchitect.Click += new System.EventHandler(this.ExitArchitect);
            // 
            // ArchitectEngineer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 255);
            this.Controls.Add(this.exitArchitect);
            this.Controls.Add(this.deleteArchitect);
            this.Controls.Add(this.saveArchitect);
            this.Controls.Add(this.clearArchitect);
            this.Controls.Add(this.newArchitect);
            this.Controls.Add(this.architectCombo);
            this.Controls.Add(this.architectLast);
            this.Controls.Add(this.architectFirst);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.selectBoxLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ArchitectEngineer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Architect and Engineer";
            this.Load += new System.EventHandler(this.ArchitectManagerLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectBoxLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox architectFirst;
        private System.Windows.Forms.TextBox architectLast;
        private System.Windows.Forms.ComboBox architectCombo;
        private System.Windows.Forms.Button newArchitect;
        private System.Windows.Forms.Button saveArchitect;
        private System.Windows.Forms.Button clearArchitect;
        private System.Windows.Forms.Button deleteArchitect;
        private System.Windows.Forms.Button exitArchitect;


    }
}