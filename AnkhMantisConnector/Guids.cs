using System;

namespace AnkhMantisConnector
{
    static class GuidList
    {
        public const string guidAnkhSampleExtensionPkgString = "189df72a-33fb-44c6-9e60-a969882db1d2";
        public const string guidAnkhSampleExtensionCmdSetString = "8d9f4e43-7321-4884-b7d0-c81c1ed490fc";
        public const string guidAnkhSampleExtensionConnectorString = "B0B92E9E-3B9F-45fa-B43F-AF11D2A14923";

        public static readonly Guid guidAnkhSampleExtensionCmdSet = new Guid(guidAnkhSampleExtensionCmdSetString);
    };
}