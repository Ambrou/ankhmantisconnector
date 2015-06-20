//TODO: Search
//TODO: Closing bugs
//TODO: Default filter
//TODO: Advanced Settings
//TODO: More error handling
//TODO: Permissions check for closing bugs, adding notes, etc
//TODO: Adding option to create new bug reports
//TODO: Make FD plugin
//TODO: Adding option when closing bugs to open a full form
//TODO: Make TortoiseSVN plugin
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ankh.ExtensionPoints.IssueTracker;
using AnkhMantisConnector.IssueTracker.Forms;

namespace AnkhMantisConnector.IssueTracker
{
    public enum DefaultAccessLevels
    {
        Anybody = 0,
        Viewer = 10,
        Reporter = 25,
        Updater = 40,
        Developer = 55,
        Manager = 70,
        Administrator = 90,
        Nobody = 100
    }

    /// <summary>
    /// Represents an Issue Repository
    /// </summary>
    internal class AnkhRepository : IssueRepository, IWin32Window, IDisposable
    {
        private ConnectorSettings _settings;
        private IDictionary<string, object> _properties;
        private string _repositoryId;
        private IssuesView _control;

        public static IssueRepository Create(IssueRepositorySettings settings)
        {
            if (settings != null)
                return new AnkhRepository(settings.RepositoryUri, settings.RepositoryId, settings.CustomProperties);
            
            return null;
        }

        public AnkhRepository(Uri uri, string repositoryId, IDictionary<string, object> properties)
            : base(PluginConstants.ConnectorName)
        {
            _repositoryId = repositoryId;
            _properties = properties;
            _settings = properties.ToConnectorSettings(uri);
        }

        /// <summary>
        /// Gets the repository connection URL
        /// </summary>
        public override Uri RepositoryUri
        {
            get { return _settings.RepositoryUri; }
        }

        /// <summary>
        /// Gets the repository id hosted on the RepositoryUri
        /// </summary>
        /// <remarks>optional</remarks>
        public override string RepositoryId
        {
            get { return _repositoryId; }
        }

        /// <summary>
        /// Gets the custom properties specific to this type of connector
        /// </summary>
        public override IDictionary<string, object> CustomProperties
        {
            get { return _properties; }
        }

        /// <summary>
        /// Gets the repository label
        /// </summary>
        public override string Label
        {
            get { return RepositoryId ?? (RepositoryUri == null ? string.Empty : RepositoryUri.ToString()); }
        }

        public override string IssueIdPattern
        {
            get
            {
                return _settings.IssuePattern;
            }
        }

        public override void PreCommit(PreCommitArgs args)
        {
            if (_control.SelectedIssues.Any())
            {
                var associatedIssues = new System.Text.StringBuilder();

                foreach (var issue in _control.SelectedIssues)
                {
                    associatedIssues.Append("#" + issue.id + ", ");
                }

                associatedIssues.Remove(associatedIssues.Length - 2, 2);

                args.CommitMessage += "\nAffected issues: " + associatedIssues;
            }

            base.PreCommit(args);
        }

        public override void PostCommit(PostCommitArgs args)
        {
            if (_settings.AddNoteAfterCommit && _control.SelectedIssues.Any())
            {
                using (var service = new org.mantisbt.www.MantisConnect(_settings.RepositoryUri.ToString() + _settings.WebServicePath))
                {
                    foreach (var issue in _control.SelectedIssues)
                    {
                        service.mc_issue_note_add(_settings.UserName, _settings.Password, issue.id,
                                                  new org.mantisbt.www.IssueNoteData()
                                                      {
                                                          text = string.Format(_settings.AssociatedCommitNoteText, args.Revision, args.CommitMessage)
                                                      });
                    }
                }

            }

            base.PostCommit(args);
        }

        /// <summary>
        /// Show issue details
        /// </summary>
        /// <param name="issueId"></param>
        public override void NavigateTo(string issueId)
        {
            if (!string.IsNullOrEmpty(issueId))
            {
                // Does AnkhSVN not return capturing groups? just the match? check AnkhSVN source.
                var regEx = new System.Text.RegularExpressions.Regex("\\d+",
                                                                     System.Text.RegularExpressions.RegexOptions.
                                                                         Compiled);

                System.Diagnostics.Process.Start(_settings.RepositoryUri.ToString() + "/view.php?id=" + regEx.Match(issueId).Value);
            }
        }

        #region IWin32Window Members

        public IntPtr Handle
        {
            get { return Control.Handle; }
        }

        #endregion

        internal IssuesView Control
        {
            get
            {
                if (_control == null)
                {
                    _control = CreateControl();
                }
                _control.LoadData(_settings);

                return _control;
            }
        }

        private IssuesView CreateControl()
        {
            return new IssuesView();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_control != null && !_control.IsDisposed && !_control.Disposing)
            {
                _control.Dispose();
            }
            _control = null;
        }

        #endregion
    }
}
