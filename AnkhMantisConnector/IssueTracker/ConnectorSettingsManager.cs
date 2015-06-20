using System;
using System.IO;

namespace AnkhMantisConnector.IssueTracker
{
    class ConnectorSettingsManager
    {

        private static readonly string localAccountFolder;
        private const string localAccountSettingsFile = "localAccount.config";

        static ConnectorSettingsManager()
        {
            localAccountFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MantisConnector");
        }

        public void SaveLocalUserSettings(ConnectorSettings source)
        {
            if (source.LocalAccount)
            {
                if (!Directory.Exists(localAccountFolder))
                    Directory.CreateDirectory(localAccountFolder);

                File.WriteAllText(Path.Combine(localAccountFolder, localAccountSettingsFile), 
                    "user=" + source.UserName + "&pass=" + source.Password);
            }
        }

        public void LoadLocalUserSettings(ConnectorSettings destination)
        {
            if (destination == null)
                throw new ArgumentNullException("destination");

            string filePath = Path.Combine(localAccountFolder, localAccountSettingsFile);

            if (!File.Exists(filePath))
                return;

            string[] entries = File.ReadAllText(filePath).Split('&');

            foreach (string entry in entries)
            {
                var keyValue = entry.Split(new[] {'='}, 2);
                if (keyValue.Length != 2) continue;

                switch (keyValue[0])
                {
                    case "user":
                        destination.UserName = keyValue[1];

                        break;

                    case "pass":
                        destination.Password = keyValue[1];

                        break;
                }
            }
        }

    }
}
