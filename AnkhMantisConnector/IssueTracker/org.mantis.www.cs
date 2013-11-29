namespace AnkhMantisConnector.org.mantisbt.www
{
    public partial class MantisConnect
    {
        private Ookii.Dialogs.CredentialDialog credDlg = null;
        public MantisConnect(string url)
        {
            this.Url = url;
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }


}