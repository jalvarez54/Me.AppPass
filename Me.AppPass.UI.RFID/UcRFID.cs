using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Me.AppPass.ServiceInterface;
using Me.AppPass.UI.Base;
using Phidgets; //Needed for the RFID class and the PhidgetException class
using Phidgets.Events; //Needed for the phidget event handling classes

namespace Me.AppPass.UI.RFID
{

    /// <summary>
    /// RFID hardware authentication provide implementation
    /// </summary>
    public partial class UcRFID : UcBase
    {
        private Phidgets.RFID rfid; //Declare an RFID object

        public UcRFID()
        {

            InitializeComponent();

            this.rfid = new Phidgets.RFID();

            this.rfid.Attach += Rfid_Attach;
            this.rfid.Detach += Rfid_Detach;
            this.rfid.Tag += Rfid_Tag;
            this.rfid.TagLost += Rfid_TagLost;

            this.rfid.open();

            this.textBoxName.Text = "";
            this.textBoxVersion.Text = "";
            this.textBoxTag.Text = "";
            this.checkBoxAttached.Checked = false;


            this.Disposed += UcRFID_Disposed;

        }

        private void UcRFID_Disposed(object sender, EventArgs e)
        {

            this.textBoxName.Text = "";
            this.textBoxVersion.Text = "";
            this.checkBoxAttached.Checked = false;
            this.IsLocked = false;
            this.StatusMessage("RFID module unplugged");

            this.rfid.Attach -= Rfid_Attach;
            this.rfid.Detach -= Rfid_Detach;
            this.rfid.Tag -= Rfid_Tag;
            this.rfid.TagLost -= Rfid_TagLost;

            //run any events in the message queue - otherwise close will hang if there are any outstanding events
            Application.DoEvents();

            this.rfid.close();

        }

        private void Rfid_TagLost(object sender, TagEventArgs e)
        {

            TagNotPresent(e);

        }

        private void Rfid_Tag(object sender, TagEventArgs e)
        {

            this.TagPresent(e);

            this.textBoxTag.Text = e.Tag;

        }

        private void Rfid_Detach(object sender, DetachEventArgs e)
        {

            Phidgets.RFID detached = (Phidgets.RFID)sender;

            this.textBoxName.Text = "";
            this.textBoxVersion.Text = "";
            this.textBoxTag.Text = "";
            this.checkBoxAttached.Checked = false;
            this.IsLocked = false;

            this.tokenValidator.ID = "";
            this.tokenValidator.UserName = "";
            this.tokenValidator.IsValid = false;

            this.StatusMessage("RFID module detached");

        }

        private void Rfid_Attach(object sender, AttachEventArgs e)
        {

            Phidgets.RFID attached = (Phidgets.RFID)sender;

            this.textBoxName.Text = attached.Name;
            this.textBoxVersion.Text = attached.Version.ToString();
            this.checkBoxAttached.Checked = true;
            this.IsLocked = false;

            this.rfid.Antenna = true;
            this.rfid.LED = true;
            this.StatusMessage("RFID module attached");

        }

        private void TagNotPresent(TagEventArgs e)
        {

            if (this.tokenValidator != null)
            {
                if (this.tokenValidator.IsValid)
                {
                    // APPLICATION ACTIVE & TAG NOT PRESENT
                    this.HideProtectedApplication();
                    this.IsLocked = true;
                    this.rfid.LED = true;
                    this.StatusMessage("Application had been locked");
                    return;
                }
            }
            // APPLICATION NOT ACTIVE & NON VALIDE TAG
            this.HideProtectedApplication();
            this.IsLocked = false;
            this.rfid.LED = false;
            this.textBoxTag.Text = "";
            this.StatusMessage("Tag leave and not valide");
            System.Threading.Thread.Sleep(1000);
            this.StatusMessage("RFID module attached");

        }
        private void TagPresent(TagEventArgs e)
        {
            if (this.AdministrationMode)
            {
                this.ForAdmin(e.Tag);
                return;
            }
            try
                {
                if (this.IsLocked & e.Tag == this.tokenValidator.ID)
                {
                    // APPLICATION WAS ACTIVE & VALIDE TAG AGAIN
                    this.ShowProtectedApplication();

                    this.IsLocked = false;
                    this.rfid.LED = true;
                    this.StatusMessage("Validation OK application in use again");
                    return;
                }
                else
                {
                    if (!this.tokenValidator.IsValid & this.IsTokenValid(Environment.UserName, e.Tag))
                    {
                        // FIRST USE ACTIVATE APPLICATION & VALIDE TAG PRESENT
                        this.tokenValidator.UserName = Environment.UserName;
                        this.tokenValidator.ID = e.Tag;
                        this.tokenValidator.IsValid = true;
                        this.IsLocked = false;
                        this.rfid.LED = true;
                        this.StatusMessage("First Validation OK");
                        this.ShowProtectedApplication();
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
            }

            if (this.IsLocked)
            {
                // A USER ATTEMPT TO UNLOCK A LOCKED APPLICATION
                this.StatusMessage("Application is locked Tag present and not valide");
            }
            else
            {
                // APPLICATION NOT ACTIVE & NON VALIDE TAG
                this.HideProtectedApplication();
                this.IsLocked = false;
                this.rfid.LED = false;
                this.textBoxTag.Text = "";
                this.StatusMessage("Tag present and not valide");
            }
        }

    }

}
