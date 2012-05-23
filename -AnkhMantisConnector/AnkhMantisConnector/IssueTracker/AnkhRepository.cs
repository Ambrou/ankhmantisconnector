// TODO: Local User/Pass
// TODO: Advanced Settings
// TODO: Async load
// TODO: Search
// TODO: Change paging buttons with images
// TODO: Bug message parsing
// TODO: Associating
// TODO: Permissions check for closing bugs, adding notes, etc
// TODO: Adding option to create new bug reports
// TODO: Adding option when closing bugs to open a full form
// TODO: Add issue view sorting
// TODO: Make TortoiseSVN plugin
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ankh.ExtensionPoints.IssueTracker;
using AnkhMantisConnector.IssueTracker.Forms;

namespace AnkhMantisConnector.IssueTracker
{
    /// <summary>
    /// Represents an Issue Repository
    /// </summary>
    internal class AnkhRepository : IssueRepository, IWin32Window, IDisposable
    {
        Uri _uri;
        string _repositoryId;
        IDictionary<string, object> _properties;
        IssuesView _control;

        public static IssueRepository Create(IssueRepositorySettings settings)
        {
            if (settings != null)
                return new AnkhRepository(settings.RepositoryUri, settings.RepositoryId, settings.CustomProperties);
            
            return null;
        }

        public AnkhRepository(Uri uri, string repositoryId, IDictionary<string, object> properties)
            : base(PluginConstants.ConnectorName)
        {
            _uri = uri;
            _repositoryId = repositoryId;
            _properties = properties;
        }

        /// <summary>
        /// Gets the repository connection URL
        /// </summary>
        public override Uri RepositoryUri
        {
            get { return _uri; }
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
                // reg expression to recognize issue id's within a text (i.e commit log message)
                // for example:
                // Text -> Sample id001, #id002 and id003
                // Resolved Issue Ids -> id001, id002, id003
                // How to test: 
                // 1. Set the current Issue repository to be this.
                // 2. Type a commit message in Pending Changes message box that would match this pattern
                // 3. See that issue ids are colorized, and "open issue" context option is available
                return @"[Ss]ample?:?\s*(#\s*)?(?<id>id\d+)(\s*(,|and)\s*(#\s*)?(?<id>id\d+))*";
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
            // show issue details
            if (!string.IsNullOrEmpty(issueId))
            {
                string message = string.Format("{0} is an issue in {1}", issueId, RepositoryUri.ToString());
                MessageBox.Show(message, "Navigate to Issue", MessageBoxButtons.OK);
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
                _control.LoadData(_properties.ToConnectorSettings(_uri));

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
