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
            this.lblUser = new System.Windows.Forms.Label();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbProjects = new System.Windows.Forms.ComboBox();
            this.btnLoadProjects = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.pgAdvancedSettings = new System.Windows.Forms.PropertyGrid();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.Location = new System.Drawing.Point(11, 11);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(67, 23);
            this.lblServerUrl.TabIndex = 0;
            this.lblServerUrl.Text = "Server URL";
            this.lblServerUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(14, 37);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Username";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvanced.Location = new System.Drawing.Point(406, 171);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(81, 23);
            this.btnAdvanced.TabIndex = 9;
            this.btnAdvanced.Text = "Advanced >>";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(84, 39);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(392, 20);
            this.txtUser.TabIndex = 3;
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerUrl.Location = new System.Drawing.Point(84, 13);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(392, 20);
            this.txtServerUrl.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(84, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(392, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cbProjects
            // 
            this.cbProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjects.FormattingEnabled = true;
            this.cbProjects.Location = new System.Drawing.Point(153, 91);
            this.cbProjects.Name = "cbProjects";
            this.cbProjects.Size = new System.Drawing.Size(323, 21);
            this.cbProjects.TabIndex = 8;
            // 
            // btnLoadProjects
            // 
            this.btnLoadProjects.Location = new System.Drawing.Point(84, 89);
            this.btnLoadProjects.Name = "btnLoadProjects";
            this.btnLoadProjects.Size = new System.Drawing.Size(63, 23);
            this.btnLoadProjects.TabIndex = 7;
            this.btnLoadProjects.Text = "Load";
            this.btnLoadProjects.UseVisualStyleBackColor = true;
            this.btnLoadProjects.Click += new System.EventHandler(this.btnLoadProjects_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(17, 63);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(11, 89);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(67, 23);
            this.lblProject.TabIndex = 6;
            this.lblProject.Text = "Project";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgAdvancedSettings
            // 
            this.pgAdvancedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgAdvancedSettings.Location = new System.Drawing.Point(3, 0);
            this.pgAdvancedSettings.Name = "pgAdvancedSettings";
            this.pgAdvancedSettings.Size = new System.Drawing.Size(481, 165);
            this.pgAdvancedSettings.TabIndex = 10;
            this.pgAdvancedSettings.Visible = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.Controls.Add(this.lblProject);
            this.pnlSettings.Controls.Add(this.lblPassword);
            this.pnlSettings.Controls.Add(this.btnLoadProjects);
            this.pnlSettings.Controls.Add(this.cbProjects);
            this.pnlSettings.Controls.Add(this.txtPassword);
            this.pnlSettings.Controls.Add(this.txtServerUrl);
            this.pnlSettings.Controls.Add(this.txtUser);
            this.pnlSettings.Controls.Add(this.lblUser);
            this.pnlSettings.Controls.Add(this.lblServerUrl);
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(487, 129);
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
            this.Size = new System.Drawing.Size(490, 197);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbProjects;
        private System.Windows.Forms.Button btnLoadProjects;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.PropertyGrid pgAdvancedSettings;
        private System.Windows.Forms.Panel pnlSettings;
    }
}
