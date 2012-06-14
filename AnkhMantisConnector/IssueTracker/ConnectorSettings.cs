using System;
using System.ComponentModel;

namespace AnkhMantisConnector.IssueTracker
{
    enum FetchingMethod
    {
        GetFullData = 0,
        GetHeaderData,
        GetExactData,
    }

    class ConnectorSettings
    {

        private const string DefaultWebServicePath = "/api/soap/mantisconnect.php";
        private const string DefaultIssuePattern = @"(?:(?:#?id)|#)(\d+)";
        private const string DefaultAssociatedCommitNoteText = "Work done for this issue in Revision {0}:\n{1}";
        private const string DefaultCloseCommitNoteText = "Issue closed in Revision {0}:\n{1}";

        [Description("The Id of the project to track")]
        [Category("Issues View")]
        public int ProjectId { get; set; }

        [Description("Address to the root path of the MantisBT installation")]
        [Category("Connection")]
        public Uri RepositoryUri { get; set; }

        [Description("User name used to connect to the tracker")]
        [Category("Connection")]
        public string UserName { get; set; }

        [Description("Password used to connect to the tracker")]
        [Category("Connection")]
        public string Password { get; set; }

        [DefaultValue(50)]
        [Description("Number of issues to fetch per page")]
        [Category("Issues View")]
        public int IssuesPerPage { get; set; }

        [DefaultValue(false)]
        [Description("Determines whether the user and password data should be stored in a local file instead of using a SVN property")]
        [Category("Connection")]
        public bool LocalAccount { get; set; }

        [DefaultValue(DefaultWebServicePath)]
        [Description("The relative path to the SOAP service")]
        [Category("Connection")]
        public string WebServicePath { get; set; }

        [DefaultValue(0)]
        [Description("The method used to retrieve data from the tracker")]
        [Category("Connection")]
        public FetchingMethod FetchingMethod { get; set; }

        [DefaultValue(DefaultIssuePattern)]
        [Description("The pattern used to match the issue ids present in a commit message")]
        [Category("Integration")]
        public string IssuePattern { get; set; }

        [DefaultValue(true)]
        [Description("Whether a note should be added to the issue in the tracker after a commit")]
        [Category("Integration")]
        public bool AddNoteAfterCommit { get; set; }

        [DefaultValue(DefaultAssociatedCommitNoteText)]
        [Description("The text for the note to add to each associated issue in a commit")]
        [Category("Integration")]
        public string AssociatedCommitNoteText { get; set; }

        [DefaultValue(DefaultCloseCommitNoteText)]
        [Description("The text for the note to add to each closed issue in a commit")]
        [Category("Integration")]
        public string CloseCommitNoteText { get; set; }

        [DefaultValue(-1)]
        [Description("Default filter to use when viewing issues. Use -1 in order to display all issues")]
        [Category("Issues View")]
        public int DefaultFilter { get; set; }

        public ConnectorSettings()
        {
            IssuesPerPage = 50;
            WebServicePath = DefaultWebServicePath;
            IssuePattern = DefaultIssuePattern;
            AddNoteAfterCommit = true;
            CloseCommitNoteText = DefaultCloseCommitNoteText;
            AssociatedCommitNoteText = DefaultAssociatedCommitNoteText;
            DefaultFilter = -1;
        }

    }
}
