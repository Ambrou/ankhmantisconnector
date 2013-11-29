using System;
using System.Windows.Forms;
using Ankh.ExtensionPoints.IssueTracker;

namespace AnkhMantisConnector.IssueTracker.Forms
{
    public partial class ConfigurationPage : UserControl
    {
        public event EventHandler<ConfigPageEventArgs> OnPageEvent;

        private ConnectorSettings _currentSettings;
        private bool _showingAdvancedSettings;

        internal ConnectorSettings Settings
        {
            get
            {
                if (!_showingAdvancedSettings)
                    SaveSettings();

                return _currentSettings;
            }
            set
            {
                _currentSettings = value ?? new ConnectorSettings();
                SelectSettings();
            }
        }

        public ConfigurationPage()
        {
            InitializeComponent();

            Settings = new ConnectorSettings();
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
                if (cbProjects.SelectedItem != null)
                    _currentSettings.ProjectId = int.Parse(((org.mantisbt.www.ProjectData)cbProjects.SelectedItem).id);
            }
        }

        /// <summary>
        /// Populates UI with existing settings
        /// </summary>
        private void SelectSettings()
        {
            txtServerUrl.Text = _currentSettings.RepositoryUri == null ? string.Empty : _currentSettings.RepositoryUri.ToString();
            pgAdvancedSettings.SelectedObject = _currentSettings;
        }

        private void btnLoadProjects_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (var mantisConnect = new org.mantisbt.www.MantisConnect(txtServerUrl.Text + _currentSettings.WebServicePath))
            {
                    ConfigPageEventArgs args = new ConfigPageEventArgs();
                    try
                    {
                        var cred = mantisConnect.GetUserCredential();
                        if (cred != null)
                        {
                            var projects = mantisConnect.mc_projects_get_user_accessible(cred.UserName, cred.Password);

                            cbProjects.DataSource = projects;
                            cbProjects.DisplayMember = "name";
                            foreach (var project in projects)
                            {
                                if (int.Parse(project.id) == _currentSettings.ProjectId)
                                {
                                    cbProjects.SelectedItem = project;
                                    break;
                                }
                            }
                            args.IsComplete = true;
                            mantisConnect.ConfirmUserCredential(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        mantisConnect.ConfirmUserCredential(false);
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

            Cursor.Current = Cursors.Default;
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            if (!_showingAdvancedSettings)
            {
                SaveSettings();
                btnAdvanced.Text = "<< Simple";
                pnlSettings.Visible = false;
                pgAdvancedSettings.Visible = true;
                _showingAdvancedSettings = true;
            }
            else
            {
                SelectSettings();
                btnAdvanced.Text = "Advanced >>";
                pgAdvancedSettings.Visible = false;
                pnlSettings.Visible = true;
                _showingAdvancedSettings = false;
            }
        }

    }
}
