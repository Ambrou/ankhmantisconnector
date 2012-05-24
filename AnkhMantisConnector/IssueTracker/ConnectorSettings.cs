using System;
using System.ComponentModel;

namespace AnkhMantisConnector.IssueTracker
{
    class ConnectorSettings
    {

        public string ProjectId { get; set; }

        public Uri RepositoryUri { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [DefaultValue(50)]
        public int IssuesPerPage { get; set; }

        [DefaultValue(false)]
        public bool LocalAccount { get; set; }

        [DefaultValue("/api/soap/mantisconnect.php")]
        public string WebServicePath { get; set; }

        public int FetchingMethod { get; set; }

        public ConnectorSettings()
        {
            IssuesPerPage = 50;
            WebServicePath = "/api/soap/mantisconnect.php";
        }

    }
}
