namespace AnkhMantisConnector.IssueTracker.Forms
{
    partial class ConfigurationPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblServerUrl = new System.Windows.Forms.Label();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.cbProjects = new System.Windows.Forms.ComboBox();
            this.btnLoadProjects = new System.Windows.Forms.Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.pgAdvancedSettings = new System.Windows.Forms.PropertyGrid();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.Location = new System.Drawing.Point(3, 1);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(67, 23);
            this.lblServerUrl.TabIndex = 0;
            this.lblServerUrl.Text = "Server URL";
            this.lblServerUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvanced.Location = new System.Drawing.Point(303, 195);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(81, 23);
            this.btnAdvanced.TabIndex = 9;
            this.btnAdvanced.Text = "Advanced >>";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerUrl.Location = new System.Drawing.Point(76, 3);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(308, 20);
            this.txtServerUrl.TabIndex = 1;
            // 
            // cbProjects
            // 
            this.cbProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjects.FormattingEnabled = true;
            this.cbProjects.Location = new System.Drawing.Point(145, 29);
            this.cbProjects.Name = "cbProjects";
            this.cbProjects.Size = new System.Drawing.Size(239, 21);
            this.cbProjects.TabIndex = 8;
            // 
            // btnLoadProjects
            // 
            this.btnLoadProjects.Location = new System.Drawing.Point(76, 29);
            this.btnLoadProjects.Name = "btnLoadProjects";
            this.btnLoadProjects.Size = new System.Drawing.Size(63, 23);
            this.btnLoadProjects.TabIndex = 7;
            this.btnLoadProjects.Text = "Load";
            this.btnLoadProjects.UseVisualStyleBackColor = true;
            this.btnLoadProjects.Click += new System.EventHandler(this.btnLoadProjects_Click);
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(3, 27);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(67, 23);
            this.lblProject.TabIndex = 6;
            this.lblProject.Text = "Project";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgAdvancedSettings
            // 
            this.pgAdvancedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgAdvancedSettings.Location = new System.Drawing.Point(3, 3);
            this.pgAdvancedSettings.Name = "pgAdvancedSettings";
            this.pgAdvancedSettings.Size = new System.Drawing.Size(384, 186);
            this.pgAdvancedSettings.TabIndex = 10;
            this.pgAdvancedSettings.Visible = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.Controls.Add(this.lblProject);
            this.pnlSettings.Controls.Add(this.btnLoadProjects);
            this.pnlSettings.Controls.Add(this.cbProjects);
            this.pnlSettings.Controls.Add(this.txtServerUrl);
            this.pnlSettings.Controls.Add(this.lblServerUrl);
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(387, 55);
            this.pnlSettings.TabIndex = 11;
            // 
            // ConfigurationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pgAdvancedSettings);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.btnAdvanced);
            this.Name = "ConfigurationPage";
            this.Size = new System.Drawing.Size(390, 221);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.ComboBox cbProjects;
        private System.Windows.Forms.Button btnLoadProjects;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.PropertyGrid pgAdvancedSettings;
        private System.Windows.Forms.Panel pnlSettings;
    }
}
