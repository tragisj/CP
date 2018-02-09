namespace FNSB.Publicworks.Projects.Reporting.Reports.UI
{
    partial class EntityDynamicPrompt
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
            this.entitySelect = new System.Windows.Forms.ComboBox();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.uniqueRadio = new System.Windows.Forms.RadioButton();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // entitySelect
            // 
            this.entitySelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.entitySelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.entitySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entitySelect.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entitySelect.FormattingEnabled = true;
            this.entitySelect.Location = new System.Drawing.Point(31, 39);
            this.entitySelect.Margin = new System.Windows.Forms.Padding(2);
            this.entitySelect.Name = "entitySelect";
            this.entitySelect.Size = new System.Drawing.Size(288, 24);
            this.entitySelect.TabIndex = 0;
            this.entitySelect.SelectedIndexChanged += new System.EventHandler(this.EntityComboSelectedIndexChanged);
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allRadio.Location = new System.Drawing.Point(189, 11);
            this.allRadio.Margin = new System.Windows.Forms.Padding(2);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(82, 20);
            this.allRadio.TabIndex = 2;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "Select All";
            this.allRadio.UseVisualStyleBackColor = true;
            this.allRadio.CheckedChanged += new System.EventHandler(this.EntityCheckChange);
            // 
            // uniqueRadio
            // 
            this.uniqueRadio.AutoSize = true;
            this.uniqueRadio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uniqueRadio.Location = new System.Drawing.Point(49, 11);
            this.uniqueRadio.Margin = new System.Windows.Forms.Padding(2);
            this.uniqueRadio.Name = "uniqueRadio";
            this.uniqueRadio.Size = new System.Drawing.Size(129, 20);
            this.uniqueRadio.TabIndex = 2;
            this.uniqueRadio.TabStop = true;
            this.uniqueRadio.Text = "Select Individual";
            this.uniqueRadio.UseVisualStyleBackColor = true;
            this.uniqueRadio.CheckedChanged += new System.EventHandler(this.EntityCheckChange);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(176, 75);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(71, 24);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Location = new System.Drawing.Point(92, 75);
            this.submit.Margin = new System.Windows.Forms.Padding(2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(71, 24);
            this.submit.TabIndex = 3;
            this.submit.Text = "&Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.SubmitClick);
            // 
            // EntityDynamicPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 112);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.uniqueRadio);
            this.Controls.Add(this.allRadio);
            this.Controls.Add(this.entitySelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EntityDynamicPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Title";
            this.Load += new System.EventHandler(this.EntityComboSelectLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox entitySelect;
        private System.Windows.Forms.RadioButton allRadio;
        private System.Windows.Forms.RadioButton uniqueRadio;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button submit;
    }
}