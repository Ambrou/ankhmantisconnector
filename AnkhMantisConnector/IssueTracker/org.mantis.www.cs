using System.Net;
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

        public NetworkCredential GetUserCredential()
        {
            var cred = Ookii.Dialogs.CredentialDialog.RetrieveCredentialFromApplicationInstanceCache(Url);
            if (cred == null)
            {
                if (credDlg == null)
                {
                    credDlg = new Ookii.Dialogs.CredentialDialog();
                    credDlg.Target = Url;
                    credDlg.UseApplicationInstanceCredentialCache = true;
                    credDlg.ShowSaveCheckBox = true;
                    credDlg.ShowUIForSavedCredentials = true;
                    credDlg.WindowTitle = "Issue Tracker";
                    credDlg.MainInstruction = "Provide password for " + Url;
                }
                if (credDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    cred = credDlg.Credentials;
                }
            }
            return cred;
        }
        public void ConfirmUserCredential(bool confirm)
        {
            if (credDlg != null)
            {
                credDlg.ConfirmCredentials(confirm);
            }
        }

        public NetworkCredential Authentificate()
        {
            var cred = GetUserCredential();
            if (cred != null)
            {
                try
                {
                    var projects = mc_projects_get_user_accessible(cred.UserName, cred.Password);
                }
                catch (System.Exception excep)
                {
                    System.Diagnostics.Debug.Assert(false, excep.Message);
                    ConfirmUserCredential(false);
                    return null;
                }
                ConfirmUserCredential(true);
                return cred;
            }
            return cred;
        }
    }
}