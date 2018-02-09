namespace FNSB.Publicworks.Projects.Reports.UI
{
    partial class ImportAcceptionManager
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
            this.acceptionsListBox = new System.Windows.Forms.ListView();
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.blockDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.glkeyText = new System.Windows.Forms.TextBox();
            this.descText = new System.Windows.Forms.TextBox();
            this.keyBlockLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newCommand = new System.Windows.Forms.Button();
            this.saveCommand = new System.Windows.Forms.Button();
            this.deleteCommand = new System.Windows.Forms.Button();
            this.exitCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // acceptionsListBox
            // 
            this.acceptionsListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Key,
            this.blockDesc});
            this.acceptionsListBox.FullRowSelect = true;
            this.acceptionsListBox.GridLines = true;
            this.acceptionsListBox.Location = new System.Drawing.Point(23, 12);
            this.acceptionsListBox.MultiSelect = false;
            this.acceptionsListBox.Name = "acceptionsListBox";
            this.acceptionsListBox.Size = new System.Drawing.Size(337, 206);
            this.acceptionsListBox.TabIndex = 0;
            this.acceptionsListBox.UseCompatibleStateImageBehavior = false;
            this.acceptionsListBox.View = System.Windows.Forms.View.Details;
            // 
            // Key
            // 
            this.Key.Text = "Blocked Key";
            this.Key.Width = 121;
            // 
            // blockDesc
            // 
            this.blockDesc.Text = "Reason";
            this.blockDesc.Width = 220;
            // 
            // glkeyText
            // 
            this.glkeyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glkeyText.Location = new System.Drawing.Point(91, 237);
            this.glkeyText.Name = "glkeyText";
            this.glkeyText.Size = new System.Drawing.Size(85, 21);
            this.glkeyText.TabIndex = 1;
            this.glkeyText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GlkeyTextKeyUp);
            // 
            // descText
            // 
            this.descText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descText.Location = new System.Drawing.Point(91, 264);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(258, 21);
            this.descText.TabIndex = 1;
            this.descText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DescTextKeyUp);
            // 
            // keyBlockLabel
            // 
            this.keyBlockLabel.AutoSize = true;
            this.keyBlockLabel.Location = new System.Drawing.Point(13, 242);
            this.keyBlockLabel.Name = "keyBlockLabel";
            this.keyBlockLabel.Size = new System.Drawing.Size(72, 13);
            this.keyBlockLabel.TabIndex = 2;
            this.keyBlockLabel.Text = "GL Key Block";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Block Desc.";
            // 
            // newCommand
            // 
            this.newCommand.Location = new System.Drawing.Point(23, 313);
            this.newCommand.Name = "newCommand";
            this.newCommand.Size = new System.Drawing.Size(68, 24);
            this.newCommand.TabIndex = 3;
            this.newCommand.Text = "&New";
            this.newCommand.UseVisualStyleBackColor = true;
            this.newCommand.Click += new System.EventHandler(this.NewCommandClick);
            // 
            // saveCommand
            // 
            this.saveCommand.Location = new System.Drawing.Point(97, 313);
            this.saveCommand.Name = "saveCommand";
            this.saveCommand.Size = new System.Drawing.Size(68, 24);
            this.saveCommand.TabIndex = 3;
            this.saveCommand.Text = "&Save";
            this.saveCommand.UseVisualStyleBackColor = true;
            this.saveCommand.Click += new System.EventHandler(this.SaveCommandClick);
            // 
            // deleteCommand
            // 
            this.deleteCommand.Location = new System.Drawing.Point(171, 313);
            this.deleteCommand.Name = "deleteCommand";
            this.deleteCommand.Size = new System.Drawing.Size(68, 24);
            this.deleteCommand.TabIndex = 3;
            this.deleteCommand.Text = "&Delete";
            this.deleteCommand.UseVisualStyleBackColor = true;
            this.deleteCommand.Click += new System.EventHandler(this.DeleteCommandClick);
            // 
            // exitCommand
            // 
            this.exitCommand.Location = new System.Drawing.Point(245, 313);
            this.exitCommand.Name = "exitCommand";
            this.exitCommand.Size = new System.Drawing.Size(68, 24);
            this.exitCommand.TabIndex = 3;
            this.exitCommand.Text = "&Exit";
            this.exitCommand.UseVisualStyleBackColor = true;
            this.exitCommand.Click += new System.EventHandler(this.ExitCommandClick);
            // 
            // ImportAcceptionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 349);
            this.Controls.Add(this.exitCommand);
            this.Controls.Add(this.deleteCommand);
            this.Controls.Add(this.saveCommand);
            this.Controls.Add(this.newCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyBlockLabel);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.glkeyText);
            this.Controls.Add(this.acceptionsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportAcceptionManager";
            this.Text = "Tracking - Import Acceptions";
            this.Load += new System.EventHandler(this.ImportAcceptionManagerLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView acceptionsListBox;
        private System.Windows.Forms.TextBox glkeyText;
        private System.Windows.Forms.TextBox descText;
        private System.Windows.Forms.Label keyBlockLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader blockDesc;
        private System.Windows.Forms.Button newCommand;
        private System.Windows.Forms.Button saveCommand;
        private System.Windows.Forms.Button deleteCommand;
        private System.Windows.Forms.Button exitCommand;

    }
}