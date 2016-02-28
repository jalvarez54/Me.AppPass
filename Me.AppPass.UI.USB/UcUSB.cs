using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Me.AppPass.ServiceInterface;
using Me.AppPass.UI.Base;
using System.Management;

namespace Me.AppPass.UI.USB
{

    /// <summary>
    /// USB hardware authentication provide implementation
    /// </summary>
    public partial class UcUSB : UcBase
    {
        private const string REQUETE_WMI = "Select * From __InstanceOperationEvent Within 10 Where " + "TargetInstance ISA 'Win32_LogicalDisk' AND TargetInstance.DriveType=2";
        private WqlEventQuery _eventQuery;
        private ManagementEventWatcher _eventWatcher;

        public UcUSB()
        {
            InitializeComponent();


            this.textBoxID.Text = "";
            this.textBoxName.Text = "";

            this.Disposed += UcUSB_Disposed;

        }

        private void UcUSB_Disposed(object sender, EventArgs e)
        {
            _eventWatcher.EventArrived -= _eventWatcher_EventArrived;
        }

        private void UcUSB_Load(object sender, EventArgs e)
        {
            _eventQuery = new WqlEventQuery(REQUETE_WMI);
            // S'abonner aux évènements de détection des disques amovibles.
            _eventWatcher = new ManagementEventWatcher(_eventQuery);
            _eventWatcher.EventArrived += _eventWatcher_EventArrived;
            _eventWatcher.Start();

            // Scan plugged usb for a validator
            SearchValidatorForApplication();
        }

        private void _eventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject objManagementBase;
            string deviceID;

            switch (e.NewEvent.ClassPath.ToString())
            {
                // USB arrived
                case @"\\.\root\CIMV2:__InstanceCreationEvent":
                    {
                        objManagementBase = e.NewEvent.Properties["TargetInstance"].Value as ManagementBaseObject;
                        deviceID = objManagementBase.Properties["DeviceId"].Value.ToString();
                        if (!this.AdministrationMode)
                        {
                            // Dont scan if tokenValidator.IsValid=true & isLocked=false (running state)
                            if (!(this.tokenValidator.IsValid & !this.IsLocked))
                            {
                                SearchValidatorForApplication();
                            }
                        }
                        else
                        {
                            SearchValidatorForAdministration();
                        }                     
                    }
                    break;
                // USB leaved
                case @"\\.\root\CIMV2:__InstanceDeletionEvent":
                    {
                        objManagementBase = e.NewEvent.Properties["TargetInstance"].Value as ManagementBaseObject;
                        deviceID = objManagementBase.Properties["DeviceId"].Value.ToString();
                        if (!this.AdministrationMode)
                        {
                            if (this.tokenValidator != null)
                            {
                                if (this.tokenValidator.IsValid)
                                {
                                    // APPLICATION ACTIVE & TAG NOT PRESENT
                                    this.IsLocked = true;
                                    this.StatusMessage("Application had been locked");
                                    this.HideProtectedApplication();
                                    return;
                                }
                            }
                            SearchValidatorForApplication();
                        }
                        else
                        {
                            SearchValidatorForAdministration();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void SearchValidatorForAdministration()
        {
            string pnpDeviceId;
            string[] deviceIdParts;
            string id = string.Empty;

            this.host.StatusMessage = "";

            try
            {
                using (ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive"))
                {
                    foreach (ManagementObject objQuery in objSearcher.Get())
                    {
                        pnpDeviceId = objQuery["PNPDeviceID"].ToString();
                        if (pnpDeviceId.StartsWith("USBSTOR"))
                        {
                            deviceIdParts = pnpDeviceId.Split(new char[] { '&' });
                            id = deviceIdParts[(deviceIdParts.Length - 2)];

                            this.ForAdmin(id);

                        }
                    }
                }
            }
            catch (ManagementException ex)
            {
                this.ExceptionMessage(ex.Message);
            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
            }

        }

        /// <summary>
        /// Search 
        /// </summary>
        private void SearchValidatorForApplication()
        {
            string pnpDeviceId;
            string[] deviceIdParts;
            string id = string.Empty;

            this.textBoxName.Text = "";
            this.textBoxID.Text = "";
            this.host.StatusMessage = "";

            try
            {
                using (ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive"))
                {
                    foreach (ManagementObject objQuery in objSearcher.Get())
                    {
                        pnpDeviceId = objQuery["PNPDeviceID"].ToString();
                        if (pnpDeviceId.StartsWith("USBSTOR"))
                        {
                            deviceIdParts = pnpDeviceId.Split(new char[] { '&' });
                            id = deviceIdParts[(deviceIdParts.Length - 2)];

                            //
                            // Initially tokenValidator.IsValid=false & isLocked=false
                            //
                            // The first time
                            if (!this.tokenValidator.IsValid & this.IsTokenValid(Environment.UserName, id))
                            {
                                this.textBoxName.Text = deviceIdParts[2];
                                this.textBoxID.Text = id;

                                this.tokenValidator.UserName = Environment.UserName;
                                this.tokenValidator.ID = id;
                                this.tokenValidator.IsValid = true;
                                this.IsLocked = false;
                                this.StatusMessage("First Validation OK");
                                this.ShowProtectedApplication();
                                return;
                            }
                            // Validator replugged (dont need to call again bll
                            if (this.tokenValidator.IsValid & this.tokenValidator.ID == id)
                            {
                                this.textBoxName.Text = deviceIdParts[2];
                                this.textBoxID.Text = id;

                                this.IsLocked = false;

                                this.StatusMessage("Validation OK application in use again");
                                this.ShowProtectedApplication();
                                return;
                            }

                        }
                    }
                }
            }
            catch (ManagementException ex)
            {
                this.ExceptionMessage(ex.Message);
            }
            catch (Exception ex)
            {
                this.ExceptionMessage(ex.Message);
            }
            if (this.IsLocked)
            {
                // A USER ATTEMPT TO UNLOCK A LOCKED APPLICATION
                this.HideProtectedApplication();
                this.StatusMessage("Application is locked usb present and not valide");
            }
            else
            {
                // APPLICATION NOT ACTIVE & NON VALIDE USB
                this.HideProtectedApplication();
                this.IsLocked = false;
                this.StatusMessage("No valide usb present");
            }

        }

    }
}
