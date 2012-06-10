//TODO: Advanced Settings
//TODO: More error handling
//TODO: Search
//TODO: Bug message parsing
//TODO: Associating
//TODO: Permissions check for closing bugs, adding notes, etc
//TODO: Adding option to create new bug reports
//TODO: Adding option when closing bugs to open a full form
//TODO: Make TortoiseSVN plugin
//TODO: Make FD plugin
using System;
using System.Collections.Generic;
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
            bool valid = true; // perform issue related pre-commit checks
            if (valid)
            {
                // modify commit message here
                string originalMessage = args.CommitMessage ?? string.Empty;
                // get _control.SelectedIssues
                // modify original message to include issue info in the message
                args.CommitMessage = originalMessage;
            }
            args.Cancel = valid; // true if "some" pre-commit check fails
        }

        public override void PostCommit(PostCommitArgs args)
        {
            // post-process selected issues after commit is done
            // i.e. change issue status, add a comment to the issue(s) about commit info etc.
            long committedRevision = args.Revision;
            string commitMessage = args.CommitMessage;
            
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
                System.Diagnostics.Process.Start(issueId);
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
