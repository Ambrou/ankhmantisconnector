using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnkhMantisConnector.IssueTracker
{
    class ConnectorSettings
    {

        public string ProjectId { get; set; }

        public Uri RepositoryUri { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public ConnectorSettings()
        {
        }

    }
}
