using System;
using System.Collections.Generic;
using Ankh.ExtensionPoints.IssueTracker;

namespace AnkhMantisConnector.IssueTracker
{
    static class Extensions
    {

        private const string PROPERTY_USERNAME = "username";
        private const string PROPERTY_PASSCODE = "passcode";
        private const string PROPERTY_PROJECT = "project";
        private const string PROPERTY_PERPAGE = "perpage";
        private const string PROPERTY_LOCALACC = "localacc";
        private const string PROPERTY_FETCHINGMETHOD = "fetchmeth";
        private const string PROPERTY_ISSUEPATTERN = "issuepattern";
        private const string PROPERTY_SOAPURI = "soappath";
        private const string PROPERTY_ADDNOTE = "addnote";
        private const string PROPERTY_ASSOCIATEDNOTE = "associatednode";
        private const string PROPERTY_CLOSENOTE = "closenote";

        public static IssueRepositorySettings ToIssueRepositorySettings(this ConnectorSettings src)
        {
            var props = new Dictionary<string, Object>();
            props[PROPERTY_PROJECT] = src.ProjectId;
            props[PROPERTY_PERPAGE] = src.IssuesPerPage;
            props[PROPERTY_LOCALACC] = src.LocalAccount;
            props[PROPERTY_SOAPURI] = src.WebServicePath;
            props[PROPERTY_FETCHINGMETHOD] = ((int) src.FetchingMethod);
            props[PROPERTY_ISSUEPATTERN] = src.IssuePattern;
            props[PROPERTY_ADDNOTE] = src.AddNoteAfterCommit;
            props[PROPERTY_ASSOCIATEDNOTE] = src.AssociatedCommitNoteText;
            props[PROPERTY_CLOSENOTE] = src.CloseCommitNoteText;

            if (!src.LocalAccount)
            {
                props[PROPERTY_USERNAME] = src.UserName;
                props[PROPERTY_PASSCODE] = src.Password;
            }

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

            if (src.TryGetValue(PROPERTY_PROJECT, out value))
                retVal.ProjectId = value.ToString();

            if (src.TryGetValue(PROPERTY_LOCALACC, out value))
                retVal.LocalAccount = bool.Parse(value.ToString());

            if (!retVal.LocalAccount)
            {
                if (src.TryGetValue(PROPERTY_USERNAME, out value))
                    retVal.UserName = value.ToString();

                if (src.TryGetValue(PROPERTY_PASSCODE, out value))
                    retVal.Password = value.ToString();
            }

            if (src.TryGetValue(PROPERTY_PERPAGE, out value))
                retVal.IssuesPerPage = int.Parse(value.ToString());

            if (src.TryGetValue(PROPERTY_SOAPURI, out value))
                retVal.WebServicePath = value.ToString();

            if (src.TryGetValue(PROPERTY_FETCHINGMETHOD, out value))
                retVal.FetchingMethod = (FetchingMethod)int.Parse(value.ToString());

            if (src.TryGetValue(PROPERTY_ISSUEPATTERN, out value))
                retVal.IssuePattern = value.ToString();

            if (src.TryGetValue(PROPERTY_ADDNOTE, out value))
                retVal.AddNoteAfterCommit = bool.Parse(value.ToString());

            if (src.TryGetValue(PROPERTY_ASSOCIATEDNOTE, out value))
                retVal.AssociatedCommitNoteText = value.ToString();

            if (src.TryGetValue(PROPERTY_CLOSENOTE, out value))
                retVal.CloseCommitNoteText = value.ToString();

            return retVal;
        }
    }
}
