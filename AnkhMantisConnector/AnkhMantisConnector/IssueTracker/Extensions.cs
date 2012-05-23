using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ankh.ExtensionPoints.IssueTracker;

namespace AnkhMantisConnector.IssueTracker
{
    static class Extensions
    {

        private const string PROPERTY_USERNAME = "username";
        private const string PROPERTY_PASSCODE = "passcode";
        private const string PROPERTY_PROJECT = "project";

        public static IssueRepositorySettings ToIssueRepositorySettings(this ConnectorSettings src)
        {
            var props = new Dictionary<string, Object>();
            props[PROPERTY_USERNAME] = src.UserName;
            props[PROPERTY_PASSCODE] = src.Password;
            props[PROPERTY_PROJECT] = src.ProjectId;

            return new AnkhRepository(src.RepositoryUri, null, props);
        }

        public static ConnectorSettings ToConnectorSettings(this IssueRepositorySettings src)
        {
            return ToConnectorSettings(src.CustomProperties, src.RepositoryUri);
        }

        public static ConnectorSettings ToConnectorSettings(this IDictionary<string, Object> src, Uri repositoryUri)
        {
            var retVal = new ConnectorSettings();
            retVal.RepositoryUri = new Uri(repositoryUri.ToString());

            Object value = null;

            if (src.TryGetValue(PROPERTY_USERNAME, out value))
                retVal.UserName = value.ToString();

            if (src.TryGetValue(PROPERTY_PROJECT, out value))
                retVal.ProjectId = value.ToString();

            if (src.TryGetValue(PROPERTY_PASSCODE, out value))
                retVal.Password = value.ToString();

            return retVal;
        }
    }
}
