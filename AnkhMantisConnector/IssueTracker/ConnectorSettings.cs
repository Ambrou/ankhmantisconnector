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

        int _projectId;
        [Description("The Id of the project to track")]
        [Category("Issues View")]
        public int ProjectId
        {
            get
            {
                return this._projectId;
            }
            set
            {
                this._projectId = value;
            }
        }

        Uri _RepositoryUri;
        [Description("Address to the root path of the MantisBT installation")]
        [Category("Connection")]
        public Uri RepositoryUri 
        {
            get
            {
                return this._RepositoryUri;
            }
            set
            {
                this._RepositoryUri = value;
            }
        }

        string _UserName;
        [Description("User name used to connect to the tracker")]
        [Category("Connection")]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        string _Password;
        [Description("Password used to connect to the tracker")]
        [Category("Connection")]
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        int _IssuesPerPage;
        [DefaultValue(50)]
        [Description("Number of issues to fetch per page")]
        [Category("Issues View")]
        public int IssuesPerPage
        {
            get
            {
                return this._IssuesPerPage;
            }
            set
            {
                this._IssuesPerPage = value;
            }
        }

        bool _LocalAccount;
        [DefaultValue(false)]
        [Description("Determines whether the user and password data should be stored in a local file instead of using a SVN property")]
        [Category("Connection")]
        public bool LocalAccount
        {
            get
            {
                return this._LocalAccount;
            }
            set
            {
                this._LocalAccount = value;
            }
        }

        string _WebServicePath;
        [DefaultValue(DefaultWebServicePath)]
        [Description("The relative path to the SOAP service")]
        [Category("Connection")]
        public string WebServicePath
        {
            get
            {
                return this._WebServicePath;
            }
            set
            {
                this._WebServicePath = value;
            }
        }

        FetchingMethod _FetchingMethod;
        [DefaultValue(0)]
        [Description("The method used to retrieve data from the tracker")]
        [Category("Connection")]
        public FetchingMethod FetchingMethod
        {
            get
            {
                return this._FetchingMethod;
            }
            set
            {
                this._FetchingMethod;
            }
        }

        string _IssuePattern;
        [DefaultValue(DefaultIssuePattern)]
        [Description("The pattern used to match the issue ids present in a commit message")]
        [Category("Integration")]
        public string IssuePattern
        {
            get
            {
                return this._IssuePattern;
            }
            set
            {
                this._IssuePattern = value;
            }
        }

        bool _AddNoteAfterCommit;
        [DefaultValue(true)]
        [Description("Whether a note should be added to the issue in the tracker after a commit")]
        [Category("Integration")]
        public bool AddNoteAfterCommit
        {
            get
            {
                return this._AddNoteAfterCommit;
            }
            set
            {
                this._AddNoteAfterCommit = value
            }
        }

        string _AssociatedCommitNoteText;
        [DefaultValue(DefaultAssociatedCommitNoteText)]
        [Description("The text for the note to add to each associated issue in a commit")]
        [Category("Integration")]
        public string AssociatedCommitNoteText
        {
            get
            {
                return this._AssociatedCommitNoteText;
            }
            set
            {
                this._AssociatedCommitNoteText = value;
            }
        }

        string _CloseCommitNoteText;
        [DefaultValue(DefaultCloseCommitNoteText)]
        [Description("The text for the note to add to each closed issue in a commit")]
        [Category("Integration")]
        public string CloseCommitNoteText
        {
            get
            {
                return this._CloseCommitNoteText;
            }
            set
            {
                this._CloseCommitNoteText = value;
            }
        }

        int _DefaultFilter;
        [DefaultValue(-1)]
        [Description("Default filter to use when viewing issues. Use -1 in order to display all issues")]
        [Category("Issues View")]
        public int DefaultFilter
        {
            get
            {
                return this._DefaultFilter;
            }
            set
            {
                this._DefaultFilter = value;
            }
        }

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
