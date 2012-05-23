using System;
using System.Windows.Forms;
using Ankh.ExtensionPoints.IssueTracker;

namespace AnkhMantisConnector.IssueTracker.Forms
{
    public partial class ConfigurationPage : UserControl
    {
        public event EventHandler<ConfigPageEventArgs> OnPageEvent;

        ConnectorSettings _currentSettings;

        internal ConnectorSettings Settings
        {
            get
            {
                SaveSettings();
                return _currentSettings;
            }
            set
            {
                _currentSettings = value;
                SelectSettings();
            }
        }

        public ConfigurationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves UI values to existing settings
        /// </summary>
        private void SaveSettings()
        {
            if (_currentSettings != null)
            {
                // TODO: TryCreate and validation
                _currentSettings.RepositoryUri = new Uri(txtServerUrl.Text);
                _currentSettings.UserName = txtUser.Text.Trim();
                _currentSettings.Password = txtPassword.Text;
                _currentSettings.ProjectId = ((org.mantisbt.www.ProjectData) cbProjects.SelectedItem).id;
            }
        }

        /// <summary>
        /// Populates UI with existing settings
        /// </summary>
        private void SelectSettings()
        {
            if (_currentSettings != null)
            {
                txtServerUrl.Text = _currentSettings.RepositoryUri.ToString();
                txtUser.Text = _currentSettings.UserName;
                txtPassword.Text = _currentSettings.Password;
            }
        }

        private void btnLoadProjects_Click(object sender, EventArgs e)
        {
            using (var mantisConnect = new org.mantisbt.www.MantisConnect(txtServerUrl.Text + "/api/soap/mantisconnect.php"))
            {
                ConfigPageEventArgs args = new ConfigPageEventArgs();
                try
                {
                    var projects = mantisConnect.mc_projects_get_user_accessible(txtUser.Text, txtPassword.Text);

                    cbProjects.DataSource = projects;
                    cbProjects.DisplayMember = "name";
                    args.IsComplete = true;
                }
                catch (Exception ex)
                {
                    args.IsComplete = false;
                    args.Exception = ex;
                    MessageBox.Show("Could not get the list of projects: " + ex.Message, "Attention",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (OnPageEvent != null)
                {
                    OnPageEvent(this, args);
                }
            }
        }

    }
}
