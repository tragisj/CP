namespace FNSB.Publicworks.Projects.Reports.UI
{
    partial class ProjectUser
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
            this.exitEntity = new System.Windows.Forms.Button();
            this.deleteEntity = new System.Windows.Forms.Button();
            this.saveEntity = new System.Windows.Forms.Button();
            this.clearEntity = new System.Windows.Forms.Button();
            this.newEntity = new System.Windows.Forms.Button();
            this.entitySelect = new System.Windows.Forms.ComboBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.selectBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitEntity
            // 
            this.exitEntity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitEntity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.exitEntity.Location = new System.Drawing.Point(431, 176);
            this.exitEntity.Name = "exitEntity";
            this.exitEntity.Size = new System.Drawing.Size(90, 30);
            this.exitEntity.TabIndex = 40;
            this.exitEntity.Text = "&Exit";
            this.exitEntity.UseVisualStyleBackColor = true;
            this.exitEntity.Click += new System.EventHandler(this.ExitEntity);
            // 
            // deleteEntity
            // 
            this.deleteEntity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteEntity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleteEntity.Location = new System.Drawing.Point(335, 176);
            this.deleteEntity.Name = "deleteEntity";
            this.deleteEntity.Size = new System.Drawing.Size(90, 30);
            this.deleteEntity.TabIndex = 39;
            this.deleteEntity.Text = "&Delete";
            this.deleteEntity.UseVisualStyleBackColor = true;
            this.deleteEntity.Click += new System.EventHandler(this.DeleteEntityClick);
            // 
            // saveEntity
            // 
            this.saveEntity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveEntity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveEntity.Location = new System.Drawing.Point(239, 176);
            this.saveEntity.Name = "saveEntity";
            this.saveEntity.Size = new System.Drawing.Size(90, 30);
            this.saveEntity.TabIndex = 38;
            this.saveEntity.Text = "&Save";
            this.saveEntity.UseVisualStyleBackColor = true;
            this.saveEntity.Click += new System.EventHandler(this.SaveClick);
            // 
            // clearEntity
            // 
            this.clearEntity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearEntity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clearEntity.Location = new System.Drawing.Point(143, 176);
            this.clearEntity.Name = "clearEntity";
            this.clearEntity.Size = new System.Drawing.Size(90, 30);
            this.clearEntity.TabIndex = 37;
            this.clearEntity.Text = "&Clear";
            this.clearEntity.UseVisualStyleBackColor = true;
            this.clearEntity.Click += new System.EventHandler(this.ClearEntityClick);
            // 
            // newEntity
            // 
            this.newEntity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEntity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.newEntity.Location = new System.Drawing.Point(47, 176);
            this.newEntity.Name = "newEntity";
            this.newEntity.Size = new System.Drawing.Size(90, 30);
            this.newEntity.TabIndex = 36;
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
            this.entitySelect.Location = new System.Drawing.Point(143, 39);
            this.entitySelect.Name = "entitySelect";
            this.entitySelect.Size = new System.Drawing.Size(378, 25);
            this.entitySelect.TabIndex = 33;
            this.entitySelect.SelectedIndexChanged += new System.EventHandler(this.EntityComboSelectedIndexChanged);
            // 
            // lastName
            // 
            this.lastName.Font = new System.Drawing.Font("Arial", 9F);
            this.lastName.Location = new System.Drawing.Point(143, 104);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(282, 25);
            this.lastName.TabIndex = 35;
            this.lastName.TextChanged += new System.EventHandler(this.LastNameTextChanged);
            // 
            // firstName
            // 
            this.firstName.Font = new System.Drawing.Font("Arial", 9F);
            this.firstName.Location = new System.Drawing.Point(144, 75);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(281, 25);
            this.firstName.TabIndex = 34;
            this.firstName.TextChanged += new System.EventHandler(this.FirstNameTextChanged);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lastNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lastNameLabel.Location = new System.Drawing.Point(45, 105);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(91, 20);
            this.lastNameLabel.TabIndex = 31;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.firstNameLabel.Location = new System.Drawing.Point(44, 73);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(92, 20);
            this.firstNameLabel.TabIndex = 32;
            this.firstNameLabel.Text = "First Name";
            // 
            // selectBoxLabel
            // 
            this.selectBoxLabel.AutoSize = true;
            this.selectBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectBoxLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectBoxLabel.Location = new System.Drawing.Point(34, 40);
            this.selectBoxLabel.Name = "selectBoxLabel";
            this.selectBoxLabel.Size = new System.Drawing.Size(103, 20);
            this.selectBoxLabel.TabIndex = 30;
            this.selectBoxLabel.Text = "Project User";
            // 
            // ProjectUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 255);
            this.Controls.Add(this.exitEntity);
            this.Controls.Add(this.deleteEntity);
            this.Controls.Add(this.saveEntity);
            this.Controls.Add(this.clearEntity);
            this.Controls.Add(this.newEntity);
            this.Controls.Add(this.entitySelect);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.selectBoxLabel);
            this.Name = "ProjectUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project User";
            this.Load += new System.EventHandler(this.EntityFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitEntity;
        private System.Windows.Forms.Button deleteEntity;
        private System.Windows.Forms.Button saveEntity;
        private System.Windows.Forms.Button clearEntity;
        private System.Windows.Forms.Button newEntity;
        private System.Windows.Forms.ComboBox entitySelect;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label selectBoxLabel;
    }
}