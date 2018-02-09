namespace FNSB.Publicworks.Projects.Reports.UI
{
    partial class Consultant
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
            this.deleteEntity = new System.Windows.Forms.Button();
            this.saveEntity = new System.Windows.Forms.Button();
            this.clearEntity = new System.Windows.Forms.Button();
            this.newEntity = new System.Windows.Forms.Button();
            this.entitySelect = new System.Windows.Forms.ComboBox();
            this.ConsultantName = new System.Windows.Forms.TextBox();
            this.selectBoxLabel = new System.Windows.Forms.Label();
            this.exitEntity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deleteEntity
            // 
            this.deleteEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.deleteEntity.Location = new System.Drawing.Point(322, 158);
            this.deleteEntity.Name = "deleteEntity";
            this.deleteEntity.Size = new System.Drawing.Size(90, 30);
            this.deleteEntity.TabIndex = 25;
            this.deleteEntity.Text = "&Delete";
            this.deleteEntity.UseVisualStyleBackColor = true;
            this.deleteEntity.Click += new System.EventHandler(this.DeleteEntityClick);
            // 
            // saveEntity
            // 
            this.saveEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.saveEntity.Location = new System.Drawing.Point(226, 158);
            this.saveEntity.Name = "saveEntity";
            this.saveEntity.Size = new System.Drawing.Size(90, 30);
            this.saveEntity.TabIndex = 24;
            this.saveEntity.Text = "&Save";
            this.saveEntity.UseVisualStyleBackColor = true;
            this.saveEntity.Click += new System.EventHandler(this.SaveClick);
            // 
            // clearEntity
            // 
            this.clearEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.clearEntity.Location = new System.Drawing.Point(130, 158);
            this.clearEntity.Name = "clearEntity";
            this.clearEntity.Size = new System.Drawing.Size(90, 30);
            this.clearEntity.TabIndex = 23;
            this.clearEntity.Text = "&Clear";
            this.clearEntity.UseVisualStyleBackColor = true;
            this.clearEntity.Click += new System.EventHandler(this.ClearEntityClick);
            // 
            // newEntity
            // 
            this.newEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.newEntity.Location = new System.Drawing.Point(33, 158);
            this.newEntity.Name = "newEntity";
            this.newEntity.Size = new System.Drawing.Size(90, 30);
            this.newEntity.TabIndex = 22;
            this.newEntity.Text = "&New";
            this.newEntity.UseVisualStyleBackColor = true;
            this.newEntity.Click += new System.EventHandler(this.SetupNewEntity);
            // 
            // entitySelect
            // 
            this.entitySelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.entitySelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.entitySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entitySelect.Font = new System.Drawing.Font("Arial", 9F);
            this.entitySelect.FormattingEnabled = true;
            this.entitySelect.Location = new System.Drawing.Point(109, 51);
            this.entitySelect.Name = "entitySelect";
            this.entitySelect.Size = new System.Drawing.Size(397, 25);
            this.entitySelect.TabIndex = 20;
            this.entitySelect.SelectedIndexChanged += new System.EventHandler(this.EntityComboSelectedIndexChanged);
            // 
            // ConsultantName
            // 
            this.ConsultantName.Font = new System.Drawing.Font("Arial", 9F);
            this.ConsultantName.Location = new System.Drawing.Point(109, 87);
            this.ConsultantName.Name = "ConsultantName";
            this.ConsultantName.Size = new System.Drawing.Size(397, 25);
            this.ConsultantName.TabIndex = 21;
            this.ConsultantName.TextChanged += new System.EventHandler(this.FirstNameTextChanged);
            // 
            // selectBoxLabel
            // 
            this.selectBoxLabel.AutoSize = true;
            this.selectBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectBoxLabel.Location = new System.Drawing.Point(14, 52);
            this.selectBoxLabel.Name = "selectBoxLabel";
            this.selectBoxLabel.Size = new System.Drawing.Size(89, 20);
            this.selectBoxLabel.TabIndex = 18;
            this.selectBoxLabel.Text = "Consultant";
            // 
            // exitEntity
            // 
            this.exitEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.exitEntity.Location = new System.Drawing.Point(418, 158);
            this.exitEntity.Name = "exitEntity";
            this.exitEntity.Size = new System.Drawing.Size(90, 30);
            this.exitEntity.TabIndex = 25;
            this.exitEntity.Text = "&Exit";
            this.exitEntity.UseVisualStyleBackColor = true;
            this.exitEntity.Click += new System.EventHandler(this.ExitEntity);
            // 
            // Consultant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 255);
            this.Controls.Add(this.exitEntity);
            this.Controls.Add(this.deleteEntity);
            this.Controls.Add(this.saveEntity);
            this.Controls.Add(this.clearEntity);
            this.Controls.Add(this.newEntity);
            this.Controls.Add(this.entitySelect);
            this.Controls.Add(this.ConsultantName);
            this.Controls.Add(this.selectBoxLabel);
            this.Name = "Consultant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultant";
            this.Load += new System.EventHandler(this.EntityFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteEntity;
        private System.Windows.Forms.Button saveEntity;
        private System.Windows.Forms.Button clearEntity;
        private System.Windows.Forms.Button newEntity;
        private System.Windows.Forms.ComboBox entitySelect;
        private System.Windows.Forms.TextBox ConsultantName;
        private System.Windows.Forms.Label selectBoxLabel;
        private System.Windows.Forms.Button exitEntity;
    }
}