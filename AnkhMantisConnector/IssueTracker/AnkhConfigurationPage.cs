using System;
using System.Windows.Forms;
using Ankh.ExtensionPoints.IssueTracker;
using AnkhMantisConnector.IssueTracker.Forms;

namespace AnkhMantisConnector.IssueTracker
{
    /// <summary>
    /// Configuration page 
    /// </summary>
    class AnkhConfigurationPage : IssueRepositoryConfigurationPage, IWin32Window
    {
        IssueRepositorySettings _settings;
        private ConfigurationPage _control;

        /// <summary>
        /// Gets or Sets the config settings
        /// </summary>
        public override IssueRepositorySettings Settings
        {
            get
            {
                if (_control != null)
                {
                    ConnectorSettings settings = _control.Settings;

                    var settingsManager = new ConnectorSettingsManager();
                    settingsManager.SaveLocalUserSettings(settings);

                    return settings.ToIssueRepositorySettings();
                }
                
                return _settings;
            }
            set
            {
                _settings = value;
                if (_settings != null 
                    && string.Equals(_settings.ConnectorName, PluginConstants.ConnectorName))
                {
                    // populate UI with new settings
                    ((ConfigurationPage)Control).Settings = _settings.ToConnectorSettings();
                }
            }
        }

        private UserControl Control
        {
            get
            {
                if (_control == null)
                {
                    ConfigurationPage control = new ConfigurationPage();
                    control.OnPageEvent += control_OnPageEvent;
                    _control = control;
                }
                return _control;
            }
        }

        void control_OnPageEvent(object sender, ConfigPageEventArgs e)
        {
            // raise page changed event to notify AnkhSVN
            base.ConfigurationPageChanged(e);
        }

        #region IWin32Window Members

        public IntPtr Handle
        {
            get { return Control.Handle; }
        }

        #endregion
    }
}
