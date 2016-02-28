using System;
using System.Windows.Forms;
using Me.AppPass.ServiceInterface;
using Me.AppPass.BLL;
using Me.AppPass.Common;
using System.Reflection;
using System.Diagnostics;

namespace Me.AppPass.UI.Base
{
    public partial class UcBase : UserControl, IPlugin
    {


        public UcBase()
        {
            InitializeComponent();

            this.progressBarBase.Value = 100;

            // Create Business instance
            try
            {
                this.bllValidation = new BLLValidation(
                    System.Configuration.ConfigurationManager.AppSettings.Get("DalAssemblyName"),
                    System.Configuration.ConfigurationManager.AppSettings.Get("DalType"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Control initial values
            this.textBoxAdminUserName.Text = Environment.UserName;
            this.textBoxAdminID.Text = "";
            this.checkBoxAdmin.Checked = false;
            this.panelAdmin.Visible = this.checkBoxAdmin.Checked;
            this.checkBoxAdmin.Enabled = false;

            // Only administrator can use checkBoxAdmin
            if (Utils.MySystem.IsAdmin()) this.checkBoxAdmin.Enabled = true;

            // Create and initialize tokenValidator
            this.tokenValidator = new Token();
            this.tokenValidator.ID = "";
            this.tokenValidator.UserName = "";
            this.tokenValidator.IsValid = false;

            this.IsLocked = false;

        }

        private void ApplicationForm_Disposed(object sender, EventArgs e)
        {
            this.ParentForm.Show();
        }

        /// <summary>
        /// FormProtected handle
        /// </summary>
        protected Form ApplicationForm = new Company.Application.FormProtected();
        /// <summary>
        /// UcHost handle to access some controls
        /// </summary>
        protected IHost host;
        /// <summary>
        /// Application is locked
        /// </summary>
        private bool isLocked;
        /// <summary>
        /// Admin mode enable
        /// </summary>
        private bool administrationMode;
        /// <summary>
        /// Business instance
        /// </summary>
        private BLLValidation bllValidation;
        /// <summary>
        /// Validator token
        /// </summary>
        public Token tokenValidator;


        #region IPlugin implementation

        string IPlugin.PluginName
        {
            get
            {
                return this.Name;
            }
        }

        void IPlugin.SetHostHandleToBaseUserControl(IHost hostHandle)
        {
            this.host = hostHandle; ;
        }

        #endregion

        /// <summary>
        /// Used by childs user controls to show FormProtected and hide FormMain
        /// </summary>
        protected void ShowProtectedApplication()
        {
            this.ParentForm.Hide();
            if(this.ApplicationForm == null)
            {
                this.ApplicationForm = new Company.Application.FormProtected();
            }
            this.ApplicationForm.ShowDialog();
            this.ParentForm.Show();
        }

        /// <summary>
        /// Used by childs user controls to show FormMain and hide FormProtected
        /// </summary>
        protected void HideProtectedApplication()
        {
            this.ParentForm.Show();
            if (this.ApplicationForm != null)
            {
                this.ApplicationForm.Hide();
            }

        }

        /// <summary>
        /// Called by childs for authentication
        /// BLL return a the token with IsValid property false or true
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool IsTokenValid(string userName, string id)
        {

            this.tokenValidator.UserName = userName;
            this.tokenValidator.ID = id;

            this.tokenValidator = this.bllValidation.IsTokenValid(this.tokenValidator);

            if (this.tokenValidator.IsValid)
            {
                return true;
            }

            // If we came here token is invalid
            return false;
        }

        /// <summary>
        /// Locked when user unplug validator (USB key, RFID tag...)
        /// </summary>
        protected bool IsLocked
        {
            get
            {
                return isLocked;
            }

            set
            {
                isLocked = value;
                // Use this inherited property to manage checkBoxIsLocked UcBase control from childs user control
                this.checkBoxIsLocked.Checked = isLocked;
            }
        }

        /// <summary>
        /// Working in admin mode
        /// </summary>
        protected bool AdministrationMode
        {
            get
            {
                return administrationMode;
            }

            set
            {
                administrationMode = value;
                // Use this inherited property to manage checkBoxAdmin UcBase control from childs user control
                this.checkBoxAdmin.Checked = administrationMode;

            }
        }

        /// <summary>
        /// Called by childs to initialize controls in admin mode
        /// </summary>
        /// <param name="id"></param>
        protected void ForAdmin(string id)
        {
            this.textBoxAdminUserName.Text = Environment.UserName;
            this.textBoxAdminID.Text = id;

        }

        /// <summary>
        /// Show or hide admin controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            this.administrationMode = cb.Checked;
            this.panelAdmin.Visible = this.checkBoxAdmin.Checked;

        }

        /// <summary>
        /// Create a token in the store request
        /// Admin mode only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                this.bllValidation.CreateToken(this.textBoxAdminUserName.Text, this.textBoxAdminID.Text);

            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
                return;
            }
            this.StatusMessage(string.Format("Token {0} {1} created successfully", this.textBoxAdminUserName.Text, this.textBoxAdminID.Text));
        }

        /// <summary>
        /// Remove a token from the store request
        /// Admin mode only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.bllValidation.DeleteToken(this.textBoxAdminUserName.Text);

            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
                return;
            }
            this.StatusMessage(string.Format("Token {0} deleted successfully", this.textBoxAdminUserName.Text));

        }

        /// <summary>
        /// Encrypt the store request
        /// Admin mode only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                this.bllValidation.EncryptTokens();

            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
                return;
            }

            this.StatusMessage("Tokens successfully encrypted");

        }

        /// <summary>
        /// Decrypt the store request
        /// Admin mode only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                this.bllValidation.DecryptTokens();

            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
                return;
            }

            this.StatusMessage("Tokens successfully decrypted");
        }

        protected void ExceptionMessage(string message)
        {
            // Who call me
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();

            string mesPlus = string.Format("[{0}] [{1}] {2}", DateTime.Now, methodBase.Name, message);

            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.host.StatusMessage = message;
            Trace.TraceError(mesPlus);
        }

        protected void StatusMessage(string message)
        {
            // Who call me
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();

            string mesPlus = string.Format("[{0}] [{1}] {2}", DateTime.Now, methodBase.Name, message);

            this.host.StatusMessage = message;
            Trace.TraceInformation(mesPlus);

        }

    }

}
