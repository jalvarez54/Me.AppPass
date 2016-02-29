using Me.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Me.AppPass.ServiceInterface;

namespace Me.AppPass.UI
{
    public partial class FormMain : Form
    {

        internal UcHost ucHost;

        public FormMain()
        {
            InitializeComponent();
            //
            // Creation of Host uc to be added to the form window.
            //
            this.ucHost = new UcHost();
            //
            // ucHost parameters
            //
            this.ucHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHost.Location = new System.Drawing.Point(0, 0);
            this.ucHost.Name = "UcHost";
            if (MySystem.IsAdmin())
            {
                this.Text += " - Admin mode";
                this.Height = 290;
                this.Width = 535;
            }
            else
            {
                // We hide Admin controls
                this.Text += " - User mode";
                this.Height = 255;
                this.Width = 535;
            }
            // Adding controls
            this.Controls.Add(this.ucHost);
        }
    }
}
