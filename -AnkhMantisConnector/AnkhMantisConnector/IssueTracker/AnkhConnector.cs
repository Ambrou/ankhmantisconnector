using Ankh.ExtensionPoints.IssueTracker;

namespace AnkhMantisConnector.IssueTracker
{
    /// <summary>
    /// Sample Issue Repository connector for AnkhSVN
    /// </summary>
    [System.Runtime.InteropServices.Guid(PluginConstants.AnkhMantisExtensionConnectorGuid)]
    public class AnkhConnector : IssueRepositoryConnector
    {

        /// <summary>
        /// Gets the configuration page used in Issue Repository Setup dialog
        /// </summary>
        public override IssueRepositoryConfigurationPage ConfigurationPage
        {
            get { return new AnkhConfigurationPage(); }
        }

        /// <summary>
        /// Create an Issue repository based on the given settings
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public override IssueRepository Create(IssueRepositorySettings settings)
        {
            if (settings != null && string.Equals(settings.ConnectorName, Name))
                return AnkhRepository.Create(settings);
            
            return null;
        }

        /// <summary>
        /// Gets the connector name used in the Issue connector drop-down
        /// </summary>
        /// <remarks>Needs to be unique</remarks>
        public override string Name
        {
            get { return PluginConstants.ConnectorName; }
        }

    }
}
