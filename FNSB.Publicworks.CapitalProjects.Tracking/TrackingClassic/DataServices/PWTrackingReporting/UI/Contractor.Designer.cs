namespace FNSB.Publicworks.Projects.Reports.UI
{
    partial class Contractor
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
            this.ContractorName = new System.Windows.Forms.TextBox();
            this.selectBoxLabel = new System.Windows.Forms.Label();
            this.entityExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deleteEntity
            // 
            this.deleteEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.deleteEntity.Location = new System.Drawing.Point(337, 169);
            this.deleteEntity.Name = "deleteEntity";
            this.deleteEntity.Size = new System.Drawing.Size(90, 30);
            this.deleteEntity.TabIndex = 33;
            this.deleteEntity.Text = "&Delete";
            this.deleteEntity.UseVisualStyleBackColor = true;
            this.deleteEntity.Click += new System.EventHandler(this.DeleteEntityClick);
            // 
            // saveEntity
            // 
            this.saveEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.saveEntity.Location = new System.Drawing.Point(241, 169);
            this.saveEntity.Name = "saveEntity";
            this.saveEntity.Size = new System.Drawing.Size(90, 30);
            this.saveEntity.TabIndex = 32;
            this.saveEntity.Text = "&Save";
            this.saveEntity.UseVisualStyleBackColor = true;
            this.saveEntity.Click += new System.EventHandler(this.SaveClick);
            // 
            // clearEntity
            // 
            this.clearEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.clearEntity.Location = new System.Drawing.Point(145, 169);
            this.clearEntity.Name = "clearEntity";
            this.clearEntity.Size = new System.Drawing.Size(90, 30);
            this.clearEntity.TabIndex = 31;
            this.clearEntity.Text = "&Clear";
            this.clearEntity.UseVisualStyleBackColor = true;
            this.clearEntity.Click += new System.EventHandler(this.ClearEntityClick);
            // 
            // newEntity
            // 
            this.newEntity.Font = new System.Drawing.Font("Arial", 9F);
            this.newEntity.Location = new System.Drawing.Point(49, 169);
            this.newEntity.Name = "newEntity";
            this.newEntity.Size = new System.Drawing.Size(90, 30);
            this.newEntity.TabIndex = 30;
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
            this.entitySelect.Location = new System.Drawing.Point(115, 54);
            this.entitySelect.Name = "entitySelect";
            this.entitySelect.Size = new System.Drawing.Size(408, 25);
            this.entitySelect.TabIndex = 28;
            this.entitySelect.SelectedIndexChanged += new System.EventHandler(this.EntityComboSelectedIndexChanged);
            // 
            // ContractorName
            // 
            this.ContractorName.Font = new System.Drawing.Font("Arial", 9F);
            this.ContractorName.Location = new System.Drawing.Point(115, 90);
            this.ContractorName.Name = "ContractorName";
            this.ContractorName.Size = new System.Drawing.Size(408, 25);
            this.ContractorName.TabIndex = 29;
            this.ContractorName.TextChanged += new System.EventHandler(this.FirstNameTextChanged);
            // 
            // selectBoxLabel
            // 
            this.selectBoxLabel.AutoSize = true;
            this.selectBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectBoxLabel.Location = new System.Drawing.Point(21, 55);
            this.selectBoxLabel.Name = "selectBoxLabel";
            this.selectBoxLabel.Size = new System.Drawing.Size(88, 20);
            this.selectBoxLabel.TabIndex = 26;
            this.selectBoxLabel.Text = "Contractor";
            // 
            // entityExit
            // 
            this.entityExit.Font = new System.Drawing.Font("Arial", 9F);
            this.entityExit.Location = new System.Drawing.Point(433, 169);
            this.entityExit.Name = "entityExit";
            this.entityExit.Size = new System.Drawing.Size(90, 30);
            this.entityExit.TabIndex = 33;
            this.entityExit.Text = "&Exit";
            this.entityExit.UseVisualStyleBackColor = true;
            this.entityExit.Click += new System.EventHandler(this.ExitEntity);
            // 
            // Contractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 255);
            this.Controls.Add(this.entityExit);
            this.Controls.Add(this.deleteEntity);
            this.Controls.Add(this.saveEntity);
            this.Controls.Add(this.clearEntity);
            this.Controls.Add(this.newEntity);
            this.Controls.Add(this.entitySelect);
            this.Controls.Add(this.ContractorName);
            this.Controls.Add(this.selectBoxLabel);
            this.Name = "Contractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contractor";
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
        private System.Windows.Forms.TextBox ContractorName;
        private System.Windows.Forms.Label selectBoxLabel;
        private System.Windows.Forms.Button entityExit;
    }
}